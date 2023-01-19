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
    public partial class Doktorİslemleri : Form
    {
        public Doktorİslemleri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void HastaListesi_btn_Click(object sender, EventArgs e)
        {
            HastaListesi hastalistesi = new HastaListesi();
            hastalistesi.Show();
            this.Hide();
        }

        private void gorusmekaydıgor_btn_Click(object sender, EventArgs e)
        {
            GorusmeKaydıAl gorusmekaydıal = new GorusmeKaydıAl();
            gorusmekaydıal.Show();
            this.Hide();

        }

        private void hastaPdf_btn_Click(object sender, EventArgs e)
        {
            HastaPdf hastaPdf = new HastaPdf();
            hastaPdf.Show();
            this.Hide();
        }

        private void geri_btn_Click(object sender, EventArgs e)
        {
            GirisYap girisyap = new GirisYap();
            girisyap.Show();
            this.Close();
        }
    }
}
