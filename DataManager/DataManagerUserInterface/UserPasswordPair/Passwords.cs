using DataManagerDomain;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PasswordsManagerUserInterface
{
    public partial class Passwords : UserControl
    {
        public DataManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        private readonly DataGridViewButtonColumn fullViewNormalPasswords;
        private readonly DataGridViewButtonColumn fullViewSharedPasswords;

        public Passwords(DataManager aPasswordManager, Panel panel)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = panel;
            fullViewNormalPasswords = new DataGridViewButtonColumn();
            fullViewSharedPasswords = new DataGridViewButtonColumn();
            LoadNormalPasswords();
            LoadSharedPasswords();
        }

        public void LoadNormalPasswords()
        {
            var userPasswordPairs = PasswordManager.
                CurrentUser.GetUserPasswordPairs();
            LoadDataGridNormalPasswords(userPasswordPairs);
        }

        private void LoadDataGridNormalPasswords(UserPasswordPair[] userPasswordPairs)
        {
            SetColumnsQuantity(dgvPasswords);
            SetNormalCategoryColumn(dgvPasswords);
            SetSiteColumn(dgvPasswords);
            SetUsernameColumn(dgvPasswords);
            SetLastModifiedColumn(dgvPasswords);
            SetFullViewColumn(dgvPasswords, fullViewNormalPasswords);
            dgvPasswords.DataSource = userPasswordPairs;
            ChangeWidthWhenScrollBarIsVisible(dgvPasswords);
        }

        public void LoadSharedPasswords()
        {
            var userPasswordPairs = PasswordManager.
                CurrentUser.GetSharedUserPasswordPairs();
            LoadDataGridSharedPasswords(userPasswordPairs);
        }

        private void LoadDataGridSharedPasswords(UserPasswordPair[] userPasswordPairs)
        {
            SetColumnsQuantity(dgvSharedPasswords);
            SetSharedCategoryColumn(dgvSharedPasswords);
            SetSiteColumn(dgvSharedPasswords);
            SetUsernameColumn(dgvSharedPasswords);
            SetLastModifiedColumn(dgvSharedPasswords);
            SetFullViewColumn(dgvSharedPasswords, fullViewSharedPasswords);
            dgvSharedPasswords.DataSource = userPasswordPairs;
            ChangeWidthWhenScrollBarIsVisible(dgvSharedPasswords);
        }

        private void SetColumnsQuantity(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.ColumnCount = 4;
        }

        private void SetNormalCategoryColumn(DataGridView dgv)
        {
            dgv.Columns[0].Name = "Category";
            dgv.Columns[0].HeaderText = "Category";
            dgv.Columns[0].DataPropertyName = "Category";
            dgv.Columns[0].Width = 135;
        }

        private void SetSharedCategoryColumn(DataGridView dgv)
        {
            dgv.Columns[0].Name = "Category";
            dgv.Columns[0].HeaderText = "Category";
            dgv.Columns[0].DefaultCellStyle.NullValue = "Passwords shared with me";
            dgv.Columns[0].Width = 135;
        }

        private void SetSiteColumn(DataGridView dgv)
        {
            dgv.Columns[1].Name = "Site";
            dgv.Columns[1].HeaderText = "Site";
            dgv.Columns[1].DataPropertyName = "Site";
            dgv.Columns[1].Width = 215;
        }

        private void SetUsernameColumn(DataGridView dgv)
        {
            dgv.Columns[2].Name = "User";
            dgv.Columns[2].HeaderText = "User";
            dgv.Columns[2].DataPropertyName = "Username";
            dgv.Columns[2].Width = 215;
        }

        private void SetLastModifiedColumn(DataGridView dgv)
        {
            dgv.Columns[3].Name = "LastModified";
            dgv.Columns[3].HeaderText = "Last Modified";
            dgv.Columns[3].DataPropertyName = "LastModifiedDate";
            dgv.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgv.Columns[3].Width = 70;
        }

        private void SetFullViewColumn(DataGridView dgv, DataGridViewButtonColumn buttonColumn)
        {
            dgv.Columns.Add(buttonColumn);
            buttonColumn.HeaderText = @"";
            buttonColumn.Name = "Full view";
            buttonColumn.Text = "Full view";
            buttonColumn.Width = 61;
            buttonColumn.UseColumnTextForButtonValue = true;
        }

        private void ChangeWidthWhenScrollBarIsVisible(DataGridView dgv)
        {
            if (dgv.Controls.OfType<ScrollBar>().Last().Visible)
            {
                dgv.Width = 715;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GoBackToMainMenu();
        }

        private void GoBackToMainMenu()
        {
            PnlMainWindow.Controls.Clear();
            UserControl menu = new Menu(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(menu);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PnlMainWindow.Controls.Clear();
            UserControl addUserPasswordPairControl = new AddUserPasswordPair(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(addUserPasswordPairControl);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Delete();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Select the password to delete", "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionUserPasswordPairDoesNotExist exception)
            {
                MessageBox.Show(exception.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Delete()
        {
            UserPasswordPair selected = dgvPasswords.SelectedRows[0].DataBoundItem as UserPasswordPair;
            selected.Category.RemoveUserPasswordPair(selected);
            dgvPasswords.DataSource = PasswordManager.CurrentUser.GetUserPasswordPairs();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                LoadModifyTab();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Select the password to modify", "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadModifyTab()
        {
            UserPasswordPair selected = dgvPasswords.SelectedRows[0].DataBoundItem as UserPasswordPair;
            PnlMainWindow.Controls.Clear();
            UserControl modifyUserPasswordPairControl = new ModifyUserPasswordPair(PasswordManager, PnlMainWindow, selected);
            PnlMainWindow.Controls.Add(modifyUserPasswordPairControl);
        }

        private void btnShare_Click(object sender, EventArgs e)
        {
            try
            {
                LoadShareTab();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Select the password to Share", "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadShareTab()
        {
            UserPasswordPair selected = dgvPasswords.SelectedRows[0].DataBoundItem as UserPasswordPair;
            UserControl shareUserPasswordPairControl = new ShareUserPasswordPair(PasswordManager, PnlMainWindow, selected);
            PnlMainWindow.Controls.Clear();
            PnlMainWindow.Controls.Add(shareUserPasswordPairControl);
        }

        private void btnUnshare_Click(object sender, EventArgs e)
        {
            try
            {
                LoadUnshareTab();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Select the password to Unshare", "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionUserPasswordPairIsNotSharedWithAnyone exception)
            {
                MessageBox.Show(exception.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUnshareTab()
        {
            var selected = dgvPasswords.SelectedRows[0].DataBoundItem as UserPasswordPair;
            selected.GetUsersWithAccessArray();
            PnlMainWindow.Controls.Clear();
            UserControl unshareUserPasswordPairControl = new UnshareUserPasswordPair(PasswordManager, PnlMainWindow, selected);
            PnlMainWindow.Controls.Add(unshareUserPasswordPairControl);
        }

        private void btnPasswordsReport_Click(object sender, EventArgs e)
        {
            PnlMainWindow.Controls.Clear();
            UserControl passwordsReport = new PasswordsStrengthReportTable(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(passwordsReport);
        }

        private void dgvPasswords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                UserPasswordPair selected = dgvPasswords.Rows[e.RowIndex].DataBoundItem as UserPasswordPair;
                PopUp30Seconds fullView = new PopUp30Seconds(selected);
                fullView.Visible = true;
            }
        }

        private void dgvSharedPasswords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                UserPasswordPair selected = dgvSharedPasswords.Rows[e.RowIndex].DataBoundItem as UserPasswordPair;
                PopUp30Seconds fullView = new PopUp30Seconds(selected, "Passwords shared with me");
                fullView.Visible = true;
            }
        }

        private void btnSharedPasswords_Click(object sender, EventArgs e)
        {
            PnlMainWindow.Controls.Clear();
            UserControl sharedPasswords = new SharedPasswordsList(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(sharedPasswords);
        }
    }
}
