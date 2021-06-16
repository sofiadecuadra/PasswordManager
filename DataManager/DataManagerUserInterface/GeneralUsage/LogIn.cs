using DataManagerDomain;
using System;
using System.Windows.Forms;

namespace PasswordsManagerUserInterface
{
    public partial class LogIn : UserControl
    {
        public DataManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }

        public LogIn(DataManager aPasswordManager, Panel panel)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = panel;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                UserLogIn();
            }
            catch (ExceptionUser ex)
            {
                MessageBox.Show(ex.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserLogIn()
        {
            string username = txtUsername.Text;
            string masterPassword = txtPassword.Text;
            PasswordManager.LogIn(username, masterPassword);
            LoadApplication();
        }

        private void LoadApplication()
        {
            PnlMainWindow.Controls.Clear();
            UserControl menu = new Menu(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(menu);
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            PnlMainWindow.Controls.Clear();
            UserControl signUp = new SignUp(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(signUp);
        }
    }
}
