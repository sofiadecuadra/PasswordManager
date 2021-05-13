using DataManagerDomain;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PasswordsManagerUserInterface
{
    public partial class DataBreachesResult : UserControl
    {
        public DataManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        public IDataBreachesFormatter DataBreaches { get; private set; }
        private readonly DataGridViewButtonColumn modifyExposedPassword;
        public DataBreachesResult(DataManager aPasswordManager, Panel aPanel, IDataBreachesFormatter dataBreaches)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = aPanel;
            DataBreaches = dataBreaches;
            modifyExposedPassword = new DataGridViewButtonColumn();
            LoadExposedPasswordsAndCreditCards();
        }

        private void LoadExposedPasswordsAndCreditCards()
        {
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
            ClearControls();
            UserControl checkDataBreaches = new CheckDataBreaches(PasswordManager, PnlMainWindow);
            AddUserControl(checkDataBreaches);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            ClearControls();
            UserControl menu = new Menu(PasswordManager, PnlMainWindow);
            AddUserControl(menu);
        }

        private void dgvExposedPasswords_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                UserPasswordPair selected = SelectedUserPasswordPair(e.RowIndex);
                ClearControls();
                UserControl modifyUserPasswordPairControl = new ModifyUserPasswordPairExposedInDataBreaches(PasswordManager, PnlMainWindow, selected, DataBreaches);
                AddUserControl(modifyUserPasswordPairControl);
            }
        }

        private UserPasswordPair SelectedUserPasswordPair(int rowIndex)
        {
            return dgvExposedPasswords.Rows[rowIndex].DataBoundItem as UserPasswordPair;
        }

        private void ClearControls()
        {
            PnlMainWindow.Controls.Clear();
        }

        private void AddUserControl(UserControl aUserControl)
        {
            PnlMainWindow.Controls.Add(aUserControl);
        }
    }
}
