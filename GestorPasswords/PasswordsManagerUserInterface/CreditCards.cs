using System;
using System.Windows.Forms;
using GestorPasswordsDominio;

namespace PasswordsManagerUserInterface
{
    public partial class CreditCards : UserControl
    {
        private const string ERROR_MESSAGE = "An error has occurred";
        public PasswordManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        private readonly DataGridViewButtonColumn fullView;
        public CreditCards(PasswordManager aPasswordManager, Panel aPanel)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = aPanel;
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

            dgvCreditCards.DataSource = GetCreditCards();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearControls();
            UserControl addCreditCard = new AddCreditCard(PasswordManager, PnlMainWindow);
            AddUserControl(addCreditCard);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                LoadModifyCreditCardForm();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please, choose a credit card to modify", ERROR_MESSAGE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadModifyCreditCardForm()
        {
            CreditCard selected = SelectedCreditCard(0);
            ClearControls();
            UserControl modifyCreditCard = new ModifyCreditCard(PasswordManager, PnlMainWindow, selected);
            AddUserControl(modifyCreditCard);
        }

        private void RemoveCreditCard()
        {
            CreditCard selected = SelectedCreditCard(0);
            selected.Category.RemoveCreditCard(selected.Number);
            dgvCreditCards.DataSource = GetCreditCards();
        }

        private CreditCard[] GetCreditCards()
        {
            return PasswordManager.CurrentUser.GetCreditCards();
        }

        private void dgvCreditCards_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                CreditCard selected = SelectedCreditCard(e.RowIndex);
                _ = new PopUp30Seconds(selected)
                {
                    Visible = true
                };
            }
        }

        private CreditCard SelectedCreditCard(int rowIndex)
        {
            return dgvCreditCards.SelectedRows[rowIndex].DataBoundItem as CreditCard;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                RemoveCreditCard();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please, choose a credit card to remove", ERROR_MESSAGE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionCreditCardDoesNotExist exception)
            {
                ShowMessageBox(exception);
            }
        }

        private void ShowMessageBox(Exception exception)
        {
            MessageBox.Show(exception.Message, ERROR_MESSAGE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ClearControls();
            UserControl menu = new Menu(PasswordManager, PnlMainWindow);
            AddUserControl(menu);
        }

        private void ClearControls()
        {
            PnlMainWindow.Controls.Clear();
        }

        private void AddUserControl(UserControl aUserControl)
        {
            PnlMainWindow.Controls.Add(aUserControl);
        }
    }
}
