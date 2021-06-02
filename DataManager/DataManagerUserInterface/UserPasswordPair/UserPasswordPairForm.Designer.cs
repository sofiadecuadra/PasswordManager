
namespace PasswordsManagerUserInterface
{
    partial class UserPasswordPairForm
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
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.checkBoxSymbols = new System.Windows.Forms.CheckBox();
            this.checkBoxDigits = new System.Windows.Forms.CheckBox();
            this.checkBoxLowerCase = new System.Windows.Forms.CheckBox();
            this.checkBoxUpperCase = new System.Windows.Forms.CheckBox();
            this.numericUpDownLength = new System.Windows.Forms.NumericUpDown();
            this.lblLength = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtSite = new System.Windows.Forms.TextBox();
            this.lblSite = new System.Windows.Forms.Label();
            this.comboCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblPassword2 = new System.Windows.Forms.Label();
            this.checkBoxShow = new System.Windows.Forms.CheckBox();
            this.lblPasswordStrength = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLength)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(168, 587);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(4);
            this.txtNotes.MaxLength = 250;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(384, 123);
            this.txtNotes.TabIndex = 38;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(80, 604);
            this.lblNotes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(68, 25);
            this.lblNotes.TabIndex = 37;
            this.lblNotes.Text = "Notes";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(414, 510);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(142, 40);
            this.btnGenerate.TabIndex = 36;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // checkBoxSymbols
            // 
            this.checkBoxSymbols.AutoSize = true;
            this.checkBoxSymbols.Location = new System.Drawing.Point(332, 469);
            this.checkBoxSymbols.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxSymbols.Name = "checkBoxSymbols";
            this.checkBoxSymbols.Size = new System.Drawing.Size(126, 29);
            this.checkBoxSymbols.TabIndex = 35;
            this.checkBoxSymbols.Text = "Symbols";
            this.checkBoxSymbols.UseVisualStyleBackColor = true;
            // 
            // checkBoxDigits
            // 
            this.checkBoxDigits.AutoSize = true;
            this.checkBoxDigits.Location = new System.Drawing.Point(332, 429);
            this.checkBoxDigits.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxDigits.Name = "checkBoxDigits";
            this.checkBoxDigits.Size = new System.Drawing.Size(98, 29);
            this.checkBoxDigits.TabIndex = 34;
            this.checkBoxDigits.Text = "Digits";
            this.checkBoxDigits.UseVisualStyleBackColor = true;
            // 
            // checkBoxLowerCase
            // 
            this.checkBoxLowerCase.AutoSize = true;
            this.checkBoxLowerCase.Location = new System.Drawing.Point(332, 388);
            this.checkBoxLowerCase.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxLowerCase.Name = "checkBoxLowerCase";
            this.checkBoxLowerCase.Size = new System.Drawing.Size(158, 29);
            this.checkBoxLowerCase.TabIndex = 33;
            this.checkBoxLowerCase.Text = "Lower Case";
            this.checkBoxLowerCase.UseVisualStyleBackColor = true;
            // 
            // checkBoxUpperCase
            // 
            this.checkBoxUpperCase.AutoSize = true;
            this.checkBoxUpperCase.Location = new System.Drawing.Point(332, 348);
            this.checkBoxUpperCase.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxUpperCase.Name = "checkBoxUpperCase";
            this.checkBoxUpperCase.Size = new System.Drawing.Size(158, 29);
            this.checkBoxUpperCase.TabIndex = 32;
            this.checkBoxUpperCase.Text = "Upper Case";
            this.checkBoxUpperCase.UseVisualStyleBackColor = true;
            // 
            // numericUpDownLength
            // 
            this.numericUpDownLength.Location = new System.Drawing.Point(436, 292);
            this.numericUpDownLength.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownLength.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDownLength.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownLength.Name = "numericUpDownLength";
            this.numericUpDownLength.ReadOnly = true;
            this.numericUpDownLength.Size = new System.Drawing.Size(120, 31);
            this.numericUpDownLength.TabIndex = 31;
            this.numericUpDownLength.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(348, 296);
            this.lblLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(78, 25);
            this.lblLength.TabIndex = 30;
            this.lblLength.Text = "Length";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(168, 240);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.MaxLength = 25;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(384, 31);
            this.txtPassword.TabIndex = 29;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(40, 244);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(106, 25);
            this.lblPassword.TabIndex = 28;
            this.lblPassword.Text = "Password";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(168, 190);
            this.txtUser.Margin = new System.Windows.Forms.Padding(4);
            this.txtUser.MaxLength = 25;
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(384, 31);
            this.txtUser.TabIndex = 27;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(36, 190);
            this.lblUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(110, 25);
            this.lblUser.TabIndex = 26;
            this.lblUser.Text = "Username";
            // 
            // txtSite
            // 
            this.txtSite.Location = new System.Drawing.Point(168, 142);
            this.txtSite.Margin = new System.Windows.Forms.Padding(4);
            this.txtSite.MaxLength = 25;
            this.txtSite.Name = "txtSite";
            this.txtSite.Size = new System.Drawing.Size(384, 31);
            this.txtSite.TabIndex = 25;
            // 
            // lblSite
            // 
            this.lblSite.AutoSize = true;
            this.lblSite.Location = new System.Drawing.Point(76, 142);
            this.lblSite.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSite.Name = "lblSite";
            this.lblSite.Size = new System.Drawing.Size(49, 25);
            this.lblSite.TabIndex = 24;
            this.lblSite.Text = "Site";
            // 
            // comboCategory
            // 
            this.comboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCategory.FormattingEnabled = true;
            this.comboCategory.Location = new System.Drawing.Point(168, 94);
            this.comboCategory.Margin = new System.Windows.Forms.Padding(4);
            this.comboCategory.Name = "comboCategory";
            this.comboCategory.Size = new System.Drawing.Size(384, 33);
            this.comboCategory.TabIndex = 23;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(48, 102);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(99, 25);
            this.lblCategory.TabIndex = 22;
            this.lblCategory.Text = "Category";
            // 
            // lblPassword2
            // 
            this.lblPassword2.AutoSize = true;
            this.lblPassword2.Location = new System.Drawing.Point(242, 42);
            this.lblPassword2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword2.Name = "lblPassword2";
            this.lblPassword2.Size = new System.Drawing.Size(106, 25);
            this.lblPassword2.TabIndex = 21;
            this.lblPassword2.Text = "Password";
            // 
            // checkBoxShow
            // 
            this.checkBoxShow.AutoSize = true;
            this.checkBoxShow.Location = new System.Drawing.Point(600, 244);
            this.checkBoxShow.Margin = new System.Windows.Forms.Padding(6);
            this.checkBoxShow.Name = "checkBoxShow";
            this.checkBoxShow.Size = new System.Drawing.Size(97, 29);
            this.checkBoxShow.TabIndex = 39;
            this.checkBoxShow.Text = "Show";
            this.checkBoxShow.UseVisualStyleBackColor = true;
            this.checkBoxShow.CheckedChanged += new System.EventHandler(this.checkBoxShow_CheckedChanged);
            // 
            // lblPasswordStrength
            // 
            this.lblPasswordStrength.AutoSize = true;
            this.lblPasswordStrength.Location = new System.Drawing.Point(600, 279);
            this.lblPasswordStrength.Name = "lblPasswordStrength";
            this.lblPasswordStrength.Size = new System.Drawing.Size(36, 25);
            this.lblPasswordStrength.TabIndex = 41;
            this.lblPasswordStrength.Text = "    ";
            // 
            // UserPasswordPairForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPasswordStrength);
            this.Controls.Add(this.checkBoxShow);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.checkBoxSymbols);
            this.Controls.Add(this.checkBoxDigits);
            this.Controls.Add(this.checkBoxLowerCase);
            this.Controls.Add(this.checkBoxUpperCase);
            this.Controls.Add(this.numericUpDownLength);
            this.Controls.Add(this.lblLength);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.txtSite);
            this.Controls.Add(this.lblSite);
            this.Controls.Add(this.comboCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblPassword2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserPasswordPairForm";
            this.Size = new System.Drawing.Size(804, 748);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.CheckBox checkBoxSymbols;
        private System.Windows.Forms.CheckBox checkBoxDigits;
        private System.Windows.Forms.CheckBox checkBoxLowerCase;
        private System.Windows.Forms.CheckBox checkBoxUpperCase;
        private System.Windows.Forms.NumericUpDown numericUpDownLength;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtSite;
        private System.Windows.Forms.Label lblSite;
        private System.Windows.Forms.ComboBox comboCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblPassword2;
        private System.Windows.Forms.CheckBox checkBoxShow;
        private System.Windows.Forms.Label lblPasswordStrength;
    }
}
