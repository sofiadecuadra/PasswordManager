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
            Form = new CategoryForm(PasswordManager);
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
                MessageBox.Show(exception.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("The category already exists", "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void AddCategory_()
        {
            Category newCategory = CreateCategory();
            PasswordManager.CurrentUser.AddCategory(newCategory);
            GoBack();
        }

        private Category CreateCategory()
        {
            string name = Form.GetName();
            Category newCategory = new Category()
            {
                Name = name,
                User = PasswordManager.CurrentUser
            };

            return newCategory;
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
