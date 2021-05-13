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
        public Categories(PasswordManager aPasswordManager, Panel aPanel)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = aPanel;
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

            dgvCategories.DataSource = GetCategories();
        }

        private NormalCategory [] GetCategories()
        {
            return PasswordManager.CurrentUser.GetCategories();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearControls();
            UserControl addCategory = new AddCategory(PasswordManager, PnlMainWindow);
            AddUserControl(addCategory);
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
            NormalCategory selected = SelectedCategory();
            ClearControls();
            UserControl modifyCategory = new ModifyCategory(PasswordManager, PnlMainWindow, selected);
            AddUserControl(modifyCategory);
        }

        private NormalCategory SelectedCategory()
        {
            return dgvCategories.SelectedRows[0].DataBoundItem as NormalCategory;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ClearControls();
            UserControl menu = new Menu(PasswordManager, PnlMainWindow);
            AddUserControl(menu);
        }

        private void ClearControls()
        {
            PnlMainWindow.Controls.Clear();
        }

        private void AddUserControl(UserControl aUserControl)
        {
            PnlMainWindow.Controls.Add(aUserControl);
        }
    }
}
