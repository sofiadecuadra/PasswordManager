
namespace PasswordsManagerUserInterface
{
    partial class ModifyCategory
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
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlAddCategory = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(369, 293);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(677, 22);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pnlAddCategory
            // 
            this.pnlAddCategory.Location = new System.Drawing.Point(303, 164);
            this.pnlAddCategory.Name = "pnlAddCategory";
            this.pnlAddCategory.Size = new System.Drawing.Size(200, 100);
            this.pnlAddCategory.TabIndex = 2;
            // 
            // ModifyCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlAddCategory);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAccept);
            this.Name = "ModifyCategory";
            this.Size = new System.Drawing.Size(804, 451);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel pnlAddCategory;
    }
}
