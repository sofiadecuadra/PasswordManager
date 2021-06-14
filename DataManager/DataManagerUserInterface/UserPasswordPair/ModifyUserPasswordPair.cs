using DataManagerDomain;
using System;
using System.Windows.Forms;

namespace PasswordsManagerUserInterface
{
    public partial class ModifyUserPasswordPair : UserControl
    {
        public DataManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        public UserPasswordPairForm Form { get; private set; }
        public UserPasswordPair PasswordToModify { get; private set; }

        public ModifyUserPasswordPair(DataManager aPasswordManager, Panel panel, UserPasswordPair password)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = panel;
            PasswordToModify = password;
            LoadUserPasswordPairForm(password);
        }

        private void LoadUserPasswordPairForm(UserPasswordPair passwordToModified)
        {
            pnlModifyUserPasswordPair.Controls.Clear();
            Form = new UserPasswordPairForm(PasswordManager, passwordToModified);
            pnlModifyUserPasswordPair.Controls.Add(Form);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                ModifyPassword();
            }
            catch (Exception ex) when (ex is ExceptionExistingUserPasswordPair || ex is ExceptionIncorrectLength)
            {
                MessageBox.Show(ex.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ModifyPassword()
        {
            UserPasswordPair newUserPasswordPair = CreatePassword();
            if (PasswordHasBeenUpdated(newUserPasswordPair.Password))
            {
                Tuple<bool, bool, bool> suggestionsAreTakenIntoAccount = PasswordManager.CurrentUser.PasswordImprovementSuggestionsAreTakenIntoAccount(newUserPasswordPair.Password);
                if (!HelperClass.LaunchSuggestionBox(suggestionsAreTakenIntoAccount))
                {
                    PasswordToModify.Category.ModifyUserPasswordPair(PasswordToModify, newUserPasswordPair);
                    GoBack();
                }
            }
            else
            {
                PasswordToModify.Category.ModifyUserPasswordPair(PasswordToModify, newUserPasswordPair);
                GoBack();
            }
        }

        private bool PasswordHasBeenUpdated(string newPassword)
        {
            return !Category.PasswordsAreEqual(PasswordToModify.Password, newPassword);
        }

        private UserPasswordPair CreatePassword()
        {
            Category category = Form.GetCategory();
            string site = Form.GetSite();
            string username = Form.GetUsername();
            string password = Form.GetPassword();
            string notes = Form.GetNotes();
            UserPasswordPair userPasswordPair = new UserPasswordPair()
            {
                Category = category,
                Site = site,
                Username = username,
                Password = password,
                Notes = notes
            };
            return userPasswordPair;
        }

        private void GoBack()
        {
            PnlMainWindow.Controls.Clear();
            UserControl passwords = new Passwords(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(passwords);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GoBack();
        }
    }
}