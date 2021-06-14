
namespace PasswordsManagerUserInterface
{
    partial class ChangeMasterPassword
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.lblOldPassword = new System.Windows.Forms.Label();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.btnUpdateMasterPassword = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Location = new System.Drawing.Point(338, 185);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.PasswordChar = '*';
            this.txtOldPassword.Size = new System.Drawing.Size(231, 20);
            this.txtOldPassword.TabIndex = 0;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(338, 241);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(231, 20);
            this.txtNewPassword.TabIndex = 1;
            // 
            // lblOldPassword
            // 
            this.lblOldPassword.AutoSize = true;
            this.lblOldPassword.Location = new System.Drawing.Point(207, 188);
            this.lblOldPassword.Name = "lblOldPassword";
            this.lblOldPassword.Size = new System.Drawing.Size(78, 13);
            this.lblOldPassword.TabIndex = 2;
            this.lblOldPassword.Text = "Old Password: ";
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Location = new System.Drawing.Point(207, 244);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(84, 13);
            this.lblNewPassword.TabIndex = 3;
            this.lblNewPassword.Text = "New Password: ";
            // 
            // btnUpdateMasterPassword
            // 
            this.btnUpdateMasterPassword.Location = new System.Drawing.Point(376, 322);
            this.btnUpdateMasterPassword.Name = "btnUpdateMasterPassword";
            this.btnUpdateMasterPassword.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateMasterPassword.TabIndex = 4;
            this.btnUpdateMasterPassword.Text = "Update";
            this.btnUpdateMasterPassword.UseVisualStyleBackColor = true;
            this.btnUpdateMasterPassword.Click += new System.EventHandler(this.btnUpdateMasterPassword_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(677, 22);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ChangeMasterPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnUpdateMasterPassword);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.lblOldPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.txtOldPassword);
            this.Name = "ChangeMasterPassword";
            this.Size = new System.Drawing.Size(804, 451);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label lblOldPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.Button btnUpdateMasterPassword;
        private System.Windows.Forms.Button btnBack;
    }
}
