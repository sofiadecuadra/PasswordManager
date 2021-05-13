
namespace PasswordsManagerUserInterface
{
    partial class PasswordsReportPasswordsList
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
            this.dgvPasswordsOfColor = new System.Windows.Forms.DataGridView();
            this.lblPasswordsOfColor = new System.Windows.Forms.Label();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasswordsOfColor)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPasswordsOfColor
            // 
            this.dgvPasswordsOfColor.AllowUserToAddRows = false;
            this.dgvPasswordsOfColor.AllowUserToDeleteRows = false;
            this.dgvPasswordsOfColor.AllowUserToResizeColumns = false;
            this.dgvPasswordsOfColor.AllowUserToResizeRows = false;
            this.dgvPasswordsOfColor.ColumnHeadersHeight = 40;
            this.dgvPasswordsOfColor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPasswordsOfColor.Location = new System.Drawing.Point(55, 129);
            this.dgvPasswordsOfColor.MultiSelect = false;
            this.dgvPasswordsOfColor.Name = "dgvPasswordsOfColor";
            this.dgvPasswordsOfColor.ReadOnly = true;
            this.dgvPasswordsOfColor.RowHeadersVisible = false;
            this.dgvPasswordsOfColor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPasswordsOfColor.Size = new System.Drawing.Size(700, 188);
            this.dgvPasswordsOfColor.TabIndex = 0;
            this.dgvPasswordsOfColor.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPasswordsOfColor_CellContentClick);
            // 
            // lblPasswordsOfColor
            // 
            this.lblPasswordsOfColor.AutoSize = true;
            this.lblPasswordsOfColor.Location = new System.Drawing.Point(52, 99);
            this.lblPasswordsOfColor.Name = "lblPasswordsOfColor";
            this.lblPasswordsOfColor.Size = new System.Drawing.Size(70, 13);
            this.lblPasswordsOfColor.TabIndex = 1;
            this.lblPasswordsOfColor.Text = "... Passwords";
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(370, 358);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 2;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(700, 15);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // PasswordsReportPasswordsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.lblPasswordsOfColor);
            this.Controls.Add(this.dgvPasswordsOfColor);
            this.Name = "PasswordsReportPasswordsList";
            this.Size = new System.Drawing.Size(804, 451);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasswordsOfColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPasswordsOfColor;
        private System.Windows.Forms.Label lblPasswordsOfColor;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnBack;
    }
}
