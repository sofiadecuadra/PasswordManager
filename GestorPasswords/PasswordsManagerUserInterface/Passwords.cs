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
        public Panel pnlMainWindow { get; private set; }
        private readonly DataGridViewButtonColumn fullView;
        public Passwords(PasswordManager aPasswordManager, Panel panel)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            pnlMainWindow = panel;
            fullView = new DataGridViewButtonColumn();
            LoadNormalPasswords();
            LoadSharedPasswords();
        }

        private void LoadDataGridViewData(UserPasswordPair[] userPasswordPairs, DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.ColumnCount = 4;
            dgv.Columns[0].Name = "Category";
            dgv.Columns[0].HeaderText = "Category";
            if (dgv == dgvPasswords)
            {
                dgv.Columns[0].DataPropertyName = "CategoryName";
            }
            else
            {
                dgv.Columns[0].DefaultCellStyle.NullValue = "Shared Passwords";
            }
            dgv.Columns[0].Width = 135;

            dgv.Columns[1].Name = "Site";
            dgv.Columns[1].HeaderText = "Site";
            dgv.Columns[1].DataPropertyName = "Site";
            dgv.Columns[1].Width = 215;

            dgv.Columns[2].Name = "User";
            dgv.Columns[2].HeaderText = "User";
            dgv.Columns[2].DataPropertyName = "Username";
            dgv.Columns[2].Width = 215;

            dgv.Columns[3].Name = "LastModified";
            dgv.Columns[3].HeaderText = "Last Modified";
            dgv.Columns[3].DataPropertyName = "LastModifiedShortFormat";
            dgv.Columns[3].Width = 70;

            dgv.Columns.Add(fullView);
            fullView.HeaderText = @"";
            fullView.Name = "Full view";
            fullView.Text = "Full view";
            fullView.Width = 61;
            fullView.UseColumnTextForButtonValue = true;

            dgv.DataSource = userPasswordPairs;
        }

        public void LoadNormalPasswords()
        {
            var userPasswordPairs = PasswordManager.
                CurrentUser.GetUserPasswordPairs();
            LoadDataGridViewData(userPasswordPairs, dgvPasswords);
        }

        public void LoadSharedPasswords()
        {
            var userPasswordPairs = PasswordManager.
                CurrentUser.GetSharedUserPasswordPairs();
            LoadDataGridViewData(userPasswordPairs, dgvSharedPasswords);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GoBackToMainMenu();
        }

        private void GoBackToMainMenu()
        {
            pnlMainWindow.Controls.Clear();
            UserControl menu = new Menu(PasswordManager, pnlMainWindow);
            pnlMainWindow.Controls.Add(menu);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            pnlMainWindow.Controls.Clear();
            UserControl addUserPasswordPairControl = new AddUserPasswordPair(PasswordManager, pnlMainWindow);
            pnlMainWindow.Controls.Add(addUserPasswordPairControl);
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
                pnlMainWindow.Controls.Clear();
                UserControl modifyUserPasswordPairControl = new ModifyUserPasswordPair(PasswordManager, pnlMainWindow, selected);
                pnlMainWindow.Controls.Add(modifyUserPasswordPairControl);
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
                pnlMainWindow.Controls.Clear();
                UserControl shareUserPasswordPairControl = new ShareUserPasswordPair(PasswordManager, pnlMainWindow, selected);
                pnlMainWindow.Controls.Add(shareUserPasswordPairControl);
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
                pnlMainWindow.Controls.Clear();
                UserControl unshareUserPasswordPairControl = new UnshareUserPasswordPair(PasswordManager, pnlMainWindow, selected);
                pnlMainWindow.Controls.Add(unshareUserPasswordPairControl);
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
    }
}
