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
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        public PasswordManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }

        public LogIn(PasswordManager aPasswordManager, Panel panel)
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
            catch (ExceptionUserDoesNotExist)
            {
                MessageBox.Show("The user does not exist", "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionIncorrectMasterPassword)
            {
                MessageBox.Show("Wrong password", "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
