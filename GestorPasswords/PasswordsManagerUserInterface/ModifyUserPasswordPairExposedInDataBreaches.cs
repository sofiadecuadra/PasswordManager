using GestorPasswordsDominio;
using System;
using System.Windows.Forms;

namespace PasswordsManagerUserInterface
{
    public partial class ModifyUserPasswordPairExposedInDataBreaches : UserControl
    {
        private const string ERROR_MESSAGE = "An error has occurred";
        public PasswordManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        public UserPasswordPairForm Form { get; private set; }
        public UserPasswordPair PasswordToModify { get; private set; }
        public IDataBreachesFormatter DataBreaches { get; private set; }
        public ModifyUserPasswordPairExposedInDataBreaches(PasswordManager aPasswordManager, Panel panel, UserPasswordPair password, IDataBreachesFormatter dataBreaches)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = panel;
            PasswordToModify = password;
            DataBreaches = dataBreaches;
            LoadUserPasswordPairForm(password);
        }

        private void LoadUserPasswordPairForm(UserPasswordPair PasswordToModify)
        {
            pnlModifyUserPasswordPair.Controls.Clear();
            Form = new UserPasswordPairForm(PasswordManager, PasswordToModify);
            pnlModifyUserPasswordPair.Controls.Add(Form);
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

        private void btnAccept_Click_1(object sender, EventArgs e)
        {
            try
            {
                ModifyPassword();
            }
            catch (ExceptionExistingUserPasswordPair exception)
            {
                MessageBox.Show(exception.Message, ERROR_MESSAGE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionIncorrectLength exception)
            {
                MessageBox.Show(exception.Message, ERROR_MESSAGE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ModifyPassword()
        {
            UserPasswordPair newPassword = CreatePassword();
            PasswordToModify.Category.ModifyUserPasswordPair(PasswordToModify, newPassword);
            GoBack();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void GoBack()
        {
            PnlMainWindow.Controls.Clear();
            UserControl dataBreachesResult = new DataBreachesResult(PasswordManager, PnlMainWindow, DataBreaches);
            PnlMainWindow.Controls.Add(dataBreachesResult);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            PnlMainWindow.Controls.Clear();
            UserControl menu = new Menu(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(menu);
        }
    }
}
