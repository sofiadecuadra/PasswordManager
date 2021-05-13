using System;
using System.Windows.Forms;
using GestorPasswordsDominio;

namespace PasswordsManagerUserInterface
{
    public partial class Menu : UserControl
    {
        public DataManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        public Menu(DataManager aPasswordManager, Panel panel)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = panel;
        }

        private void btnPasswords_Click(object sender, EventArgs e)
        {
            ClearControls();
            UserControl passwords = new Passwords(PasswordManager, PnlMainWindow);
            AddUserControl(passwords);
        }

        private void btnCreditCards_Click(object sender, EventArgs e)
        {
            ClearControls();
            UserControl creditCards = new CreditCards(PasswordManager, PnlMainWindow);
            AddUserControl(creditCards);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            ClearControls();
            UserControl logIn = new LogIn(PasswordManager, PnlMainWindow);
            AddUserControl(logIn);
        }

        private void btnChangeMasterPassword_Click(object sender, EventArgs e)
        {
            ClearControls();
            UserControl changeMasterPassword = new ChangeMasterPassword(PasswordManager, PnlMainWindow);
            AddUserControl(changeMasterPassword);
        }

        private void btnCheckDataBreaches_Click(object sender, EventArgs e)
        {
            ClearControls();
            UserControl checkDataBreaches = new CheckDataBreaches(PasswordManager, PnlMainWindow);
            AddUserControl(checkDataBreaches);
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            ClearControls();
            UserControl categories = new Categories(PasswordManager, PnlMainWindow);
            AddUserControl(categories);
        }

        private void ClearControls()
        {
            PnlMainWindow.Controls.Clear();
        }

        private void AddUserControl(UserControl aUserControl)
        {
            PnlMainWindow.Controls.Add(aUserControl);
        }
    }
}
