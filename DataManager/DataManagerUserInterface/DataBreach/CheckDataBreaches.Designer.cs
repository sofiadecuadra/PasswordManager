
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
            this.txtDataBreaches.Location = new System.Drawing.Point(209, 116);
            this.txtDataBreaches.Margin = new System.Windows.Forms.Padding(2);
            this.txtDataBreaches.Multiline = true;
            this.txtDataBreaches.Name = "txtDataBreaches";
            this.txtDataBreaches.Size = new System.Drawing.Size(394, 217);
            this.txtDataBreaches.TabIndex = 0;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(508, 357);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(2);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(94, 21);
            this.btnCheck.TabIndex = 1;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // lblExposedText
            // 
            this.lblExposedText.AutoSize = true;
            this.lblExposedText.Location = new System.Drawing.Point(206, 97);
            this.lblExposedText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblExposedText.Name = "lblExposedText";
            this.lblExposedText.Size = new System.Drawing.Size(72, 13);
            this.lblExposedText.TabIndex = 2;
            this.lblExposedText.Text = "Exposed Text";
            // 
            // lblDataBreaches
            // 
            this.lblDataBreaches.AutoSize = true;
            this.lblDataBreaches.Location = new System.Drawing.Point(370, 46);
            this.lblDataBreaches.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDataBreaches.Name = "lblDataBreaches";
            this.lblDataBreaches.Size = new System.Drawing.Size(78, 13);
            this.lblDataBreaches.TabIndex = 3;
            this.lblDataBreaches.Text = "Data Breaches";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(677, 22);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // CheckDataBreaches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblDataBreaches);
            this.Controls.Add(this.lblExposedText);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.txtDataBreaches);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CheckDataBreaches";
            this.Size = new System.Drawing.Size(804, 451);
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
