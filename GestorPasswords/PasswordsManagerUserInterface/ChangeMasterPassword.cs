using System;
using System.Windows.Forms;
using DataManagerDomain;

namespace PasswordsManagerUserInterface
{
    public partial class ChangeMasterPassword : UserControl
    {
        public DataManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }

        public ChangeMasterPassword(DataManager passwordManager, Panel pnlMainWindow)
        {
            InitializeComponent();
            PasswordManager = passwordManager;
            PnlMainWindow = pnlMainWindow;
        }

        private void btnUpdateMasterPassword_Click(object sender, System.EventArgs e)
        {
            string oldPassword = txtOldPassword.Text;
            string newPassword = txtNewPassword.Text;
            try
            {
                ChangeMasterPassword_(oldPassword, newPassword);
            }
            catch (Exception ex) when (ex is ExceptionIncorrectMasterPassword || ex is ExceptionIncorrectLength)
            {
                MessageBox.Show(ex.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangeMasterPassword_(string oldPassword, string newPassword)
        {
            PasswordManager
                .CurrentUser.ChangeMasterPassword(oldPassword, newPassword);
            GoBackToMainMenu();
        }

        private void GoBackToMainMenu()
        {
            PnlMainWindow.Controls.Clear();
            UserControl menu = new Menu(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(menu);
        }

        private void btnBack_Click(object sender, System.EventArgs e)
        {
            GoBackToMainMenu();
        }
    }
}
