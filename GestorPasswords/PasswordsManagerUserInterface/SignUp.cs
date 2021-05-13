using System;
using System.Windows.Forms;
using GestorPasswordsDominio;

namespace PasswordsManagerUserInterface
{
    public partial class SignUp : UserControl
    {
        public PasswordManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }

        public SignUp(PasswordManager passwordManager, Panel panel)
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
            catch (ArgumentException)
            {
                MessageBox.Show("The user already exists", "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionIncorrectLength exception)
            {
                MessageBox.Show(exception.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch (ExceptionUserDoesNotExist)
            {
                MessageBox.Show("The user does not exist", "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionIncorrectMasterPassword)
            {
                MessageBox.Show("Wrong password", "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private User CreateUser()
        {
            string username = txtUsername.Text;
            string masterPassword = txtPassword.Text;
            User newUser = new User()
            {
                Name = username,
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
