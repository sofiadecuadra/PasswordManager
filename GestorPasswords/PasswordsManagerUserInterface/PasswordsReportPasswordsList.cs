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
    public partial class PasswordsReportPasswordsList : UserControl
    {
        public PasswordManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        private readonly DataGridViewButtonColumn fullViewPasswords;

        public PasswordsReportPasswordsList(PasswordManager passwordManager, UserPasswordPair[] userPasswordPairs, Panel panel, string color)
        {
            InitializeComponent();
            PasswordManager = passwordManager;
            PnlMainWindow = panel;
            fullViewPasswords = new DataGridViewButtonColumn();
            LoadTableData(userPasswordPairs);
            lblPasswordsOfColor.Text = color + " passwords:";
        }

        private void LoadTableData(UserPasswordPair[] userPasswordPairs)
        {
            dgvPasswordsOfColor.AutoGenerateColumns = false;
            dgvPasswordsOfColor.ColumnCount = 4;
            dgvPasswordsOfColor.Columns[0].Name = "Category";
            dgvPasswordsOfColor.Columns[0].HeaderText = "Category";
            dgvPasswordsOfColor.Columns[0].DataPropertyName = "CategoryName";
            dgvPasswordsOfColor.Columns[0].Width = 135;

            dgvPasswordsOfColor.Columns[1].Name = "Site";
            dgvPasswordsOfColor.Columns[1].HeaderText = "Site";
            dgvPasswordsOfColor.Columns[1].DataPropertyName = "Site";
            dgvPasswordsOfColor.Columns[1].Width = 215;

            dgvPasswordsOfColor.Columns[2].Name = "User";
            dgvPasswordsOfColor.Columns[2].HeaderText = "User";
            dgvPasswordsOfColor.Columns[2].DataPropertyName = "Username";
            dgvPasswordsOfColor.Columns[2].Width = 215;

            dgvPasswordsOfColor.Columns[3].Name = "LastModified";
            dgvPasswordsOfColor.Columns[3].HeaderText = "Last Modified";
            dgvPasswordsOfColor.Columns[3].DataPropertyName = "LastModifiedShortFormat";
            dgvPasswordsOfColor.Columns[3].Width = 70;

            dgvPasswordsOfColor.Columns.Add(fullViewPasswords);
            fullViewPasswords.HeaderText = @"";
            fullViewPasswords.Name = "Full view";
            fullViewPasswords.Text = "Full view";
            fullViewPasswords.Width = 61;
            fullViewPasswords.UseColumnTextForButtonValue = true;

            dgvPasswordsOfColor.DataSource = userPasswordPairs;
        }

        private void dgvPasswordsOfColor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                UserPasswordPair selected = dgvPasswordsOfColor.Rows[e.RowIndex].DataBoundItem as UserPasswordPair;
                PopUp30Seconds fullView = new PopUp30Seconds(selected);
                fullView.Visible = true;
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                UserPasswordPair selected = dgvPasswordsOfColor.SelectedRows[0].DataBoundItem as UserPasswordPair;
                PnlMainWindow.Controls.Clear();
                UserControl modifyUserPasswordPairControl = new ModifyUserPasswordPair(PasswordManager, PnlMainWindow, selected);
                PnlMainWindow.Controls.Add(modifyUserPasswordPairControl);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Select the password to modify", "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PnlMainWindow.Controls.Clear();
            UserControl table = new PasswordsStrengthReportTable(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(table);
        }
    }
}
