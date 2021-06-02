using System;
using System.Windows.Forms;

namespace PasswordsManagerUserInterface
{
    public static class HelperClass
    {
        public static bool LaunchSuggestionBox(Tuple<bool, bool, bool> suggestionsAreTakenIntoAccount)
        {
            bool goBackToModifyPassword = false;
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
    }
}
