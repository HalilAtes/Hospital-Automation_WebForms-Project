using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Presentation_Layer
{
    public partial class DoktoraGoreHastaSayısıGraph : Form
    {
        public DoktoraGoreHastaSayısıGraph()
        {
            InitializeComponent();
        }
        private void verileri_goruntule()
        {
            SekreterManager sekretermanager1 = new SekreterManager(new DoktorDal(), new HastaDal(), new SekreterDal());
            List<Doktor> doktorlar = sekretermanager1.GetAllDoctors();

            listView1.Items.Clear();
            foreach (Doktor doktor in doktorlar)
            {
                ListViewItem item = new ListViewItem();
                item.Text = doktor.Id.ToString();
                item.SubItems.Add(doktor.Ad);
                item.SubItems.Add(doktor.Soyad);
                item.SubItems.Add(doktor.Brans);
                item.SubItems.Add(doktor.TelNo);
                listView1.Items.Add(item);
            }
        }

        private void doktoraGoreHastaSayisiGetir_btn_Click(object sender, EventArgs e)
        {
            DoktorManager doktorManager = new DoktorManager(new HastaDal(), new KayitDal());
            Dictionary<string, int> data1 = new Dictionary<string, int>();
            data1 = doktorManager.GetPatientCountByDoctor();
            chart1.Series.Clear();
            chart1.Series.Add("Hasta Sayısı");

            foreach (var item in data1)
            {
                chart1.Series["Hasta Sayısı"].Points.AddXY(item.Key, item.Value);
            }

            chart1.ChartAreas[0].AxisX.Title = "Doktorlar";
            chart1.ChartAreas[0].AxisY.Title = "Hasta Sayısı";
            chart1.Titles.Add("Hastaların Doktorlara Göre Dağılımı");
            chart1.Series["Hasta Sayısı"].ChartType = SeriesChartType.Column;
        }

        private void DoktoraGoreHastaSayısıGraph_Load(object sender, EventArgs e)
        {

        }

        private void doktorlariGetir_btn_Click(object sender, EventArgs e)
        {
            verileri_goruntule();
        }

        private void geri_btn_Click(object sender, EventArgs e)
        {
            SekreterIslemleri sekreterislem = new SekreterIslemleri();
            sekreterislem.Show();
            this.Hide();
        }
    }
}
