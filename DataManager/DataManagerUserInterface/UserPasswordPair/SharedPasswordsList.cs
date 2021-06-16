using DataManagerDomain;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PasswordsManagerUserInterface
{
    public partial class SharedPasswordsList : UserControl
    {
        public DataManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        private readonly DataGridViewButtonColumn fullViewSharedPasswords;

        public SharedPasswordsList(DataManager aPasswordManager, Panel panel)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = panel;
            fullViewSharedPasswords = new DataGridViewButtonColumn();
            LoadSharedPasswords();
        }

        private void LoadSharedPasswords()
        {
            var userPasswordPairs = PasswordManager.
                CurrentUser.GetUserPasswordPairsSharedWithOtherUsers();
            LoadDataGridSharedPasswords(userPasswordPairs);
        }

        private void LoadDataGridSharedPasswords(UserPasswordPair[] userPasswordPairs)
        {
            SetColumnsQuantity();
            SetCategoryColumn();
            SetSiteColumn();
            SetUsernameColumn();
            SetLastModifiedColumn();
            SetFullViewColumn();
            dgvSharedPasswords.DataSource = userPasswordPairs;
            ChangeWidthWhenScrollBarIsVisible(dgvSharedPasswords);
        }

        private void SetColumnsQuantity()
        {
            dgvSharedPasswords.AutoGenerateColumns = false;
            dgvSharedPasswords.ColumnCount = 4;
        }

        private void SetCategoryColumn()
        {
            dgvSharedPasswords.Columns[0].Name = "Category";
            dgvSharedPasswords.Columns[0].HeaderText = "Category";
            dgvSharedPasswords.Columns[0].DataPropertyName = "Category";
            dgvSharedPasswords.Columns[0].Width = 135;
        }

        private void SetSiteColumn()
        {
            dgvSharedPasswords.Columns[1].Name = "Site";
            dgvSharedPasswords.Columns[1].HeaderText = "Site";
            dgvSharedPasswords.Columns[1].DataPropertyName = "Site";
            dgvSharedPasswords.Columns[1].Width = 215;
        }

        private void SetUsernameColumn()
        {
            dgvSharedPasswords.Columns[2].Name = "User";
            dgvSharedPasswords.Columns[2].HeaderText = "User";
            dgvSharedPasswords.Columns[2].DataPropertyName = "Username";
            dgvSharedPasswords.Columns[2].Width = 215;
        }

        private void SetLastModifiedColumn()
        {
            dgvSharedPasswords.Columns[3].Name = "LastModified";
            dgvSharedPasswords.Columns[3].HeaderText = "Last Modified";
            dgvSharedPasswords.Columns[3].DataPropertyName = "LastModifiedDate";
            dgvSharedPasswords.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvSharedPasswords.Columns[3].Width = 70;
        }

        private void SetFullViewColumn()
        {
            dgvSharedPasswords.Columns.Add(fullViewSharedPasswords);
            fullViewSharedPasswords.HeaderText = @"";
            fullViewSharedPasswords.Name = "Full view";
            fullViewSharedPasswords.Text = "Full view";
            fullViewSharedPasswords.Width = 61;
            fullViewSharedPasswords.UseColumnTextForButtonValue = true;
        }

        private void ChangeWidthWhenScrollBarIsVisible(DataGridView dgv)
        {
            if (dgv.Controls.OfType<ScrollBar>().First().Visible)
            {
                dgv.Width = 740;
            }
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
            UserPasswordPair selected = dgvSharedPasswords.SelectedRows[0].DataBoundItem as UserPasswordPair;
            UserControl shareUserPasswordPairControl = new ShareUserPasswordPair(PasswordManager, PnlMainWindow, selected);
            PnlMainWindow.Controls.Clear();
            PnlMainWindow.Controls.Add(shareUserPasswordPairControl);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PnlMainWindow.Controls.Clear();
            UserControl passwords = new Passwords(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(passwords);
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
            var selected = dgvSharedPasswords.SelectedRows[0].DataBoundItem as UserPasswordPair;
            selected.GetUsersWithAccessArray();
            PnlMainWindow.Controls.Clear();
            UserControl unshareUserPasswordPairControl = new UnshareUserPasswordPair(PasswordManager, PnlMainWindow, selected);
            PnlMainWindow.Controls.Add(unshareUserPasswordPairControl);
        }

        private void dgvSharedPasswords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                UserPasswordPair selected = dgvSharedPasswords.Rows[e.RowIndex].DataBoundItem as UserPasswordPair;
                PopUp30Seconds fullView = new PopUp30Seconds(selected);
                fullView.Visible = true;
            }
        }
    }
}
