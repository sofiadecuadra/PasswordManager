using System;
using System.Windows.Forms;
using GestorPasswordsDominio;

namespace PasswordsManagerUserInterface
{
    public partial class ModifyCategory : UserControl
    {
        private const string ERROR_MESSAGE = "An error has occurred";
        public PasswordManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        public CategoryForm Form { get; private set; }
        public NormalCategory CategoryToModify { get; private set; }
        public ModifyCategory(PasswordManager aPasswordManager, Panel panel, NormalCategory aCategory)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = panel;
            CategoryToModify = aCategory;
            LoadCategoryForm(aCategory);
        }

        private void LoadCategoryForm(NormalCategory categoryToModified)
        {
            pnlAddCategory.Controls.Clear();
            Form = new CategoryForm(categoryToModified);
            pnlAddCategory.Controls.Add(Form);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                ModifyCategory_();
            }
            catch (Exception exception) when (
                exception is ExceptionCategoryNotExists
                || exception is ExceptionIncorrectLength
                || exception is ExceptionCategoryAlreadyExists
            )
            {
                ShowMessageBox(exception);
            }
        }

        private void ModifyCategory_()
        {
            string newName = Form.GetName();
            PasswordManager.CurrentUser.ModifyCategory(CategoryToModify, newName);
            GoBack();
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
