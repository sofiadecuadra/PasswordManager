﻿using System;
using System.Windows.Forms;
using DataManagerDomain;

namespace PasswordsManagerUserInterface
{
    public partial class AddCreditCard : UserControl
    {
        private const string ERROR_MESSAGE = "An error has occurred";
        public DataManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        public CreditCardForm Form { get; private set; }

        public AddCreditCard(DataManager aPasswordManager, Panel aPanel)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = aPanel;
            LoadCreditCardForm();
        }

        private void LoadCreditCardForm()
        {
            ClearControls(pnlAddCreditCard);
            Form = new CreditCardForm(PasswordManager);
            AddUserControl(pnlAddCreditCard, Form);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewCreditCard();
            }
            catch (Exception exception) when ( exception is ExceptionCreditCard || exception is ExceptionIncorrectLength)
            {
                ShowMessageBox(exception);
            }
        }

        private void AddNewCreditCard()
        {
            if (CategorySelectedIsValid())
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

        private bool CategorySelectedIsValid()
        {
            return Form.GetCategory() != null;
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
            ClearControls(PnlMainWindow);
            UserControl creditCards = new CreditCards(PasswordManager, PnlMainWindow);
            AddUserControl(PnlMainWindow, creditCards);
        }

        private void ClearControls(Panel aPanel)
        {
            aPanel.Controls.Clear();
        }

        private void AddUserControl(Panel aPanel, UserControl aUserControl)
        {
            aPanel.Controls.Add(aUserControl);
        }
    }
}
