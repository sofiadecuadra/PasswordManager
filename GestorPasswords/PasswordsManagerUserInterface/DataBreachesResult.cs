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
        public (List<UserPasswordPair>, List<CreditCard>) ExposedPasswordsAndCreditCards { get; set; }
        public DataBreachesResult(PasswordManager aPasswordManager, Panel panel)

        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            pnlMainWindow = panel;
            LoadDataExposed();
        }
    
        private void LoadDataExposed()
        {
            List<UserPasswordPair> listExposedPasswords = ExposedPasswordsAndCreditCards.Item1;
            foreach (UserPasswordPair userPasswordPair in listExposedPasswords)
            {
                listExposedPasswords.Add(userPasswordPair);
            }

            List<CreditCard> listExposedCreditCards = ExposedPasswordsAndCreditCards.Item2;
            foreach (CreditCard creditCard in listExposedCreditCards)
            {
                listExposedCreditCards.Add(creditCard);
            }
        }
    }
}
