﻿using System;
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
            LoadDataGridViewData();
        }

        private void LoadDataGridViewData()
        {
            var userPasswordPairs = PasswordManager.
                CurrentUser.GetUserPasswordPairs();

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

            dgvPasswords.Columns.Add(fullView);
            fullView.HeaderText = @"";
            fullView.Name = "Full view";
            fullView.Text = "Full view";
            fullView.Width = 61;
            fullView.UseColumnTextForButtonValue = true;

            dgvPasswords.DataSource = userPasswordPairs;
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
    }
}
