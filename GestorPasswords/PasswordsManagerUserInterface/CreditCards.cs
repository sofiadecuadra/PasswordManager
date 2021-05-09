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
        public Panel PnlMainWindow { get; private set; }
        
        private readonly DataGridViewButtonColumn fullView;
        public CreditCards(PasswordManager aPasswordManager, Panel panel)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = panel;
            fullView = new DataGridViewButtonColumn();
            LoadDataGridViewData();
        }

        private void LoadDataGridViewData()
        {
            dgvCreditCards.AutoGenerateColumns = false;
            dgvCreditCards.ColumnCount = 5;
            dgvCreditCards.Columns[0].Name = "Category";
            dgvCreditCards.Columns[0].HeaderText = "Category";
            dgvCreditCards.Columns[0].DataPropertyName = "Category";
            dgvCreditCards.Columns[0].Width = 140;

            dgvCreditCards.Columns[1].Name = "Name";
            dgvCreditCards.Columns[1].HeaderText = "Name";
            dgvCreditCards.Columns[1].DataPropertyName = "Name";
            dgvCreditCards.Columns[1].Width = 153;

            dgvCreditCards.Columns[2].Name = "Type";
            dgvCreditCards.Columns[2].HeaderText = "Type";
            dgvCreditCards.Columns[2].DataPropertyName = "Type";
            dgvCreditCards.Columns[2].Width = 153;

            dgvCreditCards.Columns[3].Name = "Number";
            dgvCreditCards.Columns[3].HeaderText = "Number";
            dgvCreditCards.Columns[3].DataPropertyName = "HideNumber";
            dgvCreditCards.Columns[3].Width = 140;

            dgvCreditCards.Columns[4].Name = "ExpirationDate";
            dgvCreditCards.Columns[4].HeaderText = "Expiration Date";
            dgvCreditCards.Columns[4].DataPropertyName = "ExpirationDate";
            dgvCreditCards.Columns[4].DefaultCellStyle.Format = "MM/yyyy";
            dgvCreditCards.Columns[4].Width = 71;

            dgvCreditCards.Columns.Add(fullView);
            fullView.HeaderText = @"";
            fullView.Name = "Full view";
            fullView.Text = "Full view";
            fullView.Width = 60;
            fullView.UseColumnTextForButtonValue = true;

            dgvCreditCards.DataSource = PasswordManager.CurrentUser.GetCreditCards();

            for (int i = 0; i < dgvCreditCards.Rows.Count; i++)
            {
                string numberFormatted = CreditCard.FormatNumber(dgvCreditCards.Rows[i].Cells[3].Value.ToString());
                dgvCreditCards.Rows[i].Cells[3].Value = numberFormatted;
            }
        }
        
        private void btnBack_Click(object sender, EventArgs e)
        {
            PnlMainWindow.Controls.Clear();
            UserControl menu = new Menu(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(menu);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PnlMainWindow.Controls.Clear();
            UserControl addCreditCard = new AddCreditCard(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(addCreditCard);
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
            PnlMainWindow.Controls.Clear();
            UserControl modifyCreditCard = new ModifyCreditCard(PasswordManager, PnlMainWindow, selected);
            PnlMainWindow.Controls.Add(modifyCreditCard);
        }

        private void dgvCreditCards_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                CreditCard selected = dgvCreditCards.Rows[e.RowIndex].DataBoundItem as CreditCard;
                // Load pop-up window
            }
        }
    }
}
