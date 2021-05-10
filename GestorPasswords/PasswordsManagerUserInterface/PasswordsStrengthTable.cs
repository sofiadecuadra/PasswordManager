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
    public partial class PasswordsStrengthTable : UserControl
    {
        public PasswordManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        private readonly DataGridViewButtonColumn seeList;
        Tuple<string, int, UserPasswordPair[]>[] passwordsReportData;

        public PasswordsStrengthTable(PasswordManager aPasswordManager, Panel panel)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = panel;
            seeList = new DataGridViewButtonColumn();
            LoadDataGridViewData();
        }

        private void LoadDataGridViewData()
        {
            dgvPasswordsReport.AutoGenerateColumns = false;
            dgvPasswordsReport.ColumnCount = 2;

            dgvPasswordsReport.Columns[0].Name = "Group";
            dgvPasswordsReport.Columns[0].Width = 100;

            dgvPasswordsReport.Columns[1].Name = "Quantity of Passwords";
            dgvPasswordsReport.Columns[1].Width = 100;

            dgvPasswordsReport.RowTemplate.Height = 30;

            dgvPasswordsReport.Columns.Add(seeList);
            seeList.HeaderText = @"";
            seeList.Name = "See List";
            seeList.Text = "See List";
            seeList.Width = 60;
            seeList.UseColumnTextForButtonValue = true;

            passwordsReportData = PasswordManager.CurrentUser.GetPasswordsStrengthReport();

            foreach (Tuple<string, int, UserPasswordPair[]> colorReport in passwordsReportData)
            {
                dgvPasswordsReport.Rows.Add(colorReport.Item1, colorReport.Item2);
            }
        }

        private void dgvPasswordsReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                
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
            UserControl passwords = new PasswordsStrengthChart(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(passwords);
        }
    }
}
