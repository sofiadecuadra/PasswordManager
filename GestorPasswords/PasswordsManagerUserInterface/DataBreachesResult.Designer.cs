
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
            this.listExposedCreditCards = new System.Windows.Forms.ListBox();
            this.lblExposedPasswords = new System.Windows.Forms.Label();
            this.lblExposedCreditCards = new System.Windows.Forms.Label();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.listExposedPasswords = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(716, 126);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(73, 25);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "Result";
            // 
            // listExposedCreditCards
            // 
            this.listExposedCreditCards.FormattingEnabled = true;
            this.listExposedCreditCards.ItemHeight = 25;
            this.listExposedCreditCards.Location = new System.Drawing.Point(194, 542);
            this.listExposedCreditCards.Name = "listExposedCreditCards";
            this.listExposedCreditCards.Size = new System.Drawing.Size(1130, 154);
            this.listExposedCreditCards.TabIndex = 2;
            // 
            // lblExposedPasswords
            // 
            this.lblExposedPasswords.AutoSize = true;
            this.lblExposedPasswords.Location = new System.Drawing.Point(194, 202);
            this.lblExposedPasswords.Name = "lblExposedPasswords";
            this.lblExposedPasswords.Size = new System.Drawing.Size(443, 25);
            this.lblExposedPasswords.TabIndex = 3;
            this.lblExposedPasswords.Text = "The following passwords have been exposed";
            // 
            // lblExposedCreditCards
            // 
            this.lblExposedCreditCards.AutoSize = true;
            this.lblExposedCreditCards.Location = new System.Drawing.Point(199, 490);
            this.lblExposedCreditCards.Name = "lblExposedCreditCards";
            this.lblExposedCreditCards.Size = new System.Drawing.Size(452, 25);
            this.lblExposedCreditCards.TabIndex = 4;
            this.lblExposedCreditCards.Text = "The following credit cards have been exposed";
            // 
            // btnGoBack
            // 
            this.btnGoBack.Location = new System.Drawing.Point(44, 44);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(149, 55);
            this.btnGoBack.TabIndex = 5;
            this.btnGoBack.Text = "←";
            this.btnGoBack.UseVisualStyleBackColor = true;
            // 
            // listExposedPasswords
            // 
            this.listExposedPasswords.FormattingEnabled = true;
            this.listExposedPasswords.ItemHeight = 25;
            this.listExposedPasswords.Location = new System.Drawing.Point(194, 253);
            this.listExposedPasswords.Name = "listExposedPasswords";
            this.listExposedPasswords.Size = new System.Drawing.Size(1130, 154);
            this.listExposedPasswords.TabIndex = 1;
            // 
            // DataBreachesResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.lblExposedCreditCards);
            this.Controls.Add(this.lblExposedPasswords);
            this.Controls.Add(this.listExposedCreditCards);
            this.Controls.Add(this.listExposedPasswords);
            this.Controls.Add(this.lblResult);
            this.Name = "DataBreachesResult";
            this.Size = new System.Drawing.Size(1608, 867);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.ListBox listExposedCreditCards;
        private System.Windows.Forms.Label lblExposedPasswords;
        private System.Windows.Forms.Label lblExposedCreditCards;
        private System.Windows.Forms.Button btnGoBack;
        private System.Windows.Forms.ListBox listExposedPasswords;
    }
}
