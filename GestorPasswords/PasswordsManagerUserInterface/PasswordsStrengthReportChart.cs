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
    public partial class PasswordsStrengthReportChart : UserControl
    {
        public PasswordManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        public PasswordsStrengthReportChart(PasswordManager aPasswordManager, Panel panel)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = panel;
            LoadChartData();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PnlMainWindow.Controls.Clear();
            UserControl passwordReportTable = new PasswordsStrengthReportTable(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(passwordReportTable);
        }

        private void LoadChartData()
        {
            NormalCategory[] categories = PasswordManager.CurrentUser.GetCategories();

            foreach (NormalCategory category in categories)
            {
                chartPasswordsReport.Series["Red"].Points.AddXY(category.Name, category.RedUserPasswordPairsQuantity);
                chartPasswordsReport.Series["Orange"].Points.AddXY(category.Name, category.OrangeUserPasswordPairsQuantity);
                chartPasswordsReport.Series["Yellow"].Points.AddXY(category.Name, category.YellowUserPasswordPairsQuantity);
                chartPasswordsReport.Series["Light Green"].Points.AddXY(category.Name, category.LightGreenUserPasswordPairsQuantity);
                chartPasswordsReport.Series["Dark Green"].Points.AddXY(category.Name, category.DarkGreenUserPasswordPairsQuantity);
            }
        }
    }
}
