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
    public partial class CategoryForm : UserControl
    {
        public PasswordManager PasswordManager { get; private set; }

        public CategoryForm(PasswordManager aPasswordManager)
        {
            InitializeComponent();
        }
    }
}
