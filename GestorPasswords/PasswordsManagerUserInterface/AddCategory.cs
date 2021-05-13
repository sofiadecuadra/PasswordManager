using System;
using System.Windows.Forms;
using GestorPasswordsDominio;

namespace PasswordsManagerUserInterface
{
    public partial class AddCategory : UserControl
    {
        private const string ERROR_MESSAGE = "An error has occurred";
        public PasswordManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        public CategoryForm Form { get; private set; }
        public AddCategory(PasswordManager aPasswordManager, Panel panel)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = panel;
            LoadCategoryForm();
        }

        private void LoadCategoryForm()
        {
            pnlAddCategory.Controls.Clear();
            Form = new CategoryForm();
            pnlAddCategory.Controls.Add(Form);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
           try
            {
                AddCategory_();
            }
            catch (ExceptionIncorrectLength exception)
            {
                ShowMessageBox(exception);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("The category already exists", ERROR_MESSAGE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddCategory_()
        {
            NormalCategory newCategory = CreateCategory();
            PasswordManager.CurrentUser.AddCategory(newCategory);
            GoBack();
        }

        private NormalCategory CreateCategory()
        {
            string name = Form.GetName();
            NormalCategory newCategory = new NormalCategory()
            {
                Name = name,
                User = PasswordManager.CurrentUser
            };

            return newCategory;
        }

        private void ShowMessageBox(Exception exception)
        {
            MessageBox.Show(exception.Message, ERROR_MESSAGE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void GoBack()
        {
            PnlMainWindow.Controls.Clear();
            UserControl categories = new Categories(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(categories);
        }
    }
}
