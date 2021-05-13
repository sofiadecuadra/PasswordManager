using System;
using System.Windows.Forms;
using GestorPasswordsDominio;

namespace PasswordsManagerUserInterface
{
    public partial class AddCreditCard : UserControl
    {
        private const string ERROR_MESSAGE = "An error has occurred";
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

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewCreditCard();
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

        private void AddNewCreditCard()
        {
            if (Form.GetCategory() != null)
            {
                CreditCard newCreditCard = CreateCreditCard();
                newCreditCard.Category.AddCreditCard(newCreditCard);
                GoBack();
            }
            else
            {
                MessageBox.Show("The category cannot be null \n To add a category go to Menu -> Categories -> Add", ERROR_MESSAGE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowMessageBox(Exception exception)
        {
            MessageBox.Show(exception.Message, ERROR_MESSAGE, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
