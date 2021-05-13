using DataManagerDomain;
using System;
using System.Windows.Forms;

namespace PasswordsManagerUserInterface
{
    public partial class ModifyUserPasswordPairExposedInDataBreaches : UserControl
    {
        public DataManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        public UserPasswordPairForm Form { get; private set; }
        public UserPasswordPair PasswordToModify { get; private set; }
        public IDataBreachesFormatter DataBreaches { get; private set; }

        public ModifyUserPasswordPairExposedInDataBreaches(DataManager aPasswordManager, Panel panel, UserPasswordPair password, IDataBreachesFormatter dataBreaches)
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

        private void btnAccept_Click_1(object sender, EventArgs e)
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
            PasswordToModify.Category.ModifyUserPasswordPair(PasswordToModify, newPassword);
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
            UserControl dataBreachesResult = new DataBreachesResult(PasswordManager, PnlMainWindow, DataBreaches);
            PnlMainWindow.Controls.Add(dataBreachesResult);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GoBack();
        }
    }
}