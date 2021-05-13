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
    public partial class Menu : UserControl
    {
        public PasswordManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }

        public Menu(PasswordManager aPasswordManager, Panel panel)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = panel;
        }

        private void btnPasswords_Click(object sender, EventArgs e)
        {
            PnlMainWindow.Controls.Clear();
            UserControl passwords = new Passwords(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(passwords);
        }

        private void btnCreditCards_Click(object sender, EventArgs e)
        {
            PnlMainWindow.Controls.Clear();
            UserControl creditCards = new CreditCards(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(creditCards);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            PnlMainWindow.Controls.Clear();
            UserControl logIn = new LogIn(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(logIn);
        }

        private void btnChangeMasterPassword_Click(object sender, EventArgs e)
        {
            PnlMainWindow.Controls.Clear();
            UserControl changeMasterPasswords = new ChangeMasterPassword(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(changeMasterPasswords);
        }

        private void btnCheckDataBreaches_Click(object sender, EventArgs e)
        {
            PnlMainWindow.Controls.Clear();
            UserControl checkDataBreaches = new CheckDataBreaches(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(checkDataBreaches);
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            PnlMainWindow.Controls.Clear();
            UserControl categories = new Categories(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(categories);
        }
    }
}
