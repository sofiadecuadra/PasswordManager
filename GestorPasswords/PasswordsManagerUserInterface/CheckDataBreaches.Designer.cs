
namespace PasswordsManagerUserInterface
{
    partial class CheckDataBreaches
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
            this.txtDataBreaches = new System.Windows.Forms.TextBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.lblExposedText = new System.Windows.Forms.Label();
            this.lblDataBreaches = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDataBreaches
            // 
            this.txtDataBreaches.Location = new System.Drawing.Point(418, 223);
            this.txtDataBreaches.Multiline = true;
            this.txtDataBreaches.Name = "txtDataBreaches";
            this.txtDataBreaches.Size = new System.Drawing.Size(784, 414);
            this.txtDataBreaches.TabIndex = 0;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(1015, 687);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(187, 41);
            this.btnCheck.TabIndex = 1;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // lblExposedText
            // 
            this.lblExposedText.AutoSize = true;
            this.lblExposedText.Location = new System.Drawing.Point(413, 186);
            this.lblExposedText.Name = "lblExposedText";
            this.lblExposedText.Size = new System.Drawing.Size(144, 25);
            this.lblExposedText.TabIndex = 2;
            this.lblExposedText.Text = "Exposed Text";
            // 
            // lblDataBreaches
            // 
            this.lblDataBreaches.AutoSize = true;
            this.lblDataBreaches.Location = new System.Drawing.Point(740, 88);
            this.lblDataBreaches.Name = "lblDataBreaches";
            this.lblDataBreaches.Size = new System.Drawing.Size(154, 25);
            this.lblDataBreaches.TabIndex = 3;
            this.lblDataBreaches.Text = "Data Breaches";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(1354, 43);
            this.btnBack.Margin = new System.Windows.Forms.Padding(6);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(150, 44);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // CheckDataBreaches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblDataBreaches);
            this.Controls.Add(this.lblExposedText);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.txtDataBreaches);
            this.Name = "CheckDataBreaches";
            this.Size = new System.Drawing.Size(1608, 867);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDataBreaches;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label lblExposedText;
        private System.Windows.Forms.Label lblDataBreaches;
        private System.Windows.Forms.Button btnBack;
    }
}
