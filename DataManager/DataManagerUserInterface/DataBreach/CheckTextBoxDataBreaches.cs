using DataManagerDomain;
using System;
using System.Windows.Forms;

namespace PasswordsManagerUserInterface
{
    public partial class CheckDataBreaches : UserControl
    {
        public DataManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }

        public CheckDataBreaches(DataManager aPasswordManager, Panel aPanel)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = aPanel;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string dataBreaches = txtDataBreaches.Text;
            IDataBreachesFormatter textBoxDataBreaches = new TextBoxDataBreaches()
            {
                txtDataBreaches = dataBreaches
            };
            LoadDataBreachesResult(textBoxDataBreaches);
        }

        private void LoadDataBreachesResult(IDataBreachesFormatter dataBreaches)
        {
            ClearControls();
            UserControl dataBreachesResult = new DataBreachesResult(PasswordManager, PnlMainWindow, dataBreaches);
            AddUserControl(dataBreachesResult);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ClearControls();
            UserControl dataBreachMethodSelection = new DataBreachesMethodSelection(PasswordManager, PnlMainWindow);
            AddUserControl(dataBreachMethodSelection);
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
