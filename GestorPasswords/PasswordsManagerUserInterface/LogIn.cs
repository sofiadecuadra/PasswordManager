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
    public partial class LogIn : UserControl
    {
        public PasswordManager PasswordManager { get; private set; }
        public Panel pnlMainWindow { get; private set; }

        public LogIn(PasswordManager aPasswordManager, Panel panel)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            pnlMainWindow = panel;
        }


        private void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                UserLogIn();
            }
            catch (ExceptionUserDoesNotExist)
            {
                MessageBox.Show("The user does not exist", "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            pnlMainWindow.Controls.Clear();
            //UserControl logIn = new LogIn(PasswordManager, pnlMainWindow); // main window of application
            //pnlMainWindow.Controls.Add(logIn);
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            pnlMainWindow.Controls.Clear();
            UserControl signUp = new SignUp(PasswordManager, pnlMainWindow);
            pnlMainWindow.Controls.Add(signUp);
        }
    }
}
