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
    public partial class CreditCardForm : UserControl
    {
        public PasswordManager PasswordManager { get; private set; }

        public CreditCardForm(PasswordManager aPasswordManager)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            LoadCategories();
            SetMinExpirationDate();
        }

        public CreditCardForm(PasswordManager aPasswordManager, CreditCard aCreditCard)
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
            txtNumber.Text = aCreditCard.Number;
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
            cbCategory.DataSource = PasswordManager.CurrentUser.GetCategories();
        }

        public Category GetCategory()
        {
            Category selectedCategory = cbCategory.SelectedItem as Category;
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
    }
}
