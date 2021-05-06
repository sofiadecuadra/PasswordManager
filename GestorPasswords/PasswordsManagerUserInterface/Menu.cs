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
        public Panel pnlMainWindow { get; private set; }

        public Menu(PasswordManager aPasswordManager, Panel panel)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            pnlMainWindow = panel;
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {

        }

        private void btnPasswords_Click(object sender, EventArgs e)
        {
            //pnlMainWindow.Controls.Clear();
            //UserControl passwords = new Passwords(PasswordManager, pnlMainWindow);
            //pnlMainWindow.Controls.Add(passwords);
        }

        private void btnCreditCards_Click(object sender, EventArgs e)
        {
            //pnlMainWindow.Controls.Clear();
            //UserControl creditCards = new CreditCards(PasswordManager, pnlMainWindow);
            //pnlMainWindow.Controls.Add(creditCards);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            pnlMainWindow.Controls.Clear();
            UserControl logIn = new LogIn(PasswordManager, pnlMainWindow);
            pnlMainWindow.Controls.Add(logIn);
        }

        private void btnChangeMasterPassword_Click(object sender, EventArgs e)
        {
            //pnlMainWindow.Controls.Clear();
            //UserControl changeMasterPasswords = new ChangeMasterPasswords(PasswordManager, pnlMainWindow);
            //pnlMainWindow.Controls.Add(changeMasterPasswords);
        }

        private void btnCheckDataBreaches_Click(object sender, EventArgs e)
        {
            //pnlMainWindow.Controls.Clear();
            //UserControl checkDataBreaches = new CheckDataBreaches(PasswordManager, pnlMainWindow);
            //pnlMainWindow.Controls.Add(checkDataBreaches);
        }
    }
}
