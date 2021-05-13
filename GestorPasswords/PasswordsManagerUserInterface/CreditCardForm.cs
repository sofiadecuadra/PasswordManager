using System;
using System.Windows.Forms;
using GestorPasswordsDominio;

namespace PasswordsManagerUserInterface
{
    public partial class CreditCardForm : UserControl
    {
        public DataManager PasswordManager { get; private set; }
        public CreditCardForm(DataManager aPasswordManager)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            LoadCategories();
            SetMinExpirationDate();
        }

        public CreditCardForm(DataManager aPasswordManager, CreditCard aCreditCard)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            LoadCategories();
            SetMinExpirationDate();
            LoadDefaultValues(aCreditCard);
        }

        private void LoadDefaultValues(CreditCard aCreditCard)
        {
            cbCategory.SelectedItem = aCreditCard.Category;
            txtName.Text = aCreditCard.Name;
            txtType.Text = aCreditCard.Type;
            txtNumber.Text = FormattedNumber(aCreditCard.Number);
            txtCode.Text = aCreditCard.Code;
            dtpExpirationDate.Value = aCreditCard.ExpirationDate;
            txtNotes.Text = aCreditCard.Notes;
        }

        private void SetMinExpirationDate()
        {
            dtpExpirationDate.MinDate = DateTime.Now;
        }

        private void LoadCategories()
        {
            cbCategory.DataSource = GetCategories();
        }

        private Category [] GetCategories()
        {
            return PasswordManager.CurrentUser.GetCategories();
        }

        public NormalCategory GetCategory()
        {
            NormalCategory selectedCategory = cbCategory.SelectedItem as NormalCategory;
            return selectedCategory;
        }

        public string GetName()
        {
            return txtName.Text;
        }

        public string GetCardType()
        {
            return txtType.Text;
        }

        public string GetNumber()
        {
            return txtNumber.Text;
        }

        public string GetCode()
        {
            return txtCode.Text;
        }

        public DateTime GetExpirationDate()
        {
            return dtpExpirationDate.Value;
        }

        public string GetNotes()
        {
            return txtNotes.Text;
        }

        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            txtNumber.Text = FormattedNumber(txtNumber.Text);
            txtNumber.SelectionStart = NumberLenght();
        }

        private string FormattedNumber(string numberToFormat)
        {
            return CreditCard.FormatNumber(numberToFormat);
        }

        private int NumberLenght()
        {
            return txtNumber.Text.Length;
        }
    }
}
