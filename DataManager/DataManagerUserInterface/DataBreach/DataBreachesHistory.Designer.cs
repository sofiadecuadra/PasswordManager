
namespace PasswordsManagerUserInterface
{
    partial class DataBreachesHistory
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
            this.dgvDataBreaches = new System.Windows.Forms.DataGridView();
            this.lblDataBreachesHistory = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataBreaches)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDataBreaches
            // 
            this.dgvDataBreaches.AllowUserToAddRows = false;
            this.dgvDataBreaches.AllowUserToDeleteRows = false;
            this.dgvDataBreaches.AllowUserToResizeColumns = false;
            this.dgvDataBreaches.AllowUserToResizeRows = false;
            this.dgvDataBreaches.ColumnHeadersHeight = 40;
            this.dgvDataBreaches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDataBreaches.Location = new System.Drawing.Point(478, 186);
            this.dgvDataBreaches.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dgvDataBreaches.MultiSelect = false;
            this.dgvDataBreaches.Name = "dgvDataBreaches";
            this.dgvDataBreaches.ReadOnly = true;
            this.dgvDataBreaches.RowHeadersVisible = false;
            this.dgvDataBreaches.RowHeadersWidth = 51;
            this.dgvDataBreaches.RowTemplate.Height = 24;
            this.dgvDataBreaches.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDataBreaches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataBreaches.Size = new System.Drawing.Size(568, 550);
            this.dgvDataBreaches.TabIndex = 12;
            this.dgvDataBreaches.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataBreaches_CellContentClick);
            // 
            // lblDataBreachesHistory
            // 
            this.lblDataBreachesHistory.AutoSize = true;
            this.lblDataBreachesHistory.Location = new System.Drawing.Point(634, 130);
            this.lblDataBreachesHistory.Name = "lblDataBreachesHistory";
            this.lblDataBreachesHistory.Size = new System.Drawing.Size(222, 25);
            this.lblDataBreachesHistory.TabIndex = 13;
            this.lblDataBreachesHistory.Text = "Data breaches history";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(1230, 31);
            this.btnBack.Margin = new System.Windows.Forms.Padding(6);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(290, 44);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "Back to Data Breaches";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(80, 31);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(176, 44);
            this.btnMenu.TabIndex = 15;
            this.btnMenu.Text = "Back to Menu";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // DataBreachesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.lblDataBreachesHistory);
            this.Controls.Add(this.dgvDataBreaches);
            this.Name = "DataBreachesHistory";
            this.Size = new System.Drawing.Size(1608, 867);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataBreaches)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDataBreaches;
        private System.Windows.Forms.Label lblDataBreachesHistory;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnMenu;
    }
}
