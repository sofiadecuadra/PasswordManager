
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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLength)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(84, 305);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNotes.MaxLength = 250;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(194, 66);
            this.txtNotes.TabIndex = 38;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(40, 314);
            this.lblNotes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(35, 13);
            this.lblNotes.TabIndex = 37;
            this.lblNotes.Text = "Notes";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(207, 265);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(71, 21);
            this.btnGenerate.TabIndex = 36;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // checkBoxSymbols
            // 
            this.checkBoxSymbols.AutoSize = true;
            this.checkBoxSymbols.Location = new System.Drawing.Point(166, 244);
            this.checkBoxSymbols.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxSymbols.Name = "checkBoxSymbols";
            this.checkBoxSymbols.Size = new System.Drawing.Size(65, 17);
            this.checkBoxSymbols.TabIndex = 35;
            this.checkBoxSymbols.Text = "Symbols";
            this.checkBoxSymbols.UseVisualStyleBackColor = true;
            // 
            // checkBoxDigits
            // 
            this.checkBoxDigits.AutoSize = true;
            this.checkBoxDigits.Location = new System.Drawing.Point(166, 223);
            this.checkBoxDigits.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxDigits.Name = "checkBoxDigits";
            this.checkBoxDigits.Size = new System.Drawing.Size(52, 17);
            this.checkBoxDigits.TabIndex = 34;
            this.checkBoxDigits.Text = "Digits";
            this.checkBoxDigits.UseVisualStyleBackColor = true;
            // 
            // checkBoxLowerCase
            // 
            this.checkBoxLowerCase.AutoSize = true;
            this.checkBoxLowerCase.Location = new System.Drawing.Point(166, 202);
            this.checkBoxLowerCase.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxLowerCase.Name = "checkBoxLowerCase";
            this.checkBoxLowerCase.Size = new System.Drawing.Size(82, 17);
            this.checkBoxLowerCase.TabIndex = 33;
            this.checkBoxLowerCase.Text = "Lower Case";
            this.checkBoxLowerCase.UseVisualStyleBackColor = true;
            // 
            // checkBoxUpperCase
            // 
            this.checkBoxUpperCase.AutoSize = true;
            this.checkBoxUpperCase.Location = new System.Drawing.Point(166, 181);
            this.checkBoxUpperCase.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxUpperCase.Name = "checkBoxUpperCase";
            this.checkBoxUpperCase.Size = new System.Drawing.Size(82, 17);
            this.checkBoxUpperCase.TabIndex = 32;
            this.checkBoxUpperCase.Text = "Upper Case";
            this.checkBoxUpperCase.UseVisualStyleBackColor = true;
            // 
            // numericUpDownLength
            // 
            this.numericUpDownLength.Location = new System.Drawing.Point(218, 152);
            this.numericUpDownLength.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.numericUpDownLength.Size = new System.Drawing.Size(60, 20);
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
            this.lblLength.Location = new System.Drawing.Point(163, 154);
            this.lblLength.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(40, 13);
            this.lblLength.TabIndex = 30;
            this.lblLength.Text = "Length";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(84, 125);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPassword.MaxLength = 25;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(194, 20);
            this.txtPassword.TabIndex = 29;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(20, 127);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 28;
            this.lblPassword.Text = "Password";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(84, 99);
            this.txtUser.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUser.MaxLength = 25;
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(194, 20);
            this.txtUser.TabIndex = 27;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(18, 99);
            this.lblUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(55, 13);
            this.lblUser.TabIndex = 26;
            this.lblUser.Text = "Username";
            // 
            // txtSite
            // 
            this.txtSite.Location = new System.Drawing.Point(84, 74);
            this.txtSite.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSite.MaxLength = 25;
            this.txtSite.Name = "txtSite";
            this.txtSite.Size = new System.Drawing.Size(194, 20);
            this.txtSite.TabIndex = 25;
            // 
            // lblSite
            // 
            this.lblSite.AutoSize = true;
            this.lblSite.Location = new System.Drawing.Point(38, 74);
            this.lblSite.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSite.Name = "lblSite";
            this.lblSite.Size = new System.Drawing.Size(25, 13);
            this.lblSite.TabIndex = 24;
            this.lblSite.Text = "Site";
            // 
            // comboCategory
            // 
            this.comboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCategory.FormattingEnabled = true;
            this.comboCategory.Location = new System.Drawing.Point(84, 49);
            this.comboCategory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboCategory.Name = "comboCategory";
            this.comboCategory.Size = new System.Drawing.Size(194, 21);
            this.comboCategory.TabIndex = 23;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(24, 53);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(49, 13);
            this.lblCategory.TabIndex = 22;
            this.lblCategory.Text = "Category";
            // 
            // lblPassword2
            // 
            this.lblPassword2.AutoSize = true;
            this.lblPassword2.Location = new System.Drawing.Point(121, 22);
            this.lblPassword2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPassword2.Name = "lblPassword2";
            this.lblPassword2.Size = new System.Drawing.Size(53, 13);
            this.lblPassword2.TabIndex = 21;
            this.lblPassword2.Text = "Password";
            // 
            // UserPasswordPairForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UserPasswordPairForm";
            this.Size = new System.Drawing.Size(295, 389);
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
    }
}
