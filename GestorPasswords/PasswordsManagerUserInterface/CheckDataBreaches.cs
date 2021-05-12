using GestorPasswordsDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordsManagerUserInterface
{
    public partial class CheckDataBreaches : UserControl
    {
        public PasswordManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        public CheckDataBreaches(PasswordManager aPasswordManager, Panel panel)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = panel;
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
            PnlMainWindow.Controls.Clear();
            UserControl dataBreachesResult = new DataBreachesResult(PasswordManager, PnlMainWindow, dataBreaches);
            PnlMainWindow.Controls.Add(dataBreachesResult);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PnlMainWindow.Controls.Clear();
            UserControl menu = new Menu(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(menu);
        }
    }
}
