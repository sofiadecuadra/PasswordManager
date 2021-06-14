using DataManagerDomain;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PasswordsManagerUserInterface
{
    public partial class DataBreachesHistory : UserControl
    {
        public DataManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        private readonly DataGridViewButtonColumn viewDataBreach;
        public DataBreachesHistory(DataManager aPasswordManager, Panel aPanel)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = aPanel;
            viewDataBreach = new DataGridViewButtonColumn();
            LoadDataBreachesHistory();
        }

        private void LoadDataBreachesHistory()
        {
            List<DataBreach> dataBreaches = PasswordManager.CurrentUser.DataBreaches;
            SetDataBreachesColumnQuantity();
            SetDataBreachesDateColumn();
            SetDataBreachesViewColumn();
            dgvDataBreaches.DataSource = dataBreaches;
        }
        private void SetDataBreachesViewColumn()
        {
            dgvDataBreaches.Columns.Add(viewDataBreach);
            viewDataBreach.HeaderText = @"";
            viewDataBreach.Name = "View";
            viewDataBreach.Text = "View";
            viewDataBreach.Width = 61;
            viewDataBreach.UseColumnTextForButtonValue = true;
        }

        private void SetDataBreachesDateColumn()
        {
            dgvDataBreaches.Columns[0].Name = "Date";
            dgvDataBreaches.Columns[0].HeaderText = "Date";
            dgvDataBreaches.Columns[0].DataPropertyName = "DateTime";
            dgvDataBreaches.Columns[0].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm";
            dgvDataBreaches.Columns[0].Width = 221;
        }

        private void SetDataBreachesColumnQuantity()
        {
            dgvDataBreaches.AutoGenerateColumns = false;
            dgvDataBreaches.ColumnCount = 1;
        }

        private void dgvDataBreaches_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                DataBreach selected = SelectedDataBreach(e.RowIndex);
                ClearControls();
                UserControl dataBreachHistoryResult = new DataBreachHistoryResult(PasswordManager, PnlMainWindow, selected);
                AddUserControl(dataBreachHistoryResult);
            }
        }

        private DataBreach SelectedDataBreach(int rowIndex)
        {
            return dgvDataBreaches.Rows[rowIndex].DataBoundItem as DataBreach;
        }

        private void ClearControls()
        {
            PnlMainWindow.Controls.Clear();
        }

        private void AddUserControl(UserControl aUserControl)
        {
            PnlMainWindow.Controls.Add(aUserControl);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            ClearControls();
            UserControl menu = new Menu(PasswordManager, PnlMainWindow);
            AddUserControl(menu);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ClearControls();
            UserControl dataBreachesMethodSelection = new DataBreachesMethodSelection(PasswordManager, PnlMainWindow);
            AddUserControl(dataBreachesMethodSelection);
        }
    }
}
