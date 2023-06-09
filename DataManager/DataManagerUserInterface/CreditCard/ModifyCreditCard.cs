﻿using System;
using System.Windows.Forms;
using DataManagerDomain;

namespace PasswordsManagerUserInterface
{
    public partial class ModifyCreditCard : UserControl
    {
        private const string ERROR_MESSAGE = "An error has occurred";
        public DataManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        public CreditCardForm Form { get; private set; }
        public CreditCard CreditCardToModify { get; private set; }

        public ModifyCreditCard(DataManager aPasswordManager, Panel aPanel, CreditCard aCreditCard)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = aPanel;
            CreditCardToModify = aCreditCard;
            LoadCreditCardForm(aCreditCard);
        }

        private void LoadCreditCardForm(CreditCard creditCardToModify)
        {
            ClearControls(pnlModifyCreditCard);
            Form = new CreditCardForm(PasswordManager, creditCardToModify);
            AddUserControl(pnlModifyCreditCard, Form);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                ModifyCreditCard_();
            }
            catch (Exception exception) when (exception is ExceptionCreditCard || exception is ExceptionIncorrectLength)
            {
                ShowMessageBox(exception);
            }
        }

        private void ModifyCreditCard_()
        {
            CreditCard modifiedCreditCard = CreateCreditCard();
            CreditCardToModify.Category.ModifyCreditCard(CreditCardToModify, modifiedCreditCard);
            GoBack();
        }

        private CreditCard CreateCreditCard()
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
            return modifiedCreditCard;
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
