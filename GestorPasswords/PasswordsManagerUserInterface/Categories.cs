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
    public partial class Categories : UserControl
    {
        public PasswordManager PasswordManager { get; private set; }
        public Panel pnlMainWindow { get; private set; }
        public Categories(PasswordManager aPasswordManager, Panel panel)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            pnlMainWindow = panel;
            LoadDataGridViewData();
        }

        private void LoadDataGridViewData()
        {
            Category category = new Category() { Name = " Hola", User = PasswordManager.CurrentUser };
            PasswordManager.CurrentUser.AddCategory(category);
            dgvCategories.AutoGenerateColumns = false;
            dgvCategories.ColumnCount = 1;
            dgvCategories.Columns[0].Name = "Categories";
            dgvCategories.Columns[0].HeaderText = "Categories";
            dgvCategories.Columns[0].DataPropertyName = "Name";
            dgvCategories.DataSource = PasswordManager.CurrentUser.GetCategories();
        }
    }
}
