using GestorPasswordsDominio;
using System;
using System.Windows.Forms;

namespace PasswordsManagerUserInterface
{
    public partial class UserPasswordPairForm : UserControl
    {
        public DataManager PasswordManager { get; private set; }

        public UserPasswordPairForm(DataManager aPasswordManager)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            LoadCategories();
        }

        public UserPasswordPairForm (DataManager aPasswordManager, UserPasswordPair passwordToModify)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            LoadCategories();
            SetDefaultValues(passwordToModify);
        }

        private void LoadCategories()
        {
            NormalCategory[] categories = PasswordManager.CurrentUser.GetCategories();
            foreach (NormalCategory category in categories)
            {
                comboCategory.Items.Add(category);
            }
            SetDefaultCategory(categories);
        }

        private void SetDefaultCategory(NormalCategory[] categories)
        {
            if (categories.Length > 0)
            {
                comboCategory.SelectedIndex = 0;
            }
        }

        private void SetDefaultValues(UserPasswordPair passwordToModify)
        {
            comboCategory.SelectedItem = passwordToModify.Category;
            txtSite.Text = passwordToModify.Site;
            txtUser.Text = passwordToModify.Username;
            txtPassword.Text = passwordToModify.Password;
            txtNotes.Text = passwordToModify.Notes;
        }

        public NormalCategory GetCategory()
        {
            NormalCategory category = (NormalCategory)comboCategory.SelectedItem;
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
                GenerateRandomPassword(conditions);
            }
            catch (Exception ex) when (ex is ExceptionIncorrectLength || ex is ExceptionIncorrectGenerationPasswordType)
            {
                MessageBox.Show(ex.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void GenerateRandomPassword(PasswordGenerationConditions conditions)
        {
            string randomPassword = PasswordHandler.GenerateRandomPassword(conditions);
            txtPassword.Text = randomPassword;
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
