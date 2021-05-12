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
        public Panel PnlMainWindow { get; private set; }
        public Categories(PasswordManager aPasswordManager, Panel panel)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = panel;
            LoadDataGridViewData();
        }

        private void LoadDataGridViewData()
        {
            dgvCategories.AutoGenerateColumns = false;
            dgvCategories.ColumnCount = 1;
            dgvCategories.Columns[0].Name = "Categories";
            dgvCategories.Columns[0].HeaderText = "Categories";
            dgvCategories.Columns[0].DataPropertyName = "Name";
            dgvCategories.Columns[0].Width = 215;
            dgvCategories.DataSource = PasswordManager.CurrentUser.GetCategories();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PnlMainWindow.Controls.Clear();
            UserControl menu = new Menu(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(menu);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PnlMainWindow.Controls.Clear();
            UserControl addCategory = new AddCategory(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(addCategory);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                LoadModifyCategoryForm();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please, choose a category to modify", "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadModifyCategoryForm()
        {
            NormalCategory selected = dgvCategories.SelectedRows[0].DataBoundItem as NormalCategory;
            PnlMainWindow.Controls.Clear();
            UserControl modifyCategory = new ModifyCategory(PasswordManager, PnlMainWindow, selected);
            PnlMainWindow.Controls.Add(modifyCategory);
        }
    }
}
