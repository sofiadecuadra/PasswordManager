
namespace PasswordsManagerUserInterface
{
    partial class PasswordsStrengthChart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartPasswordsReport = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartPasswordsReport)).BeginInit();
            this.SuspendLayout();
            // 
            // chartPasswordsReport
            // 
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.Name = "ChartArea1";
            this.chartPasswordsReport.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartPasswordsReport.Legends.Add(legend1);
            this.chartPasswordsReport.Location = new System.Drawing.Point(66, 74);
            this.chartPasswordsReport.Name = "chartPasswordsReport";
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.Name = "Red";
            series1.ShadowColor = System.Drawing.Color.Red;
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series2.Legend = "Legend1";
            series2.Name = "Orange";
            series2.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series3.ChartArea = "ChartArea1";
            series3.Color = System.Drawing.Color.Yellow;
            series3.Legend = "Legend1";
            series3.Name = "Yellow";
            series3.ShadowColor = System.Drawing.Color.Yellow;
            series4.ChartArea = "ChartArea1";
            series4.Color = System.Drawing.Color.Lime;
            series4.Legend = "Legend1";
            series4.Name = "Light Green";
            series4.ShadowColor = System.Drawing.Color.Lime;
            series5.ChartArea = "ChartArea1";
            series5.Color = System.Drawing.Color.Green;
            series5.Legend = "Legend1";
            series5.Name = "Dark Green";
            series5.ShadowColor = System.Drawing.Color.SeaGreen;
            this.chartPasswordsReport.Series.Add(series1);
            this.chartPasswordsReport.Series.Add(series2);
            this.chartPasswordsReport.Series.Add(series3);
            this.chartPasswordsReport.Series.Add(series4);
            this.chartPasswordsReport.Series.Add(series5);
            this.chartPasswordsReport.Size = new System.Drawing.Size(669, 336);
            this.chartPasswordsReport.TabIndex = 0;
            this.chartPasswordsReport.Text = "chart1";
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
            // PasswordsStrengthChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.chartPasswordsReport);
            this.Name = "PasswordsStrengthChart";
            this.Size = new System.Drawing.Size(804, 451);
            ((System.ComponentModel.ISupportInitialize)(this.chartPasswordsReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartPasswordsReport;
        private System.Windows.Forms.Button btnBack;
    }
}
