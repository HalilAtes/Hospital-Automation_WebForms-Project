
namespace Presentation_Layer
{
    partial class RandevuListesi
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
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.randevuGetir_btn = new System.Windows.Forms.Button();
            this.geri_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView2
            // 
            this.listView2.BackColor = System.Drawing.Color.DarkTurquoise;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader1,
            this.columnHeader2});
            this.listView2.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            listViewGroup3.Header = "ListViewGroup";
            listViewGroup3.Name = "listViewGroup1";
            this.listView2.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3});
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(38, 274);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(897, 316);
            this.listView2.TabIndex = 8;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Randevu Id";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Hasta İsim";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Hasta Soyisim ";
            this.columnHeader7.Width = 120;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Hasta Telefon No";
            this.columnHeader8.Width = 140;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Randevu Branşı";
            this.columnHeader9.Width = 150;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Doktor Adı";
            this.columnHeader1.Width = 130;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Doktor Soyadı";
            this.columnHeader2.Width = 130;
            // 
            // randevuGetir_btn
            // 
            this.randevuGetir_btn.BackColor = System.Drawing.Color.DarkTurquoise;
            this.randevuGetir_btn.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.randevuGetir_btn.Location = new System.Drawing.Point(38, 196);
            this.randevuGetir_btn.Name = "randevuGetir_btn";
            this.randevuGetir_btn.Size = new System.Drawing.Size(275, 29);
            this.randevuGetir_btn.TabIndex = 22;
            this.randevuGetir_btn.Text = "Randevuları Getir";
            this.randevuGetir_btn.UseVisualStyleBackColor = false;
            this.randevuGetir_btn.Click += new System.EventHandler(this.randevuGetir_btn_Click);
            // 
            // geri_btn
            // 
            this.geri_btn.BackColor = System.Drawing.Color.OrangeRed;
            this.geri_btn.Font = new System.Drawing.Font("Ink Free", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.geri_btn.Location = new System.Drawing.Point(819, 191);
            this.geri_btn.Name = "geri_btn";
            this.geri_btn.Size = new System.Drawing.Size(116, 34);
            this.geri_btn.TabIndex = 23;
            this.geri_btn.Text = "GERİ";
            this.geri_btn.UseVisualStyleBackColor = false;
            this.geri_btn.Click += new System.EventHandler(this.geri_btn_Click);
            // 
            // RandevuListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 819);
            this.Controls.Add(this.geri_btn);
            this.Controls.Add(this.randevuGetir_btn);
            this.Controls.Add(this.listView2);
            this.Name = "RandevuListesi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RandevuListesi";
            this.Load += new System.EventHandler(this.RandevuListesi_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button randevuGetir_btn;
        private System.Windows.Forms.Button geri_btn;
    }
}