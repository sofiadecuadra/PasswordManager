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
    public partial class AddCategory : UserControl
    {
        public PasswordManager PasswordManager { get; private set; }
        public Panel pnlMainWindow { get; private set; }
        public AddCategory(PasswordManager aPasswordManager, Panel panel)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            pnlMainWindow = panel;
            LoadCategoryForm();
        }

        private void LoadCategoryForm()
        {
            pnlAddCategory.Controls.Clear();
            UserControl form = new CategoryForm(PasswordManager);
            pnlAddCategory.Controls.Add(form);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
        }
    }
}
