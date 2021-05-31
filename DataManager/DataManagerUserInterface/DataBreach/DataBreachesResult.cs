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
        public DataBreach DataBreach { get; private set; }
        private readonly DataGridViewButtonColumn modifyExposedPassword;

        public DataBreachesResult(DataManager aPasswordManager, Panel aPanel, IDataBreachesFormatter dataBreaches)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = aPanel;
            DataBreaches = dataBreaches;
            modifyExposedPassword = new DataGridViewButtonColumn();
            LoadNewDataBreach();
        }

        public DataBreachesResult(DataManager aPasswordManager, Panel aPanel, DataBreach dataBreach)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = aPanel;
            DataBreach = dataBreach;
            modifyExposedPassword = new DataGridViewButtonColumn();
            ReloadDataBreach();
        }

        private void LoadNewDataBreach()
        {
            DataBreach = PasswordManager.CurrentUser.CheckDataBreaches(DataBreaches);
            LoadExposedPasswords(DataBreach.LeakedUserPasswordPairs);
            LoadExposedCreditCards(DataBreach.LeakedCreditCards);
        }

        private void ReloadDataBreach()
        {
            List<UserPasswordPair> NotModifiedExposedPasswords = PasswordManager.CurrentUser.GetModifiedAndNotModifiedLeakedPasswords(DataBreach).Item1;
            LoadExposedPasswords(NotModifiedExposedPasswords);
            LoadExposedCreditCards(DataBreach.LeakedCreditCards);
        }

        private void LoadExposedPasswords(List<UserPasswordPair> exposedPasswords)
        {
            SetPasswordsColumnQuantity();
            SetPasswordsCategoryColumn();
            SetPasswordsSiteColumn();
            SetPasswordsUsernameColumn();
            SetPasswordsLastModifiedColumn();
            SetPasswordsModifyColumn();
            dgvExposedPasswords.DataSource = exposedPasswords;
        }

        private void SetPasswordsModifyColumn()
        {
            dgvExposedPasswords.Columns.Add(modifyExposedPassword);
            modifyExposedPassword.HeaderText = @"";
            modifyExposedPassword.Name = "Modify";
            modifyExposedPassword.Text = "Modify";
            modifyExposedPassword.Width = 61;
            modifyExposedPassword.UseColumnTextForButtonValue = true;
        }

        private void SetPasswordsLastModifiedColumn()
        {
            dgvExposedPasswords.Columns[3].Name = "LastModified";
            dgvExposedPasswords.Columns[3].HeaderText = "Last Modified";
            dgvExposedPasswords.Columns[3].DataPropertyName = "LastModifiedDate";
            dgvExposedPasswords.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvExposedPasswords.Columns[3].Width = 70;
        }

        private void SetPasswordsUsernameColumn()
        {
            dgvExposedPasswords.Columns[2].Name = "User";
            dgvExposedPasswords.Columns[2].HeaderText = "User";
            dgvExposedPasswords.Columns[2].DataPropertyName = "Username";
            dgvExposedPasswords.Columns[2].Width = 215;
        }

        private void SetPasswordsSiteColumn()
        {
            dgvExposedPasswords.Columns[1].Name = "Site";
            dgvExposedPasswords.Columns[1].HeaderText = "Site";
            dgvExposedPasswords.Columns[1].DataPropertyName = "Site";
            dgvExposedPasswords.Columns[1].Width = 215;
        }

        private void SetPasswordsCategoryColumn()
        {
            dgvExposedPasswords.Columns[0].Name = "Category";
            dgvExposedPasswords.Columns[0].HeaderText = "Category";
            dgvExposedPasswords.Columns[0].DataPropertyName = "Category";
            dgvExposedPasswords.Columns[0].Width = 135;
        }

        private void SetPasswordsColumnQuantity()
        {
            dgvExposedPasswords.AutoGenerateColumns = false;
            dgvExposedPasswords.ColumnCount = 4;
        }

        private void LoadExposedCreditCards(List<CreditCard> exposedCreditCards)
        {
            SetCreditCardColumnsQuantity();
            SetCreditCardCategoryColumn();
            SetCreditCardNameColumn();
            SetCreditCardTypeColumn();
            SetCreditCardNumberColumn();
            dgvExposedCreditCards.DataSource = exposedCreditCards;
        }

        private void SetCreditCardColumnsQuantity()
        {
            dgvExposedCreditCards.AutoGenerateColumns = false;
            dgvExposedCreditCards.ColumnCount = 4;
        }

        private void SetCreditCardCategoryColumn()
        {
            dgvExposedCreditCards.Columns[0].Name = "Category";
            dgvExposedCreditCards.Columns[0].HeaderText = "Category";
            dgvExposedCreditCards.Columns[0].DataPropertyName = "Category";
            dgvExposedCreditCards.Columns[0].Width = 135;
        }

        private void SetCreditCardNameColumn()
        {
            dgvExposedCreditCards.Columns[1].Name = "Name";
            dgvExposedCreditCards.Columns[1].HeaderText = "Name";
            dgvExposedCreditCards.Columns[1].DataPropertyName = "Name";
            dgvExposedCreditCards.Columns[1].Width = 185;
        }

        private void SetCreditCardTypeColumn()
        {
            dgvExposedCreditCards.Columns[2].Name = "Type";
            dgvExposedCreditCards.Columns[2].HeaderText = "Type";
            dgvExposedCreditCards.Columns[2].DataPropertyName = "Type";
            dgvExposedCreditCards.Columns[2].Width = 165;
        }

        private void SetCreditCardNumberColumn()
        {
            dgvExposedCreditCards.Columns[3].Name = "Number";
            dgvExposedCreditCards.Columns[3].HeaderText = "Number";
            dgvExposedCreditCards.Columns[3].DataPropertyName = "NumberFormatted";
            dgvExposedCreditCards.Columns[3].Width = 211;
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
                UserControl modifyUserPasswordPairControl = new ModifyUserPasswordPairExposedInDataBreaches(PasswordManager, PnlMainWindow, selected, DataBreach);
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

        private void btnMenu_Click_1(object sender, EventArgs e)
        {
            ClearControls();
            UserControl menu = new Menu(PasswordManager, PnlMainWindow);
            AddUserControl(menu);
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            ClearControls();
            UserControl checkDataBreaches = new CheckDataBreaches(PasswordManager, PnlMainWindow);
            AddUserControl(checkDataBreaches);
        }
    }
}
