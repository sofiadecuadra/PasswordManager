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
    public partial class AddCreditCard : UserControl
    {
        public PasswordManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        public CreditCardForm Form { get; private set; }
        public AddCreditCard(PasswordManager aPasswordManager, Panel panel)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = panel;
            LoadCreditCardForm();
        }

        private void LoadCreditCardForm()
        {
            pnlAddCreditCard.Controls.Clear();
            Form = new CreditCardForm(PasswordManager);
            pnlAddCreditCard.Controls.Add(Form);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void GoBack()
        {
            PnlMainWindow.Controls.Clear();
            UserControl creditCards = new CreditCards(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(creditCards);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewCreditCard();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please, choose a category", "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionCreditCardNumberAlreadyExistsInUser exception)
            {
                MessageBox.Show(exception.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionCreditCardDoesNotContainOnlyDigits exception)
            {
                MessageBox.Show(exception.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionIncorrectLength exception)
            {
                MessageBox.Show(exception.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionCreditCardCodeHasNonNumericCharacters exception)
            {
                MessageBox.Show(exception.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionCreditCardHasExpired exception)
            {
                MessageBox.Show(exception.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddNewCreditCard()
        {
            CreditCard newCreditCard = CreateCreditCard();
            newCreditCard.Category.AddCreditCard(newCreditCard);
            GoBack();
        }

        private CreditCard CreateCreditCard()
        {
            CreditCard newCreditCard = new CreditCard()
            {
                Name = Form.GetName(),
                Number = Form.GetNumber(),
                Notes = Form.GetNotes(),
                Code = Form.GetCode(),
                Type = Form.GetCardType(),
                ExpirationDate = Form.GetExpirationDate(),
                Category = Form.GetCategory()
            };
            return newCreditCard;
        }
    }
}
