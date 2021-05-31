
namespace PasswordsManagerUserInterface
{
    partial class DataBreachHistoryResult
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
            this.btnBack = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.dgvExposedCreditCards = new System.Windows.Forms.DataGridView();
            this.dgvNotModifiedPasswords = new System.Windows.Forms.DataGridView();
            this.lblExposedCreditCards = new System.Windows.Forms.Label();
            this.lblExposedPasswords = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.dgvModifiedPasswords = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExposedCreditCards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotModifiedPasswords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModifiedPasswords)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(1161, 37);
            this.btnBack.Margin = new System.Windows.Forms.Padding(6);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(346, 44);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "Back to data breaches history";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(80, 37);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(176, 44);
            this.btnMenu.TabIndex = 12;
            this.btnMenu.Text = "Back to Menu";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // dgvExposedCreditCards
            // 
            this.dgvExposedCreditCards.AllowUserToAddRows = false;
            this.dgvExposedCreditCards.AllowUserToDeleteRows = false;
            this.dgvExposedCreditCards.AllowUserToResizeColumns = false;
            this.dgvExposedCreditCards.AllowUserToResizeRows = false;
            this.dgvExposedCreditCards.ColumnHeadersHeight = 40;
            this.dgvExposedCreditCards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvExposedCreditCards.Location = new System.Drawing.Point(107, 627);
            this.dgvExposedCreditCards.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dgvExposedCreditCards.MultiSelect = false;
            this.dgvExposedCreditCards.Name = "dgvExposedCreditCards";
            this.dgvExposedCreditCards.ReadOnly = true;
            this.dgvExposedCreditCards.RowHeadersVisible = false;
            this.dgvExposedCreditCards.RowHeadersWidth = 51;
            this.dgvExposedCreditCards.RowTemplate.Height = 24;
            this.dgvExposedCreditCards.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvExposedCreditCards.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExposedCreditCards.Size = new System.Drawing.Size(1400, 214);
            this.dgvExposedCreditCards.TabIndex = 17;
            // 
            // dgvNotModifiedPasswords
            // 
            this.dgvNotModifiedPasswords.AllowUserToAddRows = false;
            this.dgvNotModifiedPasswords.AllowUserToDeleteRows = false;
            this.dgvNotModifiedPasswords.AllowUserToResizeColumns = false;
            this.dgvNotModifiedPasswords.AllowUserToResizeRows = false;
            this.dgvNotModifiedPasswords.ColumnHeadersHeight = 40;
            this.dgvNotModifiedPasswords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvNotModifiedPasswords.Location = new System.Drawing.Point(107, 167);
            this.dgvNotModifiedPasswords.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dgvNotModifiedPasswords.MultiSelect = false;
            this.dgvNotModifiedPasswords.Name = "dgvNotModifiedPasswords";
            this.dgvNotModifiedPasswords.ReadOnly = true;
            this.dgvNotModifiedPasswords.RowHeadersVisible = false;
            this.dgvNotModifiedPasswords.RowHeadersWidth = 51;
            this.dgvNotModifiedPasswords.RowTemplate.Height = 24;
            this.dgvNotModifiedPasswords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvNotModifiedPasswords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNotModifiedPasswords.Size = new System.Drawing.Size(1400, 163);
            this.dgvNotModifiedPasswords.TabIndex = 16;
            this.dgvNotModifiedPasswords.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExposedPasswords_CellContentClick);
            // 
            // lblExposedCreditCards
            // 
            this.lblExposedCreditCards.AutoSize = true;
            this.lblExposedCreditCards.Location = new System.Drawing.Point(102, 596);
            this.lblExposedCreditCards.Name = "lblExposedCreditCards";
            this.lblExposedCreditCards.Size = new System.Drawing.Size(214, 25);
            this.lblExposedCreditCards.TabIndex = 15;
            this.lblExposedCreditCards.Text = "Exposed credit cards";
            // 
            // lblExposedPasswords
            // 
            this.lblExposedPasswords.AutoSize = true;
            this.lblExposedPasswords.Location = new System.Drawing.Point(102, 136);
            this.lblExposedPasswords.Name = "lblExposedPasswords";
            this.lblExposedPasswords.Size = new System.Drawing.Size(477, 25);
            this.lblExposedPasswords.TabIndex = 14;
            this.lblExposedPasswords.Text = "Exposed passwords that have not been modified";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(755, 88);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(73, 25);
            this.lblResult.TabIndex = 13;
            this.lblResult.Text = "Result";
            // 
            // dgvModifiedPasswords
            // 
            this.dgvModifiedPasswords.AllowUserToAddRows = false;
            this.dgvModifiedPasswords.AllowUserToDeleteRows = false;
            this.dgvModifiedPasswords.AllowUserToResizeColumns = false;
            this.dgvModifiedPasswords.AllowUserToResizeRows = false;
            this.dgvModifiedPasswords.ColumnHeadersHeight = 40;
            this.dgvModifiedPasswords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvModifiedPasswords.Location = new System.Drawing.Point(107, 397);
            this.dgvModifiedPasswords.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dgvModifiedPasswords.MultiSelect = false;
            this.dgvModifiedPasswords.Name = "dgvModifiedPasswords";
            this.dgvModifiedPasswords.ReadOnly = true;
            this.dgvModifiedPasswords.RowHeadersVisible = false;
            this.dgvModifiedPasswords.RowHeadersWidth = 51;
            this.dgvModifiedPasswords.RowTemplate.Height = 24;
            this.dgvModifiedPasswords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvModifiedPasswords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvModifiedPasswords.Size = new System.Drawing.Size(1400, 163);
            this.dgvModifiedPasswords.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 366);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(441, 25);
            this.label1.TabIndex = 18;
            this.label1.Text = "Exposed passwords that have been modified";
            // 
            // DataBreachHistoryResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvModifiedPasswords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvExposedCreditCards);
            this.Controls.Add(this.dgvNotModifiedPasswords);
            this.Controls.Add(this.lblExposedCreditCards);
            this.Controls.Add(this.lblExposedPasswords);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnMenu);
            this.Name = "DataBreachHistoryResult";
            this.Size = new System.Drawing.Size(1608, 867);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExposedCreditCards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotModifiedPasswords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModifiedPasswords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.DataGridView dgvExposedCreditCards;
        private System.Windows.Forms.DataGridView dgvNotModifiedPasswords;
        private System.Windows.Forms.Label lblExposedCreditCards;
        private System.Windows.Forms.Label lblExposedPasswords;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.DataGridView dgvModifiedPasswords;
        private System.Windows.Forms.Label label1;
    }
}
