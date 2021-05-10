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
    public partial class ShareUserPasswordPair : UserControl
    {
        public PasswordManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        public UserPasswordPair PasswordToShare { get; private set; }
        public ShareUserPasswordPair(PasswordManager aPasswordManager, Panel panel, UserPasswordPair password)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = panel;
            PasswordToShare = password;
            LoadUsers();
        }

        private void LoadUsers()
        {
            var users = PasswordManager.Users;

            foreach (var user in users)
            {
                AddUserNameToComboUsers(user);
            }
        }

        private void AddUserNameToComboUsers(User user)
        {
            if (NotTheCurrentUser(user))
            {
                comboUsers.Items.Add(user.Name);
            }
        }

        private bool NotTheCurrentUser(User user)
        {
            return !user.Name.Equals(PasswordManager.CurrentUser.Name);
        }

        private void btnShare_Click(object sender, EventArgs e)
        {
            try
            {
                string userToShareWith = comboUsers.Text;
                PasswordManager.SharePassword(PasswordToShare, userToShareWith);
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
