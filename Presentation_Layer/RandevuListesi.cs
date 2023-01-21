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

namespace Presentation_Layer
{
    public partial class RandevuListesi : Form
    {
        private HastaRandevuDoktorDal _randevuDal;

        public RandevuListesi()
        {
            InitializeComponent();
            _randevuDal = new HastaRandevuDoktorDal();
        }

        private void randevuGetir_btn_Click(object sender, EventArgs e)
        {

            List<HastaRandevuDoktor> hastaRandevuDoktorList = _randevuDal.GetHastaRandevuDoktor();

            foreach (HastaRandevuDoktor randevu in hastaRandevuDoktorList)
            {
                ListViewItem item = new ListViewItem(randevu.RandevuId.ToString());
                item.SubItems.Add(randevu.HastaAd);
                item.SubItems.Add(randevu.HastaSoyad);
                item.SubItems.Add(randevu.Bolum);
                item.SubItems.Add(randevu.TelNo);
                item.SubItems.Add(randevu.DoktorAd);
                item.SubItems.Add(randevu.DoktorSoyad);
                listView2.Items.Add(item);
            }



           
        }

        private void RandevuListesi_Load(object sender, EventArgs e)
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
