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
    public partial class CreditCards : UserControl
    {
        public PasswordManager PasswordManager { get; private set; }
        public Panel pnlMainWindow { get; private set; }
        public CreditCards(PasswordManager aPasswordManager, Panel panel)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            pnlMainWindow = panel;
            LoadDataGridViewData();
        }

        private void LoadDataGridViewData()
        {
            dgvCreditCards.AutoGenerateColumns = false;
            dgvCreditCards.ColumnCount = 5;
            dgvCreditCards.Columns[0].Name = "Category";
            dgvCreditCards.Columns[0].HeaderText = "Category";
            dgvCreditCards.Columns[0].DataPropertyName = "Category";
            dgvCreditCards.Columns[0].Width = 100;

            dgvCreditCards.Columns[1].Name = "Name";
            dgvCreditCards.Columns[1].HeaderText = "Name";
            dgvCreditCards.Columns[1].DataPropertyName = "Name";
            dgvCreditCards.Columns[1].Width = 100;

            dgvCreditCards.Columns[2].Name = "Type";
            dgvCreditCards.Columns[2].HeaderText = "Type";
            dgvCreditCards.Columns[2].DataPropertyName = "Type";
            dgvCreditCards.Columns[2].Width = 100;

            dgvCreditCards.Columns[3].Name = "Number";
            dgvCreditCards.Columns[3].HeaderText = "Number";
            dgvCreditCards.Columns[3].DataPropertyName = "Number";
            dgvCreditCards.Columns[3].Width = 120;

            dgvCreditCards.Columns[4].Name = "ExpirationDate";
            dgvCreditCards.Columns[4].HeaderText = "Expiration Date";
            dgvCreditCards.Columns[4].DataPropertyName = "ExpirationDate";
            dgvCreditCards.Columns[4].Width = 103;

            dgvCreditCards.DataSource = PasswordManager.CurrentUser.GetCreditCards();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            pnlMainWindow.Controls.Clear();
            UserControl menu = new Menu(PasswordManager, pnlMainWindow);
            pnlMainWindow.Controls.Add(menu);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            pnlMainWindow.Controls.Clear();
            UserControl addCreditCard = new AddCreditCard(PasswordManager, pnlMainWindow);
            pnlMainWindow.Controls.Add(addCreditCard);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                RemoveCreditCard();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please, choose a credit card to remove", "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionCreditCardDoesNotExist)
            {
                MessageBox.Show("The credit card does not exist", "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoveCreditCard()
        {
            CreditCard selected = dgvCreditCards.SelectedRows[0].DataBoundItem as CreditCard;
            selected.Category.RemoveCreditCard(selected.Number);
            dgvCreditCards.DataSource = PasswordManager.CurrentUser.GetCreditCards();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                LoadModifyCreditCardForm();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please, choose a credit card to modify", "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadModifyCreditCardForm()
        {
            CreditCard selected = dgvCreditCards.SelectedRows[0].DataBoundItem as CreditCard;
            pnlMainWindow.Controls.Clear();
            UserControl modifyCreditCard = new ModifyCreditCard(PasswordManager, pnlMainWindow, selected);
            pnlMainWindow.Controls.Add(modifyCreditCard);
        }

    }
}
