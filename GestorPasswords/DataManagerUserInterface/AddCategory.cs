using System;
using System.Windows.Forms;
using DataManagerDomain;

namespace PasswordsManagerUserInterface
{
    public partial class AddCategory : UserControl
    {
        private const string ERROR_MESSAGE = "An error has occurred";
        public DataManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        public CategoryForm Form { get; private set; }

        public AddCategory(DataManager aPasswordManager, Panel aPanel)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = aPanel;
            LoadCategoryForm();
        }

        private void LoadCategoryForm()
        {
            ClearControls(pnlAddCategory);
            Form = new CategoryForm();
            AddUserControl(pnlAddCategory,Form);
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
            CurrentUser().AddCategory(newCategory);
            GoBack();
        }

        private NormalCategory CreateCategory()
        {
            string name = Form.GetName();
            NormalCategory newCategory = new NormalCategory()
            {
                Name = name,
                User = CurrentUser()
            };
            return newCategory;
        }

        private void ShowMessageBox(Exception exception)
        {
            MessageBox.Show(exception.Message, ERROR_MESSAGE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private User CurrentUser()
        {
            return PasswordManager.CurrentUser;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void GoBack()
        {
            ClearControls(PnlMainWindow);
            UserControl categories = new Categories(PasswordManager, PnlMainWindow);
            AddUserControl(PnlMainWindow, categories);
        }

        private void ClearControls(Panel aPanel)
        {
            aPanel.Controls.Clear();
        }

        private void AddUserControl(Panel aPanel, UserControl aUserControl)
        {
            aPanel.Controls.Add(aUserControl);
        }
    }
}
