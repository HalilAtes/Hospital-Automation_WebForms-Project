using Business.Concrete;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web.UI.DataVisualization.Charting;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ZedGraph;

namespace Presentation_Layer
{
    public partial class BransaGöreHastaGraph : Form
    {
        public BransaGöreHastaGraph()
        {
            InitializeComponent();
        }

        private void bransaGoreHastaSayisiGetir_btn_Click(object sender, EventArgs e)
        {
           

            Dictionary<string, int> data1 = new Dictionary<string, int>();
            DoktorManager doktorManager = new DoktorManager(new HastaDal(),new KayitDal());
            data1 = doktorManager.GetPatientCountByBranch();

            chart1.Series.Clear();
            chart1.Series.Add("Hasta Sayısı");

            foreach (var item in data1)
            {
                chart1.Series["Hasta Sayısı"].Points.AddXY(item.Key, item.Value);
            }

            chart1.ChartAreas[0].AxisX.Title = "Branşlar";
            chart1.ChartAreas[0].AxisY.Title = "Hasta Sayısı";
            chart1.Titles.Add("Hastaların Branşlara Göre Dağılımı");
            chart1.Series["Hasta Sayısı"].ChartType = SeriesChartType.Column;





        }


        private void BransaGöreHastaGraph_Load(object sender, EventArgs e)
        {
            //comboBox1.DataSource = new List<string> { "Kardiyoloji", "Psikiyatri", "Genel Cerrahi", "Kulak-burun-boğaz", "Kadın hastalıkları", "Kadın doğum"
            //, "Üroloji" , "Dahiliye" , "Çocuk hastalıkları" , "Aile hekimi", "Dermatoloji", "Nöroloji", "Anatomi", "Radyoloji" };
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void geri_btn_Click(object sender, EventArgs e)
        {
            SekreterIslemleri sekreterislem = new SekreterIslemleri();
            sekreterislem.Show();
            this.Hide();
        }
    }
}
