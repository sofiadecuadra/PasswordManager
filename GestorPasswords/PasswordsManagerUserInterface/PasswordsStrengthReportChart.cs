using System;
using System.Windows.Forms;
using DataManagerDomain;

namespace PasswordsManagerUserInterface
{
    public partial class PasswordsStrengthReportChart : UserControl
    {
        public DataManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }

        public PasswordsStrengthReportChart(DataManager aPasswordManager, Panel panel)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = panel;
            LoadChartData();
        }

        private void LoadChartData()
        {
            NormalCategory[] categories = PasswordManager.CurrentUser.GetCategories();
            foreach (NormalCategory category in categories)
            {
                LoadRedPasswordsQuantityToChart(category);
                LoadOrangePasswordsQuantityToChart(category);
                LoadYellowPasswordsQuantityToChart(category);
                LoadLightGreenPasswordsQuantityToChart(category);
                LoadDarkGreenPasswordsQuantityToChart(category);
            }
        }

        private void LoadRedPasswordsQuantityToChart(NormalCategory category)
        {
            chartPasswordsReport.Series["Red"].Points.AddXY(category.Name, category.RedUserPasswordPairsQuantity);
        }

        private void LoadOrangePasswordsQuantityToChart(NormalCategory category)
        {
            chartPasswordsReport.Series["Orange"].Points.AddXY(category.Name, category.OrangeUserPasswordPairsQuantity);
        }

        private void LoadYellowPasswordsQuantityToChart(NormalCategory category)
        {
            chartPasswordsReport.Series["Yellow"].Points.AddXY(category.Name, category.YellowUserPasswordPairsQuantity);
        }

        private void LoadLightGreenPasswordsQuantityToChart(NormalCategory category)
        {
            chartPasswordsReport.Series["Light Green"].Points.AddXY(category.Name, category.LightGreenUserPasswordPairsQuantity);
        }

        private void LoadDarkGreenPasswordsQuantityToChart(NormalCategory category)
        {
            chartPasswordsReport.Series["Dark Green"].Points.AddXY(category.Name, category.DarkGreenUserPasswordPairsQuantity);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PnlMainWindow.Controls.Clear();
            UserControl passwordReportTable = new PasswordsStrengthReportTable(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(passwordReportTable);
        }
    }
}