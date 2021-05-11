
namespace PasswordsManagerUserInterface
{
    partial class DataBreachesResult
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
            this.lblResult = new System.Windows.Forms.Label();
            this.lblExposedPasswords = new System.Windows.Forms.Label();
            this.lblExposedCreditCards = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.dgvExposedPasswords = new System.Windows.Forms.DataGridView();
            this.dgvExposedCreditCards = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExposedPasswords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExposedCreditCards)).BeginInit();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(758, 90);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(73, 25);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "Result";
            // 
            // lblExposedPasswords
            // 
            this.lblExposedPasswords.AutoSize = true;
            this.lblExposedPasswords.Location = new System.Drawing.Point(114, 152);
            this.lblExposedPasswords.Name = "lblExposedPasswords";
            this.lblExposedPasswords.Size = new System.Drawing.Size(443, 25);
            this.lblExposedPasswords.TabIndex = 3;
            this.lblExposedPasswords.Text = "The following passwords have been exposed";
            // 
            // lblExposedCreditCards
            // 
            this.lblExposedCreditCards.AutoSize = true;
            this.lblExposedCreditCards.Location = new System.Drawing.Point(105, 498);
            this.lblExposedCreditCards.Name = "lblExposedCreditCards";
            this.lblExposedCreditCards.Size = new System.Drawing.Size(452, 25);
            this.lblExposedCreditCards.TabIndex = 4;
            this.lblExposedCreditCards.Text = "The following credit cards have been exposed";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(1212, 44);
            this.btnBack.Margin = new System.Windows.Forms.Padding(6);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(290, 44);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "Back to Data Breaches";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(110, 44);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(176, 44);
            this.btnMenu.TabIndex = 8;
            this.btnMenu.Text = "Back to Menu";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // dgvExposedPasswords
            // 
            this.dgvExposedPasswords.AllowUserToAddRows = false;
            this.dgvExposedPasswords.AllowUserToDeleteRows = false;
            this.dgvExposedPasswords.AllowUserToResizeColumns = false;
            this.dgvExposedPasswords.AllowUserToResizeRows = false;
            this.dgvExposedPasswords.ColumnHeadersHeight = 40;
            this.dgvExposedPasswords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvExposedPasswords.Location = new System.Drawing.Point(110, 183);
            this.dgvExposedPasswords.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dgvExposedPasswords.MultiSelect = false;
            this.dgvExposedPasswords.Name = "dgvExposedPasswords";
            this.dgvExposedPasswords.ReadOnly = true;
            this.dgvExposedPasswords.RowHeadersVisible = false;
            this.dgvExposedPasswords.RowHeadersWidth = 51;
            this.dgvExposedPasswords.RowTemplate.Height = 24;
            this.dgvExposedPasswords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvExposedPasswords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExposedPasswords.Size = new System.Drawing.Size(1400, 274);
            this.dgvExposedPasswords.TabIndex = 11;
            this.dgvExposedPasswords.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExposedPasswords_CellContentClick_1);
            // 
            // dgvExposedCreditCards
            // 
            this.dgvExposedCreditCards.AllowUserToAddRows = false;
            this.dgvExposedCreditCards.AllowUserToDeleteRows = false;
            this.dgvExposedCreditCards.AllowUserToResizeColumns = false;
            this.dgvExposedCreditCards.AllowUserToResizeRows = false;
            this.dgvExposedCreditCards.ColumnHeadersHeight = 40;
            this.dgvExposedCreditCards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvExposedCreditCards.Location = new System.Drawing.Point(110, 529);
            this.dgvExposedCreditCards.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dgvExposedCreditCards.MultiSelect = false;
            this.dgvExposedCreditCards.Name = "dgvExposedCreditCards";
            this.dgvExposedCreditCards.ReadOnly = true;
            this.dgvExposedCreditCards.RowHeadersVisible = false;
            this.dgvExposedCreditCards.RowHeadersWidth = 51;
            this.dgvExposedCreditCards.RowTemplate.Height = 24;
            this.dgvExposedCreditCards.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvExposedCreditCards.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExposedCreditCards.Size = new System.Drawing.Size(1400, 274);
            this.dgvExposedCreditCards.TabIndex = 12;
            // 
            // DataBreachesResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvExposedCreditCards);
            this.Controls.Add(this.dgvExposedPasswords);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblExposedCreditCards);
            this.Controls.Add(this.lblExposedPasswords);
            this.Controls.Add(this.lblResult);
            this.Name = "DataBreachesResult";
            this.Size = new System.Drawing.Size(1608, 867);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExposedPasswords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExposedCreditCards)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblExposedPasswords;
        private System.Windows.Forms.Label lblExposedCreditCards;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.DataGridView dgvExposedPasswords;
        private System.Windows.Forms.DataGridView dgvExposedCreditCards;
    }
}
