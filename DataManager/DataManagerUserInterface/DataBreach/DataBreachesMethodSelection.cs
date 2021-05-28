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
                var fileContent = string.Empty;
                var filePath = string.Empty;

                //Get the path of specified file
                filePath = dataBreachesOFileDialog.FileName;

                //Read the contents of the file into a stream
                var fileStream = dataBreachesOFileDialog.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }

                MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
            }

        }
    }
}
