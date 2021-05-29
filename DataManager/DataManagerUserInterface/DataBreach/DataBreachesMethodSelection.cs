using System;
using System.IO;
using System.Windows.Forms;
using DataManagerDomain;

namespace PasswordsManagerUserInterface.DataBreach
{
    public partial class DataBreachesMethodSelection : UserControl
    {
        public DataManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }

        public DataBreachesMethodSelection(DataManager aPasswordManager, Panel aPanel)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = aPanel;
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

        private void btnFillTextBox_Click(object sender, EventArgs e)
        {
            ClearControls();
            UserControl checkDataBreaches = new CheckDataBreaches(PasswordManager, PnlMainWindow);
            AddUserControl(checkDataBreaches);
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            if (dataBreachesOFileDialog.ShowDialog() == DialogResult.OK)
            {
                IDataBreachesFormatter textBoxDataBreaches = new TxtFileDataBreaches()
                {
                    txtDataBreaches = ReadFileContent()
                };
                LoadDataBreachesResult(textBoxDataBreaches);
            }
        }

        private string ReadFileContent()
        {
            var fileStream = dataBreachesOFileDialog.OpenFile();
            StreamReader reader = new StreamReader(fileStream);
            return reader.ReadToEnd();
        }

        private void LoadDataBreachesResult(IDataBreachesFormatter dataBreaches)
        {
            ClearControls();
            UserControl dataBreachesResult = new DataBreachesResult(PasswordManager, PnlMainWindow, dataBreaches);
            AddUserControl(dataBreachesResult);
        }
    }
}