using System;
using System.Windows.Forms;
using GestorPasswordsDominio;

namespace PasswordsManagerUserInterface
{
    public partial class UnshareUserPasswordPair : UserControl
    {
        public DataManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        public UserPasswordPair PasswordToUnshare { get; private set; }

        public UnshareUserPasswordPair(DataManager aPasswordManager, Panel panel, UserPasswordPair password)
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
            SetDefaultUser(users);
        }

        private void SetDefaultUser(User[] users)
        {
            if (users.Length > 0)
            {
                comboUsers.SelectedIndex = 0;
            }
        }

        private void btnUnshare_Click(object sender, EventArgs e)
        {
            try
            {
                Unshare();
            }
            catch (ExceptionUserDoesNotExist anException)
            {
                MessageBox.Show(anException.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Unshare()
        {
            string userToUnshare = comboUsers.Text;
            PasswordManager.UnsharePassword(PasswordToUnshare, userToUnshare);
            GoBackToPasswordView();
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