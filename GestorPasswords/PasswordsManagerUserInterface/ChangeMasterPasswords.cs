using GestorPasswordsDominio;
using System.Windows.Forms;

namespace PasswordsManagerUserInterface
{
    internal class ChangeMasterPasswords : UserControl
    {
        private PasswordManager passwordManager;
        private TextBox txtOldPassword;
        private Label lblOldPassword;
        private Label lblNewPassword;
        private TextBox txtNewPassword;
        private Button btnUpdateMasterPassword;
        private Button btnBack;
        private Panel pnlMainWindow;

        public ChangeMasterPasswords(PasswordManager passwordManager, Panel pnlMainWindow)
        {
            InitializeComponent();
            this.passwordManager = passwordManager;
            this.pnlMainWindow = pnlMainWindow;
        }

        private void InitializeComponent()
        {
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.lblOldPassword = new System.Windows.Forms.Label();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.btnUpdateMasterPassword = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.AccessibleDescription = "Insert your old master password here";
            this.txtOldPassword.AccessibleName = "Old Password";
            this.txtOldPassword.Location = new System.Drawing.Point(338, 185);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.PasswordChar = '*';
            this.txtOldPassword.Size = new System.Drawing.Size(231, 22);
            this.txtOldPassword.TabIndex = 0;
            // 
            // lblOldPassword
            // 
            this.lblOldPassword.AccessibleName = "Label for old password";
            this.lblOldPassword.AutoSize = true;
            this.lblOldPassword.Location = new System.Drawing.Point(207, 188);
            this.lblOldPassword.Name = "lblOldPassword";
            this.lblOldPassword.Size = new System.Drawing.Size(103, 17);
            this.lblOldPassword.TabIndex = 1;
            this.lblOldPassword.Text = "Old Password: ";
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AccessibleName = "Label for old password";
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Location = new System.Drawing.Point(207, 244);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(108, 17);
            this.lblNewPassword.TabIndex = 3;
            this.lblNewPassword.Text = "New Password: ";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.AccessibleDescription = "Insert your new master password here";
            this.txtNewPassword.AccessibleName = "New Password";
            this.txtNewPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtNewPassword.Location = new System.Drawing.Point(338, 241);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(231, 22);
            this.txtNewPassword.TabIndex = 2;
            // 
            // btnUpdateMasterPassword
            // 
            this.btnUpdateMasterPassword.Location = new System.Drawing.Point(338, 320);
            this.btnUpdateMasterPassword.Name = "btnUpdateMasterPassword";
            this.btnUpdateMasterPassword.Size = new System.Drawing.Size(231, 23);
            this.btnUpdateMasterPassword.TabIndex = 4;
            this.btnUpdateMasterPassword.Text = "Update";
            this.btnUpdateMasterPassword.UseVisualStyleBackColor = true;
            this.btnUpdateMasterPassword.Click += new System.EventHandler(this.btnUpdateMasterPassword_Click);
            // 
            // btnBack
            // 
            this.btnBack.AutoSize = true;
            this.btnBack.Location = new System.Drawing.Point(647, 23);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 28);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ChangeMasterPasswords
            // 
            this.AutoSize = true;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnUpdateMasterPassword);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.lblOldPassword);
            this.Controls.Add(this.txtOldPassword);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ChangeMasterPasswords";
            this.Size = new System.Drawing.Size(1072, 555);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnUpdateMasterPassword_Click(object sender, System.EventArgs e)
        {
            try
            {
                string oldPassword = txtOldPassword.Text;
                string newPassword = txtNewPassword.Text;
                passwordManager
                    .CurrentUser.ChangeMasterPassword(oldPassword, newPassword);
                GoBackToMainMenu();
            }
            catch (ExceptionIncorrectMasterPassword anException)
            {
                MessageBox.Show(anException.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionIncorrectLength anException)
            {
                MessageBox.Show(anException.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GoBackToMainMenu()
        {
            pnlMainWindow.Controls.Clear();
            UserControl menu = new Menu(passwordManager, pnlMainWindow);
            pnlMainWindow.Controls.Add(menu);
        }

        private void btnBack_Click(object sender, System.EventArgs e)
        {
            GoBackToMainMenu();
        }
    }
}
