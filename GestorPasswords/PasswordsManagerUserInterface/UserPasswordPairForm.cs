using GestorPasswordsDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordsManagerUserInterface
{
    public partial class UserPasswordPairForm : UserControl
    {
        public PasswordManager PasswordManager { get; private set; }
        public UserPasswordPairForm(PasswordManager aPasswordManager)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            txtPassword.PasswordChar = '*';
            LoadCategories();
        }

        public UserPasswordPairForm (PasswordManager aPasswordManager, UserPasswordPair passwordToModify)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            txtPassword.PasswordChar = '*';
            LoadCategories();
            comboCategory.SelectedItem = passwordToModify.Category;
            txtSite.Text = passwordToModify.Site;
            txtUser.Text = passwordToModify.Username;
            txtPassword.Text = passwordToModify.Password;
            txtNotes.Text = passwordToModify.Notes;
        }

        private void LoadCategories()
        {
            Category[] categories = PasswordManager.CurrentUser.GetCategories();

            foreach (Category category in categories)
            {
                comboCategory.Items.Add(category);
            }
            if (categories.Length > 0)
            {
                comboCategory.SelectedIndex = 0;
            }
        }

        public Category GetCategory()
        {
            Category category = (Category)comboCategory.SelectedItem;
            return category;
        }

        public string GetSite()
        {
            return txtSite.Text.Trim();
        }
        public string GetUsername()
        {
            return txtUser.Text.Trim();
        }
        public string GetPassword()
        {
            return txtPassword.Text;
        }
        public string GetNotes()
        {
            return txtNotes.Text.Trim();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            PasswordGenerationConditions conditions = CreatePasswordGenerationConditions();
            try
            {
                string randomPassword = PasswordHandler.GenerateRandomPassword(conditions);
                txtPassword.Text = randomPassword;
            }
            catch (ExceptionIncorrectLength exception)
            {
                MessageBox.Show(exception.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionIncorrectGenerationPasswordType exception)
            {
                MessageBox.Show(exception.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private PasswordGenerationConditions CreatePasswordGenerationConditions()
        {
            PasswordGenerationConditions conditions = new PasswordGenerationConditions()
            {
                Length = (int)numericUpDownLength.Value,
                HasUpperCase = checkBoxUpperCase.Checked,
                HasLowerCase = checkBoxLowerCase.Checked,
                HasDigits = checkBoxDigits.Checked,
                HasSymbols = checkBoxSymbols.Checked,
            };
            return conditions;
        }

        private void checkBoxShow_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShow.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }         
        }
    }
}
