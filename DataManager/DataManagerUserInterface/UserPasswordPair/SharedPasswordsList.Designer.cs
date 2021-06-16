
namespace PasswordsManagerUserInterface
{
    partial class SharedPasswordsList
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
            this.dgvSharedPasswords = new System.Windows.Forms.DataGridView();
            this.lblSharedPasswords = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnShare = new System.Windows.Forms.Button();
            this.btnUnshare = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSharedPasswords)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSharedPasswords
            // 
            this.dgvSharedPasswords.AllowUserToAddRows = false;
            this.dgvSharedPasswords.AllowUserToDeleteRows = false;
            this.dgvSharedPasswords.AllowUserToResizeColumns = false;
            this.dgvSharedPasswords.AllowUserToResizeRows = false;
            this.dgvSharedPasswords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSharedPasswords.Location = new System.Drawing.Point(55, 150);
            this.dgvSharedPasswords.MultiSelect = false;
            this.dgvSharedPasswords.Name = "dgvSharedPasswords";
            this.dgvSharedPasswords.ReadOnly = true;
            this.dgvSharedPasswords.RowHeadersVisible = false;
            this.dgvSharedPasswords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvSharedPasswords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSharedPasswords.Size = new System.Drawing.Size(700, 177);
            this.dgvSharedPasswords.TabIndex = 0;
            this.dgvSharedPasswords.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSharedPasswords_CellContentClick);
            // 
            // lblSharedPasswords
            // 
            this.lblSharedPasswords.AutoSize = true;
            this.lblSharedPasswords.Location = new System.Drawing.Point(55, 110);
            this.lblSharedPasswords.Name = "lblSharedPasswords";
            this.lblSharedPasswords.Size = new System.Drawing.Size(98, 13);
            this.lblSharedPasswords.TabIndex = 1;
            this.lblSharedPasswords.Text = "Shared Passwords:";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(672, 24);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnShare
            // 
            this.btnShare.Location = new System.Drawing.Point(266, 376);
            this.btnShare.Name = "btnShare";
            this.btnShare.Size = new System.Drawing.Size(75, 23);
            this.btnShare.TabIndex = 3;
            this.btnShare.Text = "Share";
            this.btnShare.UseVisualStyleBackColor = true;
            this.btnShare.Click += new System.EventHandler(this.btnShare_Click);
            // 
            // btnUnshare
            // 
            this.btnUnshare.Location = new System.Drawing.Point(476, 376);
            this.btnUnshare.Name = "btnUnshare";
            this.btnUnshare.Size = new System.Drawing.Size(75, 23);
            this.btnUnshare.TabIndex = 4;
            this.btnUnshare.Text = "Unshare";
            this.btnUnshare.UseVisualStyleBackColor = true;
            this.btnUnshare.Click += new System.EventHandler(this.btnUnshare_Click);
            // 
            // SharedPasswordsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnUnshare);
            this.Controls.Add(this.btnShare);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblSharedPasswords);
            this.Controls.Add(this.dgvSharedPasswords);
            this.Name = "SharedPasswordsList";
            this.Size = new System.Drawing.Size(804, 451);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSharedPasswords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSharedPasswords;
        private System.Windows.Forms.Label lblSharedPasswords;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnShare;
        private System.Windows.Forms.Button btnUnshare;
    }
}
