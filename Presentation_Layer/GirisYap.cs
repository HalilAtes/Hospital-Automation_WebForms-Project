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
    public partial class GirisYap : Form
    {
        public GirisYap()
        {
            InitializeComponent();
        }

        private void Giris_Yap_btn_Click(object sender, EventArgs e)
        {
            if (kullaniciAdi.Text == "m" && sifre.Text == "1")
            {
                SekreterIslemleri sekterislem = new SekreterIslemleri();
                sekterislem.Show();
                this.Hide();
            }
            else if (kullaniciAdi.Text == "z" && sifre.Text == "2")
            {
                Doktorİslemleri doktorislem = new Doktorİslemleri();
                doktorislem.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Lütfen kullanıcı adını ve şifrenizi kontrol ediniz!");
            }
            //SekreterIslemleri sekterislem = new SekreterIslemleri();
            //sekterislem.Show();
            //this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Doktorİslemleri girisSecim = new Doktorİslemleri();
            girisSecim.Show();
            this.Hide();
        }

        private void GirisYap_Load(object sender, EventArgs e)
        {

        }

        private void kapat_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
