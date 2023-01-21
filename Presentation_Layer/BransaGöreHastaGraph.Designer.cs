
namespace Presentation_Layer
{
    partial class BransaGöreHastaGraph
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BransaGöreHastaGraph));
            this.bransaGoreHastaSayisiGetir_btn = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.geri_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // bransaGoreHastaSayisiGetir_btn
            // 
            this.bransaGoreHastaSayisiGetir_btn.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.bransaGoreHastaSayisiGetir_btn.Font = new System.Drawing.Font("MV Boli", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bransaGoreHastaSayisiGetir_btn.Location = new System.Drawing.Point(70, 156);
            this.bransaGoreHastaSayisiGetir_btn.Name = "bransaGoreHastaSayisiGetir_btn";
            this.bransaGoreHastaSayisiGetir_btn.Size = new System.Drawing.Size(275, 34);
            this.bransaGoreHastaSayisiGetir_btn.TabIndex = 23;
            this.bransaGoreHastaSayisiGetir_btn.Text = "Hasta Sayısını Getir";
            this.bransaGoreHastaSayisiGetir_btn.UseVisualStyleBackColor = false;
            this.bransaGoreHastaSayisiGetir_btn.Click += new System.EventHandler(this.bransaGoreHastaSayisiGetir_btn_Click);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.DodgerBlue;
            this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.HorizontalCenter;
            this.chart1.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(70, 285);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1143, 448);
            this.chart1.TabIndex = 25;
            this.chart1.Text = "chart1";
            // 
            // geri_btn
            // 
            this.geri_btn.BackColor = System.Drawing.Color.OrangeRed;
            this.geri_btn.Font = new System.Drawing.Font("Ink Free", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.geri_btn.Location = new System.Drawing.Point(1097, 156);
            this.geri_btn.Name = "geri_btn";
            this.geri_btn.Size = new System.Drawing.Size(116, 34);
            this.geri_btn.TabIndex = 26;
            this.geri_btn.Text = "GERİ";
            this.geri_btn.UseVisualStyleBackColor = false;
            this.geri_btn.Click += new System.EventHandler(this.geri_btn_Click);
            // 
            // BransaGöreHastaGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1296, 819);
            this.Controls.Add(this.geri_btn);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.bransaGoreHastaSayisiGetir_btn);
            this.Name = "BransaGöreHastaGraph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BransaGöreHastaGraph";
            this.Load += new System.EventHandler(this.BransaGöreHastaGraph_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bransaGoreHastaSayisiGetir_btn;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button geri_btn;
    }
}