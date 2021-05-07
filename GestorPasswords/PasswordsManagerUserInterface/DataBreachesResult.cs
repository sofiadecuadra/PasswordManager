using GestorPasswordsDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordsManagerUserInterface
{
    public partial class DataBreachesResult : UserControl
    {
        public PasswordManager PasswordManager { get; private set; }
        public Panel pnlMainWindow { get; private set; }
        public IDataBreachesFormatter DataBreaches { get; private set; }
        public DataBreachesResult(PasswordManager aPasswordManager, Panel panel, IDataBreachesFormatter dataBreaches)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            pnlMainWindow = panel;
            DataBreaches = dataBreaches;
            LoadDataExposed();
        }
    
        private void LoadDataExposed()
        {
            (List<UserPasswordPair>, List<CreditCard>) ExposedPasswordsAndCreditCards = PasswordManager.CurrentUser.CheckDataBreaches(DataBreaches);
            List<UserPasswordPair> exposedPasswords = new List <UserPasswordPair> (ExposedPasswordsAndCreditCards.Item1);
            List<CreditCard> exposedCreditCards = new List<CreditCard>(ExposedPasswordsAndCreditCards.Item2);

            foreach (UserPasswordPair userPasswordPair in exposedPasswords)
            {
                listExposedPasswords.Items.Add(userPasswordPair);
            }

            foreach (CreditCard creditCard in exposedCreditCards)
            {
                listExposedCreditCards.Items.Add(creditCard);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            pnlMainWindow.Controls.Clear();
            UserControl checkDataBreaches = new CheckDataBreaches(PasswordManager, pnlMainWindow);
            pnlMainWindow.Controls.Add(checkDataBreaches);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            pnlMainWindow.Controls.Clear();
            UserControl menu = new Menu(PasswordManager, pnlMainWindow);
            pnlMainWindow.Controls.Add(menu);
        }
    }
}
