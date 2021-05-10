
namespace PasswordsManagerUserInterface
{
    partial class UnshareUserPasswordPair
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBack = new System.Windows.Forms.Button();
            this.btnUnshare = new System.Windows.Forms.Button();
            this.lblUnshare = new System.Windows.Forms.Label();
            this.comboUsers = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(652, 46);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(71, 21);
            this.btnBack.TabIndex = 42;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnUnshare
            // 
            this.btnUnshare.Location = new System.Drawing.Point(367, 282);
            this.btnUnshare.Margin = new System.Windows.Forms.Padding(2);
            this.btnUnshare.Name = "btnUnshare";
            this.btnUnshare.Size = new System.Drawing.Size(71, 21);
            this.btnUnshare.TabIndex = 41;
            this.btnUnshare.Text = "Unshare";
            this.btnUnshare.UseVisualStyleBackColor = true;
            this.btnUnshare.Click += new System.EventHandler(this.btnUnshare_Click);
            // 
            // lblUnshare
            // 
            this.lblUnshare.AutoSize = true;
            this.lblUnshare.Location = new System.Drawing.Point(181, 180);
            this.lblUnshare.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUnshare.Name = "lblUnshare";
            this.lblUnshare.Size = new System.Drawing.Size(157, 13);
            this.lblUnshare.TabIndex = 40;
            this.lblUnshare.Text = "Who to unshare your password:";
            // 
            // comboUsers
            // 
            this.comboUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboUsers.FormattingEnabled = true;
            this.comboUsers.Location = new System.Drawing.Point(340, 178);
            this.comboUsers.Margin = new System.Windows.Forms.Padding(2);
            this.comboUsers.Name = "comboUsers";
            this.comboUsers.Size = new System.Drawing.Size(155, 21);
            this.comboUsers.TabIndex = 39;
            // 
            // UnshareUserPasswordPair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnUnshare);
            this.Controls.Add(this.lblUnshare);
            this.Controls.Add(this.comboUsers);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UnshareUserPasswordPair";
            this.Size = new System.Drawing.Size(804, 451);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnUnshare;
        private System.Windows.Forms.Label lblUnshare;
        private System.Windows.Forms.ComboBox comboUsers;
    }
}
