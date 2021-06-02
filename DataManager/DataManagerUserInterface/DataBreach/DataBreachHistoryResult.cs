using DataManagerDomain;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PasswordsManagerUserInterface
{
    public partial class DataBreachHistoryResult : UserControl
    {
        public DataManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        public DataBreach DataBreachToView { get; private set; }
        private readonly DataGridViewButtonColumn modifyExposedPassword;
        public DataBreachHistoryResult(DataManager aPasswordManager, Panel aPanel, DataBreach dataBreach)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = aPanel;
            DataBreachToView = dataBreach;
            modifyExposedPassword = new DataGridViewButtonColumn();
            LoadExposedPasswordsAndCreditCards();
        }

         private void LoadNotModifiedExposedPasswords(List<UserPasswordPair> exposedPasswords)
        {
            SetPasswordsColumnQuantity(dgvNotModifiedPasswords, 4);
            SetPasswordsCategoryColumn(dgvNotModifiedPasswords);
            SetPasswordsSiteColumn(dgvNotModifiedPasswords);
            SetPasswordsUsernameColumn(dgvNotModifiedPasswords);
            SetPasswordsLastModifiedColumn(dgvNotModifiedPasswords, 70);
            SetPasswordsModifyColumn();
            dgvNotModifiedPasswords.DataSource = exposedPasswords;
        }
        private void LoadModifiedExposedPasswords(List<UserPasswordPair> exposedPasswords)
        {
            SetPasswordsColumnQuantity(dgvModifiedPasswords, 4);
            SetPasswordsCategoryColumn(dgvModifiedPasswords);
            SetPasswordsSiteColumn(dgvModifiedPasswords);
            SetPasswordsUsernameColumn(dgvModifiedPasswords);
            SetPasswordsLastModifiedColumn(dgvModifiedPasswords, 131);
            dgvModifiedPasswords.DataSource = exposedPasswords;
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

        private void SetPasswordsModifyColumn()
        {
            dgvNotModifiedPasswords.Columns.Add(modifyExposedPassword);
            modifyExposedPassword.HeaderText = @"";
            modifyExposedPassword.Name = "Modify";
            modifyExposedPassword.Text = "Modify";
            modifyExposedPassword.Width = 61;
            modifyExposedPassword.UseColumnTextForButtonValue = true;
        }

        private void SetPasswordsLastModifiedColumn(DataGridView aDataGriedView, int width)
        {
            aDataGriedView.Columns[3].Name = "LastModified";
            aDataGriedView.Columns[3].HeaderText = "Last Modified";
            aDataGriedView.Columns[3].DataPropertyName = "LastModifiedDate";
            aDataGriedView.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            aDataGriedView.Columns[3].Width = width;
        }

        private void SetPasswordsUsernameColumn(DataGridView aDataGriedView)
        {
            aDataGriedView.Columns[2].Name = "User";
            aDataGriedView.Columns[2].HeaderText = "User";
            aDataGriedView.Columns[2].DataPropertyName = "Username";
            aDataGriedView.Columns[2].Width = 215;
        }

        private void SetPasswordsSiteColumn(DataGridView aDataGriedView)
        {
            aDataGriedView.Columns[1].Name = "Site";
            aDataGriedView.Columns[1].HeaderText = "Site";
            aDataGriedView.Columns[1].DataPropertyName = "Site";
            aDataGriedView.Columns[1].Width = 215;
        }

        private void SetPasswordsCategoryColumn(DataGridView aDataGriedView)
        {
            aDataGriedView.Columns[0].Name = "Category";
            aDataGriedView.Columns[0].HeaderText = "Category";
            aDataGriedView.Columns[0].DataPropertyName = "Category";
            aDataGriedView.Columns[0].Width = 135;
        }

        private void SetPasswordsColumnQuantity(DataGridView aDataGriedView, int quantity)
        {
            aDataGriedView.AutoGenerateColumns = false;
            aDataGriedView.ColumnCount = quantity;
        }

        private void LoadExposedPasswordsAndCreditCards()
        {
            (List<UserPasswordPair>, List<UserPasswordPair>) getModifiedAndNotModifiedPasswords = (PasswordManager.CurrentUser.GetModifiedAndNotModifiedLeakedPasswords(DataBreachToView));
            LoadModifiedExposedPasswords(getModifiedAndNotModifiedPasswords.Item2);
            LoadNotModifiedExposedPasswords(getModifiedAndNotModifiedPasswords.Item1);
            LoadExposedCreditCards(DataBreachToView.LeakedCreditCardsOfUser);
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

        private void btnMenu_Click(object sender, EventArgs e)
        {
            ClearControls();
            UserControl menu = new Menu(PasswordManager, PnlMainWindow);
            AddUserControl(menu);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ClearControls();
            UserControl dataBreachesHistory = new DataBreachesHistory(PasswordManager, PnlMainWindow);
            AddUserControl(dataBreachesHistory);
        }

        private void ClearControls()
        {
            PnlMainWindow.Controls.Clear();
        }

        private void AddUserControl(UserControl aUserControl)
        {
            PnlMainWindow.Controls.Add(aUserControl);
        }

        private void dgvExposedPasswords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                UserPasswordPair selected = SelectedUserPasswordPair(e.RowIndex);
                ClearControls();
                UserControl modifyUserPasswordPairControl = new ModifyUserPasswordPairFromDataBreachesHistory(PasswordManager, PnlMainWindow, selected, DataBreachToView);
                AddUserControl(modifyUserPasswordPairControl);
            }
        }

        private UserPasswordPair SelectedUserPasswordPair(int rowIndex)
        {
            return dgvNotModifiedPasswords.Rows[rowIndex].DataBoundItem as UserPasswordPair;
        }
    }
}
