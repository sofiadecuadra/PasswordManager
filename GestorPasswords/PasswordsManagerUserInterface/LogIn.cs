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
    public partial class LogIn : UserControl
    {
        public PasswordManager PasswordManager { get; private set; }

        public LogIn(PasswordManager aPasswordManager)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
        }
    }
}
