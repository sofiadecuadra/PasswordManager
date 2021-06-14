using DataManagerDomain;
using System;
using System.Windows.Forms;

namespace PasswordsManagerUserInterface
{
    public partial class ModifyUserPasswordPairFromDataBreachesHistory : UserControl
    {
        public DataManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        public UserPasswordPairForm Form { get; private set; }
        public UserPasswordPair PasswordToModify { get; private set; }
        public DataBreach DataBreach { get; private set; }
        public ModifyUserPasswordPairFromDataBreachesHistory(DataManager aPasswordManager, Panel panel, UserPasswordPair password, DataBreach dataBreach)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = panel;
            PasswordToModify = password;
            DataBreach = dataBreach;
            LoadUserPasswordPairForm(password);
        }
        private void LoadUserPasswordPairForm(UserPasswordPair PasswordToModify)
        {
            pnlModifyUserPasswordPair.Controls.Clear();
            Form = new UserPasswordPairForm(PasswordManager, PasswordToModify);
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
            UserControl dataBreachHistoryResult = new DataBreachHistoryResult(PasswordManager, PnlMainWindow, DataBreach);
            PnlMainWindow.Controls.Add(dataBreachHistoryResult);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GoBack();
        }
    }
}
