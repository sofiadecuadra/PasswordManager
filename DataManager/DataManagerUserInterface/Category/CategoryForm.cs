﻿using System.Windows.Forms;
using DataManagerDomain;

namespace PasswordsManagerUserInterface
{
    public partial class CategoryForm : UserControl
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        public CategoryForm(Category categoryToModified)
        {
            InitializeComponent();
            txtName.Text = categoryToModified.Name;
        }

        public string GetName()
        {
            return txtName.Text;
        }
    }
}
