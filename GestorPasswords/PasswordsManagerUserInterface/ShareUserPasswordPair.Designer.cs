
namespace PasswordsManagerUserInterface
{
    partial class ShareUserPasswordPair
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
            this.lblShare = new System.Windows.Forms.Label();
            this.btnShare = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.comboUsers = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblShare
            // 
            this.lblShare.AutoSize = true;
            this.lblShare.Location = new System.Drawing.Point(258, 181);
            this.lblShare.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblShare.Name = "lblShare";
            this.lblShare.Size = new System.Drawing.Size(60, 13);
            this.lblShare.TabIndex = 25;
            this.lblShare.Text = "Share with:";
            // 
            // btnShare
            // 
            this.btnShare.Location = new System.Drawing.Point(367, 282);
            this.btnShare.Margin = new System.Windows.Forms.Padding(2);
            this.btnShare.Name = "btnShare";
            this.btnShare.Size = new System.Drawing.Size(71, 21);
            this.btnShare.TabIndex = 37;
            this.btnShare.Text = "Share";
            this.btnShare.UseVisualStyleBackColor = true;
            this.btnShare.Click += new System.EventHandler(this.btnShare_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(670, 38);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(71, 21);
            this.btnBack.TabIndex = 38;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // comboUsers
            // 
            this.comboUsers.FormattingEnabled = true;
            this.comboUsers.Location = new System.Drawing.Point(340, 178);
            this.comboUsers.Name = "comboUsers";
            this.comboUsers.Size = new System.Drawing.Size(155, 21);
            this.comboUsers.TabIndex = 39;
            // 
            // ShareUserPasswordPair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboUsers);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnShare);
            this.Controls.Add(this.lblShare);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ShareUserPasswordPair";
            this.Size = new System.Drawing.Size(804, 451);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblShare;
        private System.Windows.Forms.Button btnShare;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ComboBox comboUsers;
    }
}
