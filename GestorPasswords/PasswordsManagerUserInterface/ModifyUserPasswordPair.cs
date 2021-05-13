using GestorPasswordsDominio;
using System;
using System.Windows.Forms;

namespace PasswordsManagerUserInterface
{
    public partial class ModifyUserPasswordPair : UserControl
    {
        public PasswordManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        public UserPasswordPairForm Form { get; private set; }
        public UserPasswordPair PasswordToModified { get; private set; }

        public ModifyUserPasswordPair(PasswordManager aPasswordManager, Panel panel, UserPasswordPair password)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = panel;
            PasswordToModified = password;
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
            UserPasswordPair newPassword = CreatePassword();
            PasswordToModified.Category.ModifyUserPasswordPair(PasswordToModified, newPassword);
            GoBack();
        }

        private UserPasswordPair CreatePassword()
        {
            NormalCategory category = Form.GetCategory();
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