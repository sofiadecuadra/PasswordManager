
namespace PasswordsManagerUserInterface
{
    partial class DataBreachesMethodSelection
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
            this.btnFillTextBox = new System.Windows.Forms.Button();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.lblMethodSelection = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblOr = new System.Windows.Forms.Label();
            this.dataBreachesOFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnDataBreachesHistory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFillTextBox
            // 
            this.btnFillTextBox.Location = new System.Drawing.Point(736, 304);
            this.btnFillTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnFillTextBox.Name = "btnFillTextBox";
            this.btnFillTextBox.Size = new System.Drawing.Size(150, 44);
            this.btnFillTextBox.TabIndex = 0;
            this.btnFillTextBox.Text = "Fill Textbox";
            this.btnFillTextBox.UseVisualStyleBackColor = true;
            this.btnFillTextBox.Click += new System.EventHandler(this.btnFillTextBox_Click);
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(736, 604);
            this.btnLoadFile.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(150, 44);
            this.btnLoadFile.TabIndex = 1;
            this.btnLoadFile.Text = "Load file";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // lblMethodSelection
            // 
            this.lblMethodSelection.AutoSize = true;
            this.lblMethodSelection.Location = new System.Drawing.Point(578, 127);
            this.lblMethodSelection.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblMethodSelection.Name = "lblMethodSelection";
            this.lblMethodSelection.Size = new System.Drawing.Size(467, 25);
            this.lblMethodSelection.TabIndex = 2;
            this.lblMethodSelection.Text = "How would you like to load Data Breach\'s data?";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(1354, 42);
            this.btnBack.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(150, 44);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblOr
            // 
            this.lblOr.AutoSize = true;
            this.lblOr.Location = new System.Drawing.Point(790, 465);
            this.lblOr.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblOr.Name = "lblOr";
            this.lblOr.Size = new System.Drawing.Size(35, 25);
            this.lblOr.TabIndex = 4;
            this.lblOr.Text = "Or";
            // 
            // dataBreachesOFileDialog
            // 
            this.dataBreachesOFileDialog.FileName = "File";
            this.dataBreachesOFileDialog.Filter = "txt files (*.txt)|*.txt";
            this.dataBreachesOFileDialog.InitialDirectory = "c:\\\\";
            // 
            // btnDataBreachesHistory
            // 
            this.btnDataBreachesHistory.Location = new System.Drawing.Point(78, 42);
            this.btnDataBreachesHistory.Name = "btnDataBreachesHistory";
            this.btnDataBreachesHistory.Size = new System.Drawing.Size(312, 44);
            this.btnDataBreachesHistory.TabIndex = 5;
            this.btnDataBreachesHistory.Text = "View data breaches history";
            this.btnDataBreachesHistory.UseVisualStyleBackColor = true;
            this.btnDataBreachesHistory.Click += new System.EventHandler(this.btnDataBreachesHistory_Click);
            // 
            // DataBreachesMethodSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDataBreachesHistory);
            this.Controls.Add(this.lblOr);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblMethodSelection);
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.btnFillTextBox);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "DataBreachesMethodSelection";
            this.Size = new System.Drawing.Size(1608, 867);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFillTextBox;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Label lblMethodSelection;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblOr;
        private System.Windows.Forms.OpenFileDialog dataBreachesOFileDialog;
        private System.Windows.Forms.Button btnDataBreachesHistory;
    }
}
