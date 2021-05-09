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
    public partial class PopUp30Seconds : Form
    {
        public PopUp30Seconds(UserPasswordPair aUserPasswordPair)
        {
            InitializeComponent();
            LoadUserPasswordPairData(aUserPasswordPair);
        }

        private void LoadUserPasswordPairData(UserPasswordPair aUserPasswordPair)
        {
            dgvData.AutoGenerateColumns = false;
            dgvData.ColumnCount = 5;
            dgvData.Columns[0].Name = "Category";
            dgvData.Columns[0].Width = 150;

            dgvData.Columns[1].Name = "Site";
            dgvData.Columns[1].Width = 218;

            dgvData.Columns[2].Name = "User";
            dgvData.Columns[2].Width = 218;

            dgvData.Columns[3].Name = "Password";
            dgvData.Columns[3].Width = 290;

            dgvData.Columns[4].Name = "LastModified";
            dgvData.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvData.Columns[4].Width = 70;
            dgvData.BackgroundColor = SystemColors.Control;

            dgvData.Rows.Add(aUserPasswordPair.Category, aUserPasswordPair.Site, aUserPasswordPair.Username, aUserPasswordPair.Password, aUserPasswordPair.LastModifiedDate);
            txtNotes.Text = aUserPasswordPair.Notes;
        }

        public PopUp30Seconds(CreditCard aCreditCard)
        {
            InitializeComponent();
            LoadCreditCardData(aCreditCard);
        }

        private void LoadCreditCardData(CreditCard aCreditCard)
        {
            dgvData.AutoGenerateColumns = false;
            dgvData.ColumnCount = 6;
            dgvData.Columns[0].Name = "Category";
            dgvData.Columns[0].Width = 135;

            dgvData.Columns[1].Name = "Name";
            dgvData.Columns[1].Width = 210;

            dgvData.Columns[2].Name = "Type";
            dgvData.Columns[2].Width = 210;

            dgvData.Columns[3].Name = "Number";
            dgvData.Columns[3].Width = 290;

            dgvData.Columns[4].Name = "Code";
            dgvData.Columns[4].Width = 30;

            dgvData.Columns[5].Name = "ExpirationDate";
            dgvData.Columns[5].DefaultCellStyle.Format = "MM/yyyy";
            dgvData.Columns[5].Width = 70;

            dgvData.BackgroundColor = SystemColors.Control;

            dgvData.Rows.Add(aCreditCard.Category, aCreditCard.Name, aCreditCard.Type, aCreditCard.Number, aCreditCard.Code, aCreditCard.ExpirationDate);
            txtNotes.Text = aCreditCard.Notes;
        }

        private void PopUp30Seconds_Load(object sender, EventArgs e)
        {
            timer.Interval = 3000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}