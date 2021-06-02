
namespace PasswordsManagerUserInterface
{
    partial class AddUserPasswordPair
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
            this.pnlAddUserPasswordPair = new System.Windows.Forms.Panel();
            this.btnAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.AutoSize = true;
            this.btnBack.Location = new System.Drawing.Point(1396, 29);
            this.btnBack.Margin = new System.Windows.Forms.Padding(6);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(150, 44);
            this.btnBack.TabIndex = 18;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pnlAddUserPasswordPair
            // 
            this.pnlAddUserPasswordPair.Location = new System.Drawing.Point(456, 29);
            this.pnlAddUserPasswordPair.Margin = new System.Windows.Forms.Padding(4);
            this.pnlAddUserPasswordPair.Name = "pnlAddUserPasswordPair";
            this.pnlAddUserPasswordPair.Size = new System.Drawing.Size(804, 748);
            this.pnlAddUserPasswordPair.TabIndex = 20;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(762, 806);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(4);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(148, 38);
            this.btnAccept.TabIndex = 40;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click_1);
            // 
            // AddUserPasswordPair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.pnlAddUserPasswordPair);
            this.Controls.Add(this.btnBack);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddUserPasswordPair";
            this.Size = new System.Drawing.Size(1608, 867);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel pnlAddUserPasswordPair;
        private System.Windows.Forms.Button btnAccept;
    }
}
