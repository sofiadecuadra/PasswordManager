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
        public Panel pnlMainWindow { get; private set; }
        public CheckDataBreaches(PasswordManager aPasswordManager, Panel panel)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            pnlMainWindow = panel;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string dataBreaches = txtDataBreaches.Text;
            IDataBreachesFormatter textBoxDataBreaches = new TextBoxDataBreaches()
            {
                txtDataBreaches = dataBreaches
            };
            LoadApplication(textBoxDataBreaches);
        }

        private void LoadApplication(IDataBreachesFormatter dataBreaches)
        {
            pnlMainWindow.Controls.Clear();
            UserControl dataBreachesResult = new DataBreachesResult(PasswordManager, pnlMainWindow, dataBreaches);
            pnlMainWindow.Controls.Add(dataBreachesResult);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            pnlMainWindow.Controls.Clear();
            UserControl menu = new Menu(PasswordManager, pnlMainWindow);
            pnlMainWindow.Controls.Add(menu);
        }
    }
}
