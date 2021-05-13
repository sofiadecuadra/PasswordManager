using GestorPasswordsDominio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PasswordsManagerUserInterface
{
    public partial class DataBreachesResult : UserControl
    {
        public PasswordManager PasswordManager { get; private set; }
        public Panel pnlMainWindow { get; private set; }
        public IDataBreachesFormatter DataBreaches { get; private set; }
        private readonly DataGridViewButtonColumn modifyExposedPassword;
        public DataBreachesResult(PasswordManager aPasswordManager, Panel panel, IDataBreachesFormatter dataBreaches)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            pnlMainWindow = panel;
            DataBreaches = dataBreaches;
            modifyExposedPassword = new DataGridViewButtonColumn();
            (List<UserPasswordPair>, List<CreditCard>) ExposedPasswordsAndCreditCards = PasswordManager.CurrentUser.CheckDataBreaches(DataBreaches);
            LoadExposedPasswords(ExposedPasswordsAndCreditCards.Item1);
            LoadExposedCreditCards(ExposedPasswordsAndCreditCards.Item2);
        }

        private void LoadExposedPasswords(List<UserPasswordPair> exposedPasswords)
        {
            dgvExposedPasswords.AutoGenerateColumns = false;
            dgvExposedPasswords.ColumnCount = 4;

            dgvExposedPasswords.Columns[0].Name = "Category";
            dgvExposedPasswords.Columns[0].HeaderText = "Category";
            dgvExposedPasswords.Columns[0].DataPropertyName = "Category";
            dgvExposedPasswords.Columns[0].Width = 135;

            dgvExposedPasswords.Columns[1].Name = "Site";
            dgvExposedPasswords.Columns[1].HeaderText = "Site";
            dgvExposedPasswords.Columns[1].DataPropertyName = "Site";
            dgvExposedPasswords.Columns[1].Width = 215;

            dgvExposedPasswords.Columns[2].Name = "User";
            dgvExposedPasswords.Columns[2].HeaderText = "User";
            dgvExposedPasswords.Columns[2].DataPropertyName = "Username";
            dgvExposedPasswords.Columns[2].Width = 215;

            dgvExposedPasswords.Columns[3].Name = "LastModified";
            dgvExposedPasswords.Columns[3].HeaderText = "Last Modified";
            dgvExposedPasswords.Columns[3].DataPropertyName = "LastModifiedDate";
            dgvExposedPasswords.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvExposedPasswords.Columns[3].Width = 70;

            dgvExposedPasswords.Columns.Add(modifyExposedPassword);
            modifyExposedPassword.HeaderText = @"";
            modifyExposedPassword.Name = "Modify";
            modifyExposedPassword.Text = "Modify";
            modifyExposedPassword.Width = 61;
            modifyExposedPassword.UseColumnTextForButtonValue = true;

            dgvExposedPasswords.DataSource = exposedPasswords;
        }

        private void LoadExposedCreditCards(List<CreditCard> exposedCreditCards)
        {
            dgvExposedCreditCards.AutoGenerateColumns = false;
            dgvExposedCreditCards.ColumnCount = 4;

            dgvExposedCreditCards.Columns[0].Name = "Category";
            dgvExposedCreditCards.Columns[0].HeaderText = "Category";
            dgvExposedCreditCards.Columns[0].DataPropertyName = "Category";
            dgvExposedCreditCards.Columns[0].Width = 135;

            dgvExposedCreditCards.Columns[1].Name = "Name";
            dgvExposedCreditCards.Columns[1].HeaderText = "Name";
            dgvExposedCreditCards.Columns[1].DataPropertyName = "Name";
            dgvExposedCreditCards.Columns[1].Width = 185;

            dgvExposedCreditCards.Columns[2].Name = "Type";
            dgvExposedCreditCards.Columns[2].HeaderText = "Type";
            dgvExposedCreditCards.Columns[2].DataPropertyName = "Type";
            dgvExposedCreditCards.Columns[2].Width = 165;

            dgvExposedCreditCards.Columns[3].Name = "Number";
            dgvExposedCreditCards.Columns[3].HeaderText = "Number";
            dgvExposedCreditCards.Columns[3].DataPropertyName = "NumberFormatted";
            dgvExposedCreditCards.Columns[3].Width = 211;

            dgvExposedCreditCards.DataSource = exposedCreditCards;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            pnlMainWindow.Controls.Clear();
            UserControl checkDataBreaches = new CheckDataBreaches(PasswordManager, pnlMainWindow);
            pnlMainWindow.Controls.Add(checkDataBreaches);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            pnlMainWindow.Controls.Clear();
            UserControl menu = new Menu(PasswordManager, pnlMainWindow);
            pnlMainWindow.Controls.Add(menu);
        }

        private void dgvExposedPasswords_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                UserPasswordPair selected = dgvExposedPasswords.Rows[e.RowIndex].DataBoundItem as UserPasswordPair;
                UserControl modifyUserPasswordPairControl = new ModifyUserPasswordPairExposedInDataBreaches(PasswordManager, pnlMainWindow, selected, DataBreaches);
                pnlMainWindow.Controls.Clear();
                pnlMainWindow.Controls.Add(modifyUserPasswordPairControl);
            }
        }
    }
}
