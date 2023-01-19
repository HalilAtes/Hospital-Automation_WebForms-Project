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
    public partial class RandevuIslemleri : Form
    {
        private RandevuDal _randevuDal;
        public RandevuIslemleri()
        {
            InitializeComponent();
            _randevuDal = new RandevuDal();
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

        private void bransagoredoktor_btn_Click(object sender, EventArgs e)
        {
            //string selectedBranch = comboBox2.SelectedItem.ToString();
            Hasta selectedItem = (Hasta)comboBox2.SelectedItem;
            string bolum = selectedItem.GittigiBolum;
            SekreterManager sekretermanager1 = new SekreterManager(new DoktorDal(), new HastaDal(), new SekreterDal());
            List<Doktor> doktorlar = sekretermanager1.GetDoctorsByBranch(bolum);
            listView1.Items.Clear();
            foreach (Doktor doktor in doktorlar)
            {
                ListViewItem item = new ListViewItem(doktor.Id.ToString());
                item.SubItems.Add(doktor.Ad);
                item.SubItems.Add(doktor.Soyad);
                item.SubItems.Add(doktor.Brans);
                listView1.Items.Add(item);
            }
        }



        private void RandevuIslemleri_Load(object sender, EventArgs e)
        {
            //SekreterManager sekreterManager = new SekreterManager(new DoktorDal(), new HastaDal(), new SekreterDal());
            //List<string> branslar = sekreterManager.GetBranches();
            //comboBox1.DataSource = branslar;
            //comboBox2.DataSource = branslar;
            //comboBox3.DataSource = branslar;
            SekreterDal _sekreterDal = new SekreterDal();
            comboBox1 = _sekreterDal.GetBranches(comboBox1);
            comboBox2 = _sekreterDal.GetBranches(comboBox2);
            comboBox3 = _sekreterDal.GetBranches(comboBox3);


        }

        private void HastaGetir_btn_Click(object sender, EventArgs e)
        {
            verileri_goruntule();

        }

        private void hastaEkle_btn_Click(object sender, EventArgs e)
        {
           
            SekreterManager sekretermanager1 = new SekreterManager(new DoktorDal(), new HastaDal(), new SekreterDal());
            string ad = textBox1.Text;
            string soyad = textBox2.Text;
            string telNo = maskedTextBox1.Text;
            Hasta selectedItem = (Hasta)comboBox1.SelectedItem;
            string bolum = selectedItem.GittigiBolum;
            int bolumId = selectedItem.bransId;
            int doktorId = Convert.ToInt32(textBox3.Text);
            Hasta hasta = new Hasta { Ad = ad, Soyad = soyad, TelNo = telNo, GittigiBolum = bolum, bransId = bolumId,doktorId = doktorId};
            sekretermanager1.Add(hasta);
            verileri_goruntule();
            MessageBox.Show("Hasta Başarıyla Eklendi!");
        }

        private void temizle_btn_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1;
            maskedTextBox1.Clear();
        }

        private void randevuKayıt_btn_Click(object sender, EventArgs e)
        {
            RandevuDal randevuDal = new RandevuDal();
            int HastaId = Convert.ToInt32(textBox6.Text);
            int DoktorId = Convert.ToInt32(textBox4.Text);
            DateTime Tarih = Convert.ToDateTime(maskedTextBox2.Text);
            //string tarih = Tarih.ToString();
            string brans = comboBox3.Text;
            randevuDal.Insert(HastaId, DoktorId, Tarih);
            MessageBox.Show("Randevu Başarıyla Kaydedildi!");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Hasta selectedItem = (Hasta)comboBox1.SelectedItem;
            //label6.Text = selectedItem.bransId.ToString();
        }

        private void geri_btn_Click(object sender, EventArgs e)
        {
            SekreterIslemleri sekreterislem = new SekreterIslemleri();
            sekreterislem.Show();
            this.Hide();
        }
    }
}

