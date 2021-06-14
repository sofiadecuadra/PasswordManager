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
            Category[] categories = PasswordManager.CurrentUser.GetCategories();
            foreach (Category category in categories)
            {
                LoadRedPasswordsQuantityToChart(category);
                LoadOrangePasswordsQuantityToChart(category);
                LoadYellowPasswordsQuantityToChart(category);
                LoadLightGreenPasswordsQuantityToChart(category);
                LoadDarkGreenPasswordsQuantityToChart(category);
            }
        }

        private void LoadRedPasswordsQuantityToChart(Category category)
        {
            chartPasswordsReport.Series["Red"].Points.AddXY(category.Name, category.RedUserPasswordPairsQuantity);
        }

        private void LoadOrangePasswordsQuantityToChart(Category category)
        {
            chartPasswordsReport.Series["Orange"].Points.AddXY(category.Name, category.OrangeUserPasswordPairsQuantity);
        }

        private void LoadYellowPasswordsQuantityToChart(Category category)
        {
            chartPasswordsReport.Series["Yellow"].Points.AddXY(category.Name, category.YellowUserPasswordPairsQuantity);
        }

        private void LoadLightGreenPasswordsQuantityToChart(Category category)
        {
            chartPasswordsReport.Series["Light Green"].Points.AddXY(category.Name, category.LightGreenUserPasswordPairsQuantity);
        }

        private void LoadDarkGreenPasswordsQuantityToChart(Category category)
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