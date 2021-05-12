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
    public partial class ModifyCategory : UserControl
    {
        public PasswordManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        public CategoryForm Form { get; private set; }
        public Category CategoryToModified { get; private set; }

        public ModifyCategory(PasswordManager aPasswordManager, Panel panel, Category category)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = panel;
            CategoryToModified = category;
            LoadCategoryForm(category);
        }

        private void LoadCategoryForm(Category categoryToModified)
        {
            pnlAddCategory.Controls.Clear();
            Form = new CategoryForm(PasswordManager, categoryToModified);
            pnlAddCategory.Controls.Add(Form);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                ModifyCategory_();
            }
            catch (ExceptionCategoryNotExists)
            {
                MessageBox.Show("The category does not exist", "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionCategoryHasInvalidNameLength exception)
            {
                MessageBox.Show(exception.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionCategoryAlreadyExists exception)
            {
                MessageBox.Show(exception.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ModifyCategory_()
        {
            string newName = Form.GetName();
            PasswordManager.CurrentUser.ModifyCategory(CategoryToModified, newName);
            GoBack();
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
