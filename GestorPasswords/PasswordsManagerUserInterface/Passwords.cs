using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestorPasswordsDominio;

namespace PasswordsManagerUserInterface
{

    public partial class Passwords : UserControl
    {
        public PasswordManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        private readonly DataGridViewButtonColumn fullViewNormalPasswords;
        private readonly DataGridViewButtonColumn fullViewSharedPasswords;

        public Passwords(PasswordManager aPasswordManager, Panel panel)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = panel;
            fullViewNormalPasswords = new DataGridViewButtonColumn();
            fullViewSharedPasswords = new DataGridViewButtonColumn();
            LoadNormalPasswords();
            LoadSharedPasswords();
        }

        private void LoadDataGridSharedPasswords(UserPasswordPair[] userPasswordPairs)
        {
            dgvSharedPasswords.AutoGenerateColumns = false;
            dgvSharedPasswords.ColumnCount = 4;
            dgvSharedPasswords.Columns[0].Name = "Category";
            dgvSharedPasswords.Columns[0].HeaderText = "Category";
            dgvSharedPasswords.Columns[0].DefaultCellStyle.NullValue = "Shared Passwords";
            dgvSharedPasswords.Columns[0].Width = 135;

            dgvSharedPasswords.Columns[1].Name = "Site";
            dgvSharedPasswords.Columns[1].HeaderText = "Site";
            dgvSharedPasswords.Columns[1].DataPropertyName = "Site";
            dgvSharedPasswords.Columns[1].Width = 215;

            dgvSharedPasswords.Columns[2].Name = "User";
            dgvSharedPasswords.Columns[2].HeaderText = "User";
            dgvSharedPasswords.Columns[2].DataPropertyName = "Username";
            dgvSharedPasswords.Columns[2].Width = 215;

            dgvSharedPasswords.Columns[3].Name = "LastModified";
            dgvSharedPasswords.Columns[3].HeaderText = "Last Modified";
            dgvSharedPasswords.Columns[3].DataPropertyName = "LastModifiedShortFormat";
            dgvSharedPasswords.Columns[3].Width = 70;

            dgvSharedPasswords.Columns.Add(fullViewNormalPasswords);
            fullViewNormalPasswords.HeaderText = @"";
            fullViewNormalPasswords.Name = "Full view";
            fullViewNormalPasswords.Text = "Full view";
            fullViewNormalPasswords.Width = 61;
            fullViewNormalPasswords.UseColumnTextForButtonValue = true;

            dgvSharedPasswords.DataSource = userPasswordPairs;
        }

        private void LoadDataGridNormalPasswords(UserPasswordPair[] userPasswordPairs)
        {
            dgvPasswords.AutoGenerateColumns = false;
            dgvPasswords.ColumnCount = 4;
            dgvPasswords.Columns[0].Name = "Category";
            dgvPasswords.Columns[0].HeaderText = "Category";
            dgvPasswords.Columns[0].DataPropertyName = "CategoryName";
            dgvPasswords.Columns[0].Width = 135;

            dgvPasswords.Columns[1].Name = "Site";
            dgvPasswords.Columns[1].HeaderText = "Site";
            dgvPasswords.Columns[1].DataPropertyName = "Site";
            dgvPasswords.Columns[1].Width = 215;

            dgvPasswords.Columns[2].Name = "User";
            dgvPasswords.Columns[2].HeaderText = "User";
            dgvPasswords.Columns[2].DataPropertyName = "Username";
            dgvPasswords.Columns[2].Width = 215;

            dgvPasswords.Columns[3].Name = "LastModified";
            dgvPasswords.Columns[3].HeaderText = "Last Modified";
            dgvPasswords.Columns[3].DataPropertyName = "LastModifiedShortFormat";
            dgvPasswords.Columns[3].Width = 70;

            dgvPasswords.Columns.Add(fullViewSharedPasswords);
            fullViewSharedPasswords.HeaderText = @"";
            fullViewSharedPasswords.Name = "Full view";
            fullViewSharedPasswords.Text = "Full view";
            fullViewSharedPasswords.Width = 61;
            fullViewSharedPasswords.UseColumnTextForButtonValue = true;

            dgvPasswords.DataSource = userPasswordPairs;
        }

        public void LoadNormalPasswords()
        {
            var userPasswordPairs = PasswordManager.
                CurrentUser.GetUserPasswordPairs();
            LoadDataGridNormalPasswords(userPasswordPairs);
            if (dgvPasswords.Controls.OfType<ScrollBar>().Last().Visible)
            {
                dgvPasswords.Width = 715;
            }
        }

        public void LoadSharedPasswords()
        {
            var userPasswordPairs = PasswordManager.
                CurrentUser.GetSharedUserPasswordPairs();
            LoadDataGridSharedPasswords(userPasswordPairs);
            if (dgvSharedPasswords.Controls.OfType<ScrollBar>().Last().Visible)
            {
                dgvSharedPasswords.Width = 715;
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
                UserPasswordPair selected = dgvPasswords.SelectedRows[0].DataBoundItem as UserPasswordPair;
                selected.Category.RemoveUserPasswordPair(selected);
                dgvPasswords.DataSource = PasswordManager.CurrentUser.GetUserPasswordPairs();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Select the password to delete", "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                UserPasswordPair selected = dgvPasswords.SelectedRows[0].DataBoundItem as UserPasswordPair;
                PnlMainWindow.Controls.Clear();
                UserControl modifyUserPasswordPairControl = new ModifyUserPasswordPair(PasswordManager, PnlMainWindow, selected);
                PnlMainWindow.Controls.Add(modifyUserPasswordPairControl);
                dgvPasswords.DataSource = PasswordManager.CurrentUser.GetUserPasswordPairs();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Select the password to modify", "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        
        private void btnShare_Click(object sender, EventArgs e)
        {
            try
            {
                UserPasswordPair selected = dgvPasswords.SelectedRows[0].DataBoundItem as UserPasswordPair;
                UserControl shareUserPasswordPairControl = new ShareUserPasswordPair(PasswordManager, PnlMainWindow, selected);
                PnlMainWindow.Controls.Clear();
                PnlMainWindow.Controls.Add(shareUserPasswordPairControl);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Select the password to Share", "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUnshare_Click(object sender, EventArgs e)
        {
            try
            {
                var selected = dgvPasswords.SelectedRows[0].DataBoundItem as UserPasswordPair;
                selected.GetUsersWithAccessArray();
                PnlMainWindow.Controls.Clear();
                UserControl unshareUserPasswordPairControl = new UnshareUserPasswordPair(PasswordManager, PnlMainWindow, selected);
                PnlMainWindow.Controls.Add(unshareUserPasswordPairControl);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Select the password to Unshare", "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionUserPasswordPairIsNotSharedWithAnyone)
            {
                MessageBox.Show("This password has not been shared with anyone", "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnPasswordsReport_Click(object sender, EventArgs e)
        {
            PnlMainWindow.Controls.Clear();
            UserControl passwordsReport = new PasswordsStrengthTable(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(passwordsReport);
        }
    }
}
