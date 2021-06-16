using DataManagerDomain;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PasswordsManagerUserInterface
{
    public partial class SharedPasswordsList : UserControl
    {
        public DataManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        private readonly DataGridViewButtonColumn fullViewSharedPasswords;

        public SharedPasswordsList(DataManager aPasswordManager, Panel panel)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = panel;
            fullViewSharedPasswords = new DataGridViewButtonColumn();
            LoadSharedPasswords();
        }

        private void LoadSharedPasswords()
        {
            var userPasswordPairs = PasswordManager.
                CurrentUser.GetSharedUserPasswordPairs();
            LoadDataGridSharedPasswords(userPasswordPairs);
        }

        private void LoadDataGridSharedPasswords(UserPasswordPair[] userPasswordPairs)
        {
            SetColumnsQuantity();
            SetCategoryColumn();
            SetSiteColumn();
            SetUsernameColumn();
            SetLastModifiedColumn();
            SetFullViewColumn();
            dgvSharedPasswords.DataSource = userPasswordPairs;
            ChangeWidthWhenScrollBarIsVisible();
        }

        private void SetColumnsQuantity()
        {
            dgvSharedPasswords.AutoGenerateColumns = false;
            dgvSharedPasswords.ColumnCount = 4;
        }

        private void SetCategoryColumn()
        {
            dgvSharedPasswords.Columns[0].Name = "Category";
            dgvSharedPasswords.Columns[0].HeaderText = "Category";
            dgvSharedPasswords.Columns[0].DataPropertyName = "Category";
            dgvSharedPasswords.Columns[0].Width = 135;
        }

        private void SetSiteColumn()
        {
            dgvSharedPasswords.Columns[1].Name = "Site";
            dgvSharedPasswords.Columns[1].HeaderText = "Site";
            dgvSharedPasswords.Columns[1].DataPropertyName = "Site";
            dgvSharedPasswords.Columns[1].Width = 215;
        }

        private void SetUsernameColumn()
        {
            dgvSharedPasswords.Columns[2].Name = "User";
            dgvSharedPasswords.Columns[2].HeaderText = "User";
            dgvSharedPasswords.Columns[2].DataPropertyName = "Username";
            dgvSharedPasswords.Columns[2].Width = 215;
        }

        private void SetLastModifiedColumn()
        {
            dgvSharedPasswords.Columns[3].Name = "LastModified";
            dgvSharedPasswords.Columns[3].HeaderText = "Last Modified";
            dgvSharedPasswords.Columns[3].DataPropertyName = "LastModifiedDate";
            dgvSharedPasswords.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvSharedPasswords.Columns[3].Width = 70;
        }

        private void SetFullViewColumn()
        {
            dgvSharedPasswords.Columns.Add(fullViewSharedPasswords);
            fullViewSharedPasswords.HeaderText = @"";
            fullViewSharedPasswords.Name = "Full view";
            fullViewSharedPasswords.Text = "Full view";
            fullViewSharedPasswords.Width = 61;
            fullViewSharedPasswords.UseColumnTextForButtonValue = true;
        }

        private void ChangeWidthWhenScrollBarIsVisible()
        {
            if (dgvSharedPasswords.Controls.OfType<ScrollBar>().Last().Visible)
            {
                dgvSharedPasswords.Width = 717;
            }
        }

        private void btnShare_Click(object sender, EventArgs e)
        {

        }
    }
}
