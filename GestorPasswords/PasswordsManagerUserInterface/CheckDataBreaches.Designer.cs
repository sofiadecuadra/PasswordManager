
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
            this.btnGoBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDataBreaches
            // 
            this.txtDataBreaches.Location = new System.Drawing.Point(224, 212);
            this.txtDataBreaches.Multiline = true;
            this.txtDataBreaches.Name = "txtDataBreaches";
            this.txtDataBreaches.Size = new System.Drawing.Size(1116, 413);
            this.txtDataBreaches.TabIndex = 0;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(1121, 674);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(219, 83);
            this.btnCheck.TabIndex = 1;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // lblExposedText
            // 
            this.lblExposedText.AutoSize = true;
            this.lblExposedText.Location = new System.Drawing.Point(219, 160);
            this.lblExposedText.Name = "lblExposedText";
            this.lblExposedText.Size = new System.Drawing.Size(144, 25);
            this.lblExposedText.TabIndex = 2;
            this.lblExposedText.Text = "Exposed Text";
            // 
            // lblDataBreaches
            // 
            this.lblDataBreaches.AutoSize = true;
            this.lblDataBreaches.Location = new System.Drawing.Point(682, 78);
            this.lblDataBreaches.Name = "lblDataBreaches";
            this.lblDataBreaches.Size = new System.Drawing.Size(154, 25);
            this.lblDataBreaches.TabIndex = 3;
            this.lblDataBreaches.Text = "Data Breaches";
            // 
            // btnGoBack
            // 
            this.btnGoBack.Location = new System.Drawing.Point(46, 48);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(149, 55);
            this.btnGoBack.TabIndex = 4;
            this.btnGoBack.Text = "←";
            this.btnGoBack.UseVisualStyleBackColor = true;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // CheckDataBreaches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnGoBack);
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
        private System.Windows.Forms.Button btnGoBack;
    }
}
