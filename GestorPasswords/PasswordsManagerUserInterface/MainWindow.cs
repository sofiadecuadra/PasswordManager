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
    public partial class MainWindow : Form
    {
        public PasswordManager PasswordManager { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            PasswordManager = new PasswordManager();
            LoadLogInUserControl();
        }

        private void LoadLogInUserControl()
        {
            pnlMain.Controls.Clear();
            UserControl logIn = new LogIn(PasswordManager, pnlMain);
            pnlMain.Controls.Add(logIn);
        }
    }
}
