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
    public partial class UnshareUserPasswordPair : UserControl
    {
        public PasswordManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        public UserPasswordPair PasswordToUnshare { get; private set; }
        public UnshareUserPasswordPair(PasswordManager aPasswordManager, Panel panel, UserPasswordPair password)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = panel;
            PasswordToUnshare = password;
            LoadUsers();
        }

        private void LoadUsers()
        {
            var users = PasswordToUnshare.GetUsersWithAccessArray();

            foreach (var user in users)
            {
                comboUsers.Items.Add(user.Name);
            }
            if (users.Length > 0)
            {
                comboUsers.SelectedIndex = 0;
            }
        }

        private void btnUnshare_Click(object sender, EventArgs e)
        {
            try
            {
                string userToUnshare = comboUsers.Text;
                PasswordManager.UnsharePassword(PasswordToUnshare, userToUnshare);
                GoBackToPasswordView();
            }
            catch (ExceptionUserDoesNotExist anException)
            {

                MessageBox.Show(anException.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void GoBackToPasswordView()
        {
            PnlMainWindow.Controls.Clear();
            UserControl menu = new Passwords(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(menu);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GoBackToPasswordView();
        }
    }
}
