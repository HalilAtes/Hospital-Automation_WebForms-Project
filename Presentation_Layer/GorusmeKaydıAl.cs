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

namespace Presentation_Layer
{
    public partial class GorusmeKaydıAl : Form
    {
        public GorusmeKaydıAl()
        {
            InitializeComponent();
        }
        private void verileri_goruntule()
        {
            SekreterManager sekretermanager1 = new SekreterManager(new DoktorDal(), new HastaDal(), new SekreterDal());
            List<Hasta> hastalar = sekretermanager1.GetAllPatients();

            listView2.Items.Clear();
            foreach (Hasta hasta in hastalar)
            {
                ListViewItem item = new ListViewItem();
                item.Text = hasta.Id.ToString();
                item.SubItems.Add(hasta.Ad);
                item.SubItems.Add(hasta.Soyad);
                item.SubItems.Add(hasta.TelNo);
                item.SubItems.Add(hasta.GittigiBolum);
                listView2.Items.Add(item);
            }
        }
        private void GorusmeKaydıAl_Load(object sender, EventArgs e)
        {
           
        }

        private void HastaGetir_btn_Click(object sender, EventArgs e)
        {
            verileri_goruntule();
        }

        private void temizle_btn_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void gorusKayıtEkle_btn_Click(object sender, EventArgs e)
        {
            RandevuDal randevuDal = new RandevuDal();
            int HastaId = Convert.ToInt32(textBox3.Text);
            string Gorus = textBox1.Text;
            string Sonuc = textBox2.Text;
            randevuDal.InsertGorus(HastaId, Gorus, Sonuc);
            MessageBox.Show("Görüşme Kaydı Başarıyla Kaydedildi!");
        }

        private void kayitGuncelle_btn_Click(object sender, EventArgs e)
        {
            KayitDal kayitDal = new KayitDal();
            int id = Convert.ToInt32(textBox3.Text);
            string gorus = textBox1.Text;
            string sonuc = textBox2.Text;
            Kayit updatedkayit = new Kayit { HastaId = id, Gorus = gorus, Sonuc = sonuc };
            kayitDal.UpdateKayit(updatedkayit);
            //verileri_goruntule();
            MessageBox.Show("Görüşme Kaydı Başarıyla Güncellendi!");
        }

        private void kaydıGetir_btn_Click(object sender, EventArgs e)
        {
            KayitDal kayitDal = new KayitDal();
            int hastaId = Convert.ToInt32(textBox3.Text);
            Kayit kayitNesne = kayitDal.GetKayitByHastaId(hastaId);
            textBox3.Text = kayitNesne.HastaId.ToString();
            textBox1.Text = kayitNesne.Gorus;
            textBox2.Text = kayitNesne.Sonuc;
        }

        private void geri_btn_Click(object sender, EventArgs e)
        {
            Doktorİslemleri doktorislem = new Doktorİslemleri();
            doktorislem.Show();
            this.Hide();
        }
    }
}
