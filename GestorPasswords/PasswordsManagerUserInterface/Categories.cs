using System;
using System.Windows.Forms;
using GestorPasswordsDominio;

namespace PasswordsManagerUserInterface
{
    public partial class Categories : UserControl
    {
        private const string ERROR_MESSAGE = "An error has occurred";
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
                MessageBox.Show("Please, choose a category to modify", ERROR_MESSAGE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadModifyCategoryForm()
        {
            NormalCategory selected = dgvCategories.SelectedRows[0].DataBoundItem as NormalCategory;
            PnlMainWindow.Controls.Clear();
            UserControl modifyCategory = new ModifyCategory(PasswordManager, PnlMainWindow, selected);
            PnlMainWindow.Controls.Add(modifyCategory);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PnlMainWindow.Controls.Clear();
            UserControl menu = new Menu(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(menu);
        }
    }
}
