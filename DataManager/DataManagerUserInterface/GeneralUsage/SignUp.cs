using System;
using System.Windows.Forms;
using DataManagerDomain;

namespace PasswordsManagerUserInterface
{
    public partial class SignUp : UserControl
    {
        public DataManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }

        public SignUp(DataManager passwordManager, Panel panel)
        {
            InitializeComponent();
            PasswordManager = passwordManager;
            PnlMainWindow = panel;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                UserSignUp();
            }
            catch (Exception ex) when (ex is ExceptionUser || ex is ExceptionIncorrectLength)
            {
                MessageBox.Show(ex.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserSignUp()
        {
            User newUser = CreateUser();
            PasswordManager.AddUser(newUser);
            try
            {
                UserLogIn();
            }
            catch (ExceptionUser ex)
            {
                MessageBox.Show(ex.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private User CreateUser()
        {
            string username = txtUsername.Text;
            string masterPassword = txtPassword.Text;
            User newUser = new User()
            {
                Username = username,
                MasterPassword = masterPassword,
            };
            return newUser;
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

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            PnlMainWindow.Controls.Clear();
            UserControl logIn = new LogIn(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(logIn);
        }
    }
}
