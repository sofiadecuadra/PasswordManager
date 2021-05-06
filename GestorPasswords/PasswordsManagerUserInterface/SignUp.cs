using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestorPasswordsDominio;

namespace PasswordsManagerUserInterface
{
    public partial class SignUp : UserControl
    {
        public PasswordManager PasswordManager { get; private set; }
        public Panel pnlMainWindow { get; private set; }
        public SignUp(PasswordManager passwordManager, Panel panel)
        {
            InitializeComponent();
            PasswordManager = passwordManager;
            pnlMainWindow = panel;
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
            catch (ExceptionIncorrectUserNameLength exception)
            {
                MessageBox.Show(exception.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            LoadApplication();
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


        private void LoadApplication()
        {
            pnlMainWindow.Controls.Clear();
            UserControl menu = new Menu(PasswordManager, pnlMainWindow);
            pnlMainWindow.Controls.Add(menu);
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            pnlMainWindow.Controls.Clear();
            UserControl logIn = new LogIn(PasswordManager, pnlMainWindow);
            pnlMainWindow.Controls.Add(logIn);
        }
    }
}
