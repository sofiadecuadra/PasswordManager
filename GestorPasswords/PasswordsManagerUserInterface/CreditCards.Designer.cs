
namespace PasswordsManagerUserInterface
{
    partial class CreditCards
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.dgvCreditCards = new System.Windows.Forms.DataGridView();
            this.lblCreditCards = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCreditCards)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(464, 640);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 44);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(740, 640);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(150, 44);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(1016, 640);
            this.btnModify.Margin = new System.Windows.Forms.Padding(6);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(150, 44);
            this.btnModify.TabIndex = 3;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(1354, 42);
            this.btnBack.Margin = new System.Windows.Forms.Padding(6);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(150, 44);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dgvCreditCards
            // 
            this.dgvCreditCards.AllowUserToAddRows = false;
            this.dgvCreditCards.AllowUserToDeleteRows = false;
            this.dgvCreditCards.AllowUserToResizeColumns = false;
            this.dgvCreditCards.AllowUserToResizeRows = false;
            this.dgvCreditCards.ColumnHeadersHeight = 40;
            this.dgvCreditCards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCreditCards.Location = new System.Drawing.Point(98, 265);
            this.dgvCreditCards.Margin = new System.Windows.Forms.Padding(6);
            this.dgvCreditCards.MultiSelect = false;
            this.dgvCreditCards.Name = "dgvCreditCards";
            this.dgvCreditCards.ReadOnly = true;
            this.dgvCreditCards.RowHeadersVisible = false;
            this.dgvCreditCards.RowHeadersWidth = 82;
            this.dgvCreditCards.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCreditCards.Size = new System.Drawing.Size(1440, 288);
            this.dgvCreditCards.TabIndex = 5;
            this.dgvCreditCards.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCreditCards_CellContentClick);
            // 
            // lblCreditCards
            // 
            this.lblCreditCards.AutoSize = true;
            this.lblCreditCards.Location = new System.Drawing.Point(93, 234);
            this.lblCreditCards.Name = "lblCreditCards";
            this.lblCreditCards.Size = new System.Drawing.Size(190, 25);
            this.lblCreditCards.TabIndex = 6;
            this.lblCreditCards.Text = "Your Credit Cards:";
            // 
            // CreditCards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCreditCards);
            this.Controls.Add(this.dgvCreditCards);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "CreditCards";
            this.Size = new System.Drawing.Size(1608, 867);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCreditCards)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dgvCreditCards;
        private System.Windows.Forms.Label lblCreditCards;
    }
}
