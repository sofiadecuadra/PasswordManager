
namespace PasswordsManagerUserInterface
{
    partial class PasswordsStrengthTable
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
            this.dgvPasswordsReport = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnChart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasswordsReport)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPasswordsReport
            // 
            this.dgvPasswordsReport.AllowUserToAddRows = false;
            this.dgvPasswordsReport.AllowUserToDeleteRows = false;
            this.dgvPasswordsReport.AllowUserToResizeColumns = false;
            this.dgvPasswordsReport.AllowUserToResizeRows = false;
            this.dgvPasswordsReport.ColumnHeadersHeight = 40;
            this.dgvPasswordsReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPasswordsReport.Location = new System.Drawing.Point(270, 123);
            this.dgvPasswordsReport.Name = "dgvPasswordsReport";
            this.dgvPasswordsReport.ReadOnly = true;
            this.dgvPasswordsReport.RowHeadersVisible = false;
            this.dgvPasswordsReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPasswordsReport.Size = new System.Drawing.Size(263, 192);
            this.dgvPasswordsReport.TabIndex = 0;
            this.dgvPasswordsReport.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPasswordsReport_CellContentClick);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(700, 15);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnChart
            // 
            this.btnChart.Location = new System.Drawing.Point(370, 358);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(75, 23);
            this.btnChart.TabIndex = 2;
            this.btnChart.Text = "See Chart";
            this.btnChart.UseVisualStyleBackColor = true;
            this.btnChart.Click += new System.EventHandler(this.btnChart_Click);
            // 
            // PasswordsStrengthReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnChart);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dgvPasswordsReport);
            this.Name = "PasswordsStrengthReport";
            this.Size = new System.Drawing.Size(804, 451);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasswordsReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPasswordsReport;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnChart;
    }
}
