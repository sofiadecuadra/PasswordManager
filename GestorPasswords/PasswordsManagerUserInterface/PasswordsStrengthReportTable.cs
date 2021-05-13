using System;
using System.Windows.Forms;
using GestorPasswordsDominio;

namespace PasswordsManagerUserInterface
{
    public partial class PasswordsStrengthReportTable : UserControl
    {
        public DataManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        private readonly DataGridViewButtonColumn seeList;
        Tuple<PasswordStrengthType, int>[] passwordsReportData;

        public PasswordsStrengthReportTable(DataManager aPasswordManager, Panel panel)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = panel;
            seeList = new DataGridViewButtonColumn();
            LoadDataGridViewData();
        }

        private void LoadDataGridViewData()
        {
            SetColumnsQuantity();
            SetGroupColumn();
            SetQuantityOfPasswordsColumn();
            SetRowsHeight();
            SetSeeListColumn();
            InsertDataInTable();
        }

        private void SetColumnsQuantity()
        {
            dgvPasswordsReport.AutoGenerateColumns = false;
            dgvPasswordsReport.ColumnCount = 2;
        }

        private void SetGroupColumn()
        {
            dgvPasswordsReport.Columns[0].Name = "Group";
            dgvPasswordsReport.Columns[0].Width = 100;
        }

        private void SetQuantityOfPasswordsColumn()
        {
            dgvPasswordsReport.Columns[1].Name = "Quantity of Passwords";
            dgvPasswordsReport.Columns[1].Width = 100;
        }

        private void SetRowsHeight()
        {
            dgvPasswordsReport.RowTemplate.Height = 30;
        }

        private void SetSeeListColumn()
        {
            dgvPasswordsReport.Columns.Add(seeList);
            seeList.HeaderText = @"";
            seeList.Name = "See List";
            seeList.Text = "See List";
            seeList.Width = 60;
            seeList.UseColumnTextForButtonValue = true;
        }

        private void InsertDataInTable()
        {
            passwordsReportData = PasswordManager.CurrentUser.GetPasswordsStrengthReport();
            foreach (Tuple<PasswordStrengthType, int> colorReport in passwordsReportData)
            {
                dgvPasswordsReport.Rows.Add(colorReport.Item1, colorReport.Item2);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PnlMainWindow.Controls.Clear();
            UserControl passwords = new Passwords(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(passwords);
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            PnlMainWindow.Controls.Clear();
            UserControl passwords = new PasswordsStrengthReportChart(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(passwords);
        }

        private void dgvPasswordsReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                PnlMainWindow.Controls.Clear();
                PasswordStrengthType color = passwordsReportData[e.RowIndex].Item1;
                PasswordsReportPasswordsList passwordsList = new PasswordsReportPasswordsList(PasswordManager, PnlMainWindow, color);
                PnlMainWindow.Controls.Add(passwordsList);
            }
        }
    }
}