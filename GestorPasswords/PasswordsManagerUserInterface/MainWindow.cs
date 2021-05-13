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
            ClearControls();
            UserControl logIn = new LogIn(PasswordManager, pnlMain);
            AddUserControl(logIn);
        }

        private void ClearControls()
        {
            pnlMain.Controls.Clear();
        }

        private void AddUserControl(UserControl aUserControl)
        {
            pnlMain.Controls.Add(aUserControl);
        }
    }
}
