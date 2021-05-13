using System;
using System.Windows.Forms;
using DataManagerDomain;

namespace PasswordsManagerUserInterface
{
    public partial class ModifyReportedUserPasswordPair : UserControl
    {
        public DataManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        public UserPasswordPairForm Form { get; private set; }
        public UserPasswordPair PasswordToModified { get; private set; }
        public PasswordStrengthType passwordColor;

        public ModifyReportedUserPasswordPair(DataManager aPasswordManager, Panel panel, UserPasswordPair password, PasswordStrengthType color)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = panel;
            PasswordToModified = password;
            passwordColor = color;
            LoadUserPasswordPairForm(password);
        }

        private void LoadUserPasswordPairForm(UserPasswordPair passwordToModified)
        {
            pnlModifyPassword.Controls.Clear();
            Form = new UserPasswordPairForm(PasswordManager, passwordToModified);
            pnlModifyPassword.Controls.Add(Form);
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
            UserControl passwords = new PasswordsReportPasswordsList(PasswordManager, PnlMainWindow, passwordColor);
            PnlMainWindow.Controls.Add(passwords);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GoBack();
        }
    }
}
