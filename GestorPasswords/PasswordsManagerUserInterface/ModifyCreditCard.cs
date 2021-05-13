using System;
using System.Windows.Forms;
using GestorPasswordsDominio;

namespace PasswordsManagerUserInterface
{
    public partial class ModifyCreditCard : UserControl
    {
        private const string ERROR_MESSAGE = "An error has occurred";
        public PasswordManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        public CreditCardForm Form { get; private set; }
        public CreditCard CreditCardToModify { get; private set; }
        public ModifyCreditCard(PasswordManager aPasswordManager, Panel panel, CreditCard aCreditCard)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = panel;
            CreditCardToModify = aCreditCard;
            LoadCreditCardForm(aCreditCard);
        }

        private void LoadCreditCardForm(CreditCard creditCardToModify)
        {
            pnlModifyCreditCard.Controls.Clear();
            Form = new CreditCardForm(PasswordManager, creditCardToModify);
            pnlModifyCreditCard.Controls.Add(Form);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                ModifyCreditCard_();
            }
            catch (Exception exception) when (
                exception is ExceptionCreditCardNumberAlreadyExistsInUser
                || exception is ExceptionCreditCardDoesNotContainOnlyDigits
                || exception is ExceptionIncorrectLength
                || exception is ExceptionCreditCardCodeHasNonNumericCharacters
                || exception is ExceptionCreditCardHasExpired
            )
            {
                ShowMessageBox(exception);
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
            CreditCardToModify.Category.ModifyCreditCard(CreditCardToModify, modifiedCreditCard);
            GoBack();
        }

        private void ShowMessageBox(Exception exception)
        {
            MessageBox.Show(exception.Message, ERROR_MESSAGE, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
