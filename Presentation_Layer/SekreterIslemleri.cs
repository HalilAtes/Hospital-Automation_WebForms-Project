using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation_Layer
{
    public partial class SekreterIslemleri : Form
    {
        public SekreterIslemleri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GirisYap girisyap = new GirisYap();
            girisyap.Show();
            this.Hide();
        }


        private void SekreterCrud_btn_Click(object sender, EventArgs e)
        {
            SekreterCRUD sekreterCrud = new SekreterCRUD();
            sekreterCrud.Show();
            this.Hide();
        }

        private void DoktorCrud_btn_Click(object sender, EventArgs e)
        {
            DoktorCRUD doktorCrud = new DoktorCRUD();
            doktorCrud.Show();
            this.Hide();
        }

        private void HastaCrud_btn_Click(object sender, EventArgs e)
        {
            HastaCRUD hastaCrud = new HastaCRUD();
            hastaCrud.Show();
            this.Hide();
        }

        private void RandevuAlma_btn_Click(object sender, EventArgs e)
        {
            RandevuIslemleri randevuislemleri = new RandevuIslemleri();
            randevuislemleri.Show();
            this.Hide();
        }


        private void bransagorehasta_btn_Click(object sender, EventArgs e)
        {
            BransaGöreHastaGraph bransagorehasta = new BransaGöreHastaGraph();
            bransagorehasta.Show();
            this.Hide();
        }

        private void SekreterIslemleri_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            RandevuListesi randevuList = new RandevuListesi();
            randevuList.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DoktoraGoreHastaSayısıGraph randevuList = new DoktoraGoreHastaSayısıGraph();
            randevuList.Show();
            this.Hide();
        }

       
    }
}
