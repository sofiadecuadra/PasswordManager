
namespace PasswordsManagerUserInterface
{
    partial class Menu
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
            this.btnPasswords = new System.Windows.Forms.Button();
            this.btnCreditCards = new System.Windows.Forms.Button();
            this.btnCategories = new System.Windows.Forms.Button();
            this.btnCheckDataBreaches = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChangeMasterPassword = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPasswords
            // 
            this.btnPasswords.CausesValidation = false;
            this.btnPasswords.Location = new System.Drawing.Point(277, 89);
            this.btnPasswords.Name = "btnPasswords";
            this.btnPasswords.Size = new System.Drawing.Size(263, 50);
            this.btnPasswords.TabIndex = 0;
            this.btnPasswords.Text = "Passwords";
            this.btnPasswords.UseVisualStyleBackColor = true;
            this.btnPasswords.Click += new System.EventHandler(this.btnPasswords_Click);
            // 
            // btnCreditCards
            // 
            this.btnCreditCards.Location = new System.Drawing.Point(277, 175);
            this.btnCreditCards.Name = "btnCreditCards";
            this.btnCreditCards.Size = new System.Drawing.Size(263, 50);
            this.btnCreditCards.TabIndex = 1;
            this.btnCreditCards.Text = "Credit Cards";
            this.btnCreditCards.UseVisualStyleBackColor = true;
            this.btnCreditCards.Click += new System.EventHandler(this.btnCreditCards_Click);
            // 
            // btnCategories
            // 
            this.btnCategories.Location = new System.Drawing.Point(277, 264);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Size = new System.Drawing.Size(263, 50);
            this.btnCategories.TabIndex = 2;
            this.btnCategories.Text = "Categories";
            this.btnCategories.UseVisualStyleBackColor = true;
            // 
            // btnCheckDataBreaches
            // 
            this.btnCheckDataBreaches.Location = new System.Drawing.Point(277, 352);
            this.btnCheckDataBreaches.Name = "btnCheckDataBreaches";
            this.btnCheckDataBreaches.Size = new System.Drawing.Size(263, 50);
            this.btnCheckDataBreaches.TabIndex = 3;
            this.btnCheckDataBreaches.Text = "Check Data Breaches";
            this.btnCheckDataBreaches.UseVisualStyleBackColor = true;
            this.btnCheckDataBreaches.Click += new System.EventHandler(this.btnCheckDataBreaches_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 4;
            // 
            // btnChangeMasterPassword
            // 
            this.btnChangeMasterPassword.Location = new System.Drawing.Point(40, 17);
            this.btnChangeMasterPassword.Name = "btnChangeMasterPassword";
            this.btnChangeMasterPassword.Size = new System.Drawing.Size(173, 31);
            this.btnChangeMasterPassword.TabIndex = 5;
            this.btnChangeMasterPassword.Text = "Change MasterPassword";
            this.btnChangeMasterPassword.UseVisualStyleBackColor = true;
            this.btnChangeMasterPassword.Click += new System.EventHandler(this.btnChangeMasterPassword_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(598, 17);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(173, 31);
            this.btnLogOut.TabIndex = 6;
            this.btnLogOut.Text = "Log out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnChangeMasterPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCheckDataBreaches);
            this.Controls.Add(this.btnCategories);
            this.Controls.Add(this.btnCreditCards);
            this.Controls.Add(this.btnPasswords);
            this.Name = "Menu";
            this.Size = new System.Drawing.Size(804, 451);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPasswords;
        private System.Windows.Forms.Button btnCreditCards;
        private System.Windows.Forms.Button btnCategories;
        private System.Windows.Forms.Button btnCheckDataBreaches;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChangeMasterPassword;
        private System.Windows.Forms.Button btnLogOut;
    }
}
