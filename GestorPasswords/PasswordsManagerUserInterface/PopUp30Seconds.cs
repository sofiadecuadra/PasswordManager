using System;
using System.Windows.Forms;
using GestorPasswordsDominio;

namespace PasswordsManagerUserInterface
{
    public partial class PopUp30Seconds : Form
    {
        public PopUp30Seconds(UserPasswordPair aUserPasswordPair)
        {
            InitializeComponent();
            LoadNormalUserPasswordPairData(aUserPasswordPair);
        }

        public PopUp30Seconds(UserPasswordPair aUserPasswordPair, string specialCategoryName)
        {
            InitializeComponent();
            LoadSharedUserPasswordPairData(aUserPasswordPair, specialCategoryName);
        }

        public PopUp30Seconds(CreditCard aCreditCard)
        {
            InitializeComponent();
            LoadCreditCardData(aCreditCard);
        }

        private void LoadNormalUserPasswordPairData(UserPasswordPair aUserPasswordPair)
        {
            SetUserPasswordPairColumnQuantity();
            SetNormalUserPasswordPairCategoryColumn();
            SetUserPasswordPairSiteColumn();
            SetUserPasswordPairUsernameColumn();
            SetUserPasswordPairPasswordColumn();
            SetUserPasswordPairLastModifiedColumn();
            SetUserPasswordPairData(aUserPasswordPair);
            txtNotes.Text = aUserPasswordPair.Notes;
        }

        private void SetUserPasswordPairColumnQuantity()
        {
            dgvData.AutoGenerateColumns = false;
            dgvData.ColumnCount = 5;
        }

        private void SetNormalUserPasswordPairCategoryColumn()
        {
            dgvData.Columns[0].Name = "Category";
            dgvData.Columns[0].DataPropertyName = "Category";
            dgvData.Columns[0].Width = 150;
        }

        private void SetUserPasswordPairSiteColumn()
        {
            dgvData.Columns[1].Name = "Site";
            dgvData.Columns[1].DataPropertyName = "Site";
            dgvData.Columns[1].Width = 218;
        }

        private void SetUserPasswordPairUsernameColumn()
        {
            dgvData.Columns[2].Name = "User";
            dgvData.Columns[2].DataPropertyName = "Username";
            dgvData.Columns[2].Width = 218;
        }

        private void SetUserPasswordPairPasswordColumn()
        {
            dgvData.Columns[3].Name = "Password";
            dgvData.Columns[3].DataPropertyName = "Password";
            dgvData.Columns[3].Width = 290;
        }

        private void SetUserPasswordPairLastModifiedColumn()
        {
            dgvData.Columns[4].Name = "LastModified";
            dgvData.Columns[4].DataPropertyName = "LastModifiedDate";
            dgvData.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvData.Columns[4].Width = 70;
        }

        private void SetUserPasswordPairData(UserPasswordPair aUserPasswordPair)
        {
            UserPasswordPair[] array = new UserPasswordPair[1];
            array[0] = aUserPasswordPair;
            dgvData.DataSource = array;
        }

        private void LoadSharedUserPasswordPairData(UserPasswordPair aUserPasswordPair, string categoryText)
        {
            SetUserPasswordPairColumnQuantity();
            SetSharedUserPasswordPairCategoryColumn(categoryText);
            SetUserPasswordPairSiteColumn();
            SetUserPasswordPairUsernameColumn();
            SetUserPasswordPairPasswordColumn();
            SetUserPasswordPairLastModifiedColumn();
            SetUserPasswordPairData(aUserPasswordPair);
            txtNotes.Text = aUserPasswordPair.Notes;
        }

        private void SetSharedUserPasswordPairCategoryColumn(string categoryText)
        {
            dgvData.Columns[0].Name = "Category";
            dgvData.Columns[0].DefaultCellStyle.NullValue = categoryText;
            dgvData.Columns[0].Width = 150;
        }

        private void LoadCreditCardData(CreditCard aCreditCard)
        {
            SetCreditCardColumnQuantity();
            SetCreditCardCategoryColumn();
            SetCreditCardNameColumn();
            SetCreditCardTypeColumn();
            SetCreditCardNumberColumn();
            SetCreditCardCodeColumn();
            SetCreditCardExpirationDateColumn();
            SetCreditCardData(aCreditCard);
            txtNotes.Text = aCreditCard.Notes;
        }

        private void SetCreditCardColumnQuantity()
        {
            dgvData.AutoGenerateColumns = false;
            dgvData.ColumnCount = 6;
        }

        private void SetCreditCardCategoryColumn()
        {
            dgvData.Columns[0].Name = "Category";
            dgvData.Columns[0].Width = 132;
        }

        private void SetCreditCardNameColumn()
        {
            dgvData.Columns[1].Name = "Name";
            dgvData.Columns[1].Width = 286;
        }

        private void SetCreditCardTypeColumn()
        {
            dgvData.Columns[2].Name = "Type";
            dgvData.Columns[2].Width = 286;
        }

        private void SetCreditCardNumberColumn()
        {
            dgvData.Columns[3].Name = "Number";
            dgvData.Columns[3].Width = 120;
        }

        private void SetCreditCardCodeColumn()
        {
            dgvData.Columns[4].Name = "Code";
            dgvData.Columns[4].Width = 44;
        }

        private void SetCreditCardExpirationDateColumn()
        {
            dgvData.Columns[5].Name = "Expiration Date";
            dgvData.Columns[5].DefaultCellStyle.Format = "MM/yyyy";
            dgvData.Columns[5].Width = 79;
        }

        private void SetCreditCardData(CreditCard aCreditCard)
        {
            dgvData.Rows.Add(aCreditCard.Category, aCreditCard.Name, aCreditCard.Type, CreditCard.FormatNumber(aCreditCard.Number), aCreditCard.Code, aCreditCard.ExpirationDate);
        }

        private void PopUp30Seconds_Load(object sender, EventArgs e)
        {
            timer.Interval = 30000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Close();
        }
    }
}