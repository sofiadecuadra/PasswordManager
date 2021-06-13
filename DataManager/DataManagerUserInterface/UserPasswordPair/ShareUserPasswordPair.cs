using System;
using System.Windows.Forms;
using DataManagerDomain;

namespace PasswordsManagerUserInterface
{
    public partial class ShareUserPasswordPair : UserControl
    {
        public DataManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        public UserPasswordPair PasswordToShare { get; private set; }

        public ShareUserPasswordPair(DataManager aPasswordManager, Panel panel, UserPasswordPair password)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = panel;
            PasswordToShare = password;
            LoadUsers();
        }

        private void LoadUsers()
        {
            User[] users = PasswordManager.GetUsers();
            foreach (User user in users)
            {
                AddUserNameToComboUsers(user);
            }
            SetDefaultUser(users);
        }

        private void AddUserNameToComboUsers(User user)
        {
            if (NotTheCurrentUser(user))
            {
                comboUsers.Items.Add(user);
            }
        }

        private void SetDefaultUser(User[] users)
        {
            if (users.Length > 1)
            {
                comboUsers.SelectedIndex = 0;
            }
        }

        private bool NotTheCurrentUser(User user)
        {
            return !user.Username.Equals(PasswordManager.CurrentUser.Username);
        }

        private void btnShare_Click(object sender, EventArgs e)
        {
            try
            {
                Share();
            }
            catch (ExceptionUserDoesNotExist anException)
            {
                MessageBox.Show(anException.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("The password has already been shared with the selected user", "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Share()
        {
            User userToShareWith = comboUsers.SelectedItem as User;
            PasswordManager.SharePassword(PasswordToShare, userToShareWith);
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
