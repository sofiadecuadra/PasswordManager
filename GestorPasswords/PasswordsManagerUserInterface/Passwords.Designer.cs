
namespace PasswordsManagerUserInterface
{
    partial class Passwords
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
            this.dgvPasswords = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnShare = new System.Windows.Forms.Button();
            this.btnUnshare = new System.Windows.Forms.Button();
            this.lblSharedWithYouPasswords = new System.Windows.Forms.Label();
            this.lblYourPasswords = new System.Windows.Forms.Label();
            this.btnPasswordsReport = new System.Windows.Forms.Button();
            this.dgvSharedPasswords = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasswords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSharedPasswords)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPasswords
            // 
            this.dgvPasswords.AllowUserToAddRows = false;
            this.dgvPasswords.AllowUserToDeleteRows = false;
            this.dgvPasswords.AllowUserToResizeColumns = false;
            this.dgvPasswords.AllowUserToResizeRows = false;
            this.dgvPasswords.ColumnHeadersHeight = 40;
            this.dgvPasswords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPasswords.Location = new System.Drawing.Point(53, 76);
            this.dgvPasswords.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvPasswords.MultiSelect = false;
            this.dgvPasswords.Name = "dgvPasswords";
            this.dgvPasswords.ReadOnly = true;
            this.dgvPasswords.RowHeadersVisible = false;
            this.dgvPasswords.RowHeadersWidth = 51;
            this.dgvPasswords.RowTemplate.Height = 24;
            this.dgvPasswords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvPasswords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPasswords.Size = new System.Drawing.Size(700, 177);
            this.dgvPasswords.TabIndex = 0;
            this.dgvPasswords.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPasswords_CellContentClick);
            // 
            // btnBack
            // 
            this.btnBack.AutoSize = true;
            this.btnBack.Location = new System.Drawing.Point(700, 15);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.Location = new System.Drawing.Point(476, 260);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.Location = new System.Drawing.Point(576, 260);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnModify
            // 
            this.btnModify.AutoSize = true;
            this.btnModify.Location = new System.Drawing.Point(678, 260);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 9;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnShare
            // 
            this.btnShare.AutoSize = true;
            this.btnShare.Location = new System.Drawing.Point(275, 260);
            this.btnShare.Margin = new System.Windows.Forms.Padding(4);
            this.btnShare.Name = "btnShare";
            this.btnShare.Size = new System.Drawing.Size(75, 23);
            this.btnShare.TabIndex = 11;
            this.btnShare.Text = "Share";
            this.btnShare.UseVisualStyleBackColor = true;
            this.btnShare.Click += new System.EventHandler(this.btnShare_Click);
            // 
            // btnUnshare
            // 
            this.btnUnshare.AutoSize = true;
            this.btnUnshare.Location = new System.Drawing.Point(377, 260);
            this.btnUnshare.Margin = new System.Windows.Forms.Padding(4);
            this.btnUnshare.Name = "btnUnshare";
            this.btnUnshare.Size = new System.Drawing.Size(75, 23);
            this.btnUnshare.TabIndex = 12;
            this.btnUnshare.Text = "Unshare";
            this.btnUnshare.UseVisualStyleBackColor = true;
            this.btnUnshare.Click += new System.EventHandler(this.btnUnshare_Click);
            // 
            // lblSharedWithYouPasswords
            // 
            this.lblSharedWithYouPasswords.AutoSize = true;
            this.lblSharedWithYouPasswords.Location = new System.Drawing.Point(50, 291);
            this.lblSharedWithYouPasswords.Name = "lblSharedWithYouPasswords";
            this.lblSharedWithYouPasswords.Size = new System.Drawing.Size(145, 13);
            this.lblSharedWithYouPasswords.TabIndex = 13;
            this.lblSharedWithYouPasswords.Text = "Passwords Shared With You:";
            // 
            // lblYourPasswords
            // 
            this.lblYourPasswords.AutoSize = true;
            this.lblYourPasswords.Location = new System.Drawing.Point(50, 60);
            this.lblYourPasswords.Name = "lblYourPasswords";
            this.lblYourPasswords.Size = new System.Drawing.Size(86, 13);
            this.lblYourPasswords.TabIndex = 14;
            this.lblYourPasswords.Text = "Your Passwords:";
            // 
            // btnPasswordsReport
            // 
            this.btnPasswordsReport.Location = new System.Drawing.Point(53, 15);
            this.btnPasswordsReport.Name = "btnPasswordsReport";
            this.btnPasswordsReport.Size = new System.Drawing.Size(132, 23);
            this.btnPasswordsReport.TabIndex = 15;
            this.btnPasswordsReport.Text = "Passwords Report";
            this.btnPasswordsReport.UseVisualStyleBackColor = true;
            this.btnPasswordsReport.Click += new System.EventHandler(this.btnPasswordsReport_Click);
            // 
            // dgvSharedPasswords
            // 
            this.dgvSharedPasswords.AllowUserToAddRows = false;
            this.dgvSharedPasswords.AllowUserToDeleteRows = false;
            this.dgvSharedPasswords.AllowUserToResizeColumns = false;
            this.dgvSharedPasswords.AllowUserToResizeRows = false;
            this.dgvSharedPasswords.ColumnHeadersHeight = 40;
            this.dgvSharedPasswords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSharedPasswords.Location = new System.Drawing.Point(53, 308);
            this.dgvSharedPasswords.MultiSelect = false;
            this.dgvSharedPasswords.Name = "dgvSharedPasswords";
            this.dgvSharedPasswords.ReadOnly = true;
            this.dgvSharedPasswords.RowHeadersVisible = false;
            this.dgvSharedPasswords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvSharedPasswords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSharedPasswords.Size = new System.Drawing.Size(700, 128);
            this.dgvSharedPasswords.TabIndex = 16;
            this.dgvSharedPasswords.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSharedPasswords_CellContentClick_1);
            // 
            // Passwords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvSharedPasswords);
            this.Controls.Add(this.btnPasswordsReport);
            this.Controls.Add(this.lblYourPasswords);
            this.Controls.Add(this.lblSharedWithYouPasswords);
            this.Controls.Add(this.btnUnshare);
            this.Controls.Add(this.btnShare);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dgvPasswords);
            this.Name = "Passwords";
            this.Size = new System.Drawing.Size(804, 451);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasswords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSharedPasswords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPasswords;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnShare;
        private System.Windows.Forms.Button btnUnshare;
        private System.Windows.Forms.Label lblSharedWithYouPasswords;
        private System.Windows.Forms.Label lblYourPasswords;
        private System.Windows.Forms.Button btnPasswordsReport;
        private System.Windows.Forms.DataGridView dgvSharedPasswords;
    }
}
