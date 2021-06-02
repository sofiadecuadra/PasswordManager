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
        public DataBreach DataBreach { get; private set; }

        public ModifyUserPasswordPairExposedInDataBreaches(DataManager aPasswordManager, Panel panel, UserPasswordPair password, DataBreach dataBreach)
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
            if (!NormalCategory.PasswordsAreEqual(PasswordToModify.Password, newPassword.Password))
            {
                if (!GoBackToModifyPasswordAfterReadingSuggestions(newPassword.Password))
                {
                    PasswordToModify.Category.ModifyUserPasswordPair(PasswordToModify, newPassword);
                    GoBack();
                }
            }
            else
            {
                PasswordToModify.Category.ModifyUserPasswordPair(PasswordToModify, newPassword);
                GoBack();
            }
        }

        public bool GoBackToModifyPasswordAfterReadingSuggestions(string aPassword)
        {
            bool goBackToModifyPassword = false;
            Tuple<bool, bool, bool> suggestionsAreTakenIntoAccount = PasswordManager.CurrentUser.PasswordImprovementSuggestionsAreTakenIntoAccount(aPassword);
            bool passwordIsStrong = suggestionsAreTakenIntoAccount.Item1;
            bool passwordIsNotDuplicated = suggestionsAreTakenIntoAccount.Item2;
            bool passwordHasNotAppearedInDataBreaches = suggestionsAreTakenIntoAccount.Item3;

            if (!passwordIsStrong || !passwordIsNotDuplicated || !passwordHasNotAppearedInDataBreaches)
            {
                string suggestionsMessage = "Password Improvement Suggestions:\n";
                if (!passwordIsStrong)
                {
                    suggestionsMessage += "\n - Improve it's strength";
                }
                if (!passwordIsNotDuplicated)
                {
                    suggestionsMessage += "\n - Try another one, reusing a password is not recommended";
                }
                if (!passwordHasNotAppearedInDataBreaches)
                {
                    suggestionsMessage += "\n - Try another one, the one provided has appeared in a data breach";
                }
                suggestionsMessage += "\n\nWould you like to go back and change the password provided?";

                DialogResult goBack = MessageBox.Show(suggestionsMessage, "Suggestions", MessageBoxButtons.YesNo);

                if (goBack == DialogResult.Yes)
                {
                    goBackToModifyPassword = true;
                }
            }
            return goBackToModifyPassword;
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
            UserControl dataBreachesResult = new DataBreachesResult(PasswordManager, PnlMainWindow, DataBreach);
            PnlMainWindow.Controls.Add(dataBreachesResult);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GoBack();
        }
    }
}