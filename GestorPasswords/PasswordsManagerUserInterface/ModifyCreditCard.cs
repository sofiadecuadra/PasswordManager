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
    public partial class ModifyCreditCard : UserControl
    {
        public PasswordManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        public CreditCardForm Form { get; private set; }
        public CreditCard CreditCardToModified { get; private set; }
        public ModifyCreditCard(PasswordManager aPasswordManager, Panel panel, CreditCard aCreditCard)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = panel;
            CreditCardToModified = aCreditCard;
            LoadCreditCardForm(aCreditCard);
        }

        private void LoadCreditCardForm(CreditCard creditCardToModify)
        {
            pnlModifyCreditCard.Controls.Clear();
            Form = new CreditCardForm(PasswordManager, creditCardToModify);
            pnlModifyCreditCard.Controls.Add(Form);
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
                ModifyCreditCard_();
            }
            catch (ExceptionCreditCardNumberAlreadyExistsInUser exception)
            {
                MessageBox.Show(exception.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionCreditCardDoesNotContainOnlyDigits exception)
            {
                MessageBox.Show(exception.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionCreditCardHasInvalidNumberLength exception)
            {
                MessageBox.Show(exception.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionCreditCardHasInvalidTypeLength exception)
            {
                MessageBox.Show(exception.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionCreditCardHasInvalidNameLength exception)
            {
                MessageBox.Show(exception.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionCreditCardHasInvalidCodeLength exception)
            {
                MessageBox.Show(exception.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionCreditCardCodeHasNonNumericCharacters exception)
            {
                MessageBox.Show(exception.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionCreditCardHasInvalidNotesLength exception)
            {
                MessageBox.Show(exception.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionCreditCardHasExpired exception)
            {
                MessageBox.Show(exception.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ModifyCreditCard_()
        {
            CreditCard modifiedCreditCard = new CreditCard()
            {
                Category = Form.GetCategory(),
                Name = Form.GetName(),
                Type = Form.GetCardType(),
                Number = Form.GetNumber(),
                Code = Form.GetCode(),
                ExpirationDate = Form.GetExpirationDate(),
                Notes = Form.GetNotes()
            };
            CreditCardToModified.Category.ModifyCreditCard(CreditCardToModified, modifiedCreditCard);
            GoBack();
        }
    }
}
