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
            DoktorManager doktorManager = new DoktorManager(new HastaDal(), new KayitDal());
            List<Hasta> hastalar = doktorManager.GetAllPatients();

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
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Hasta İsmi boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Hasta Soyİsmi boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(maskedTextBox1.Text) || (maskedTextBox1.Text.Length < 10))
            {
                MessageBox.Show("Telefon numarası boş olamaz ve en az 10 haneli olmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBox1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Doktor İd boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }
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
            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Hasta İd boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Doktor İd boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }
            DateTime currentDate = DateTime.Now;
            DateTime selectedDate = dateTimePicker1.Value;

            if (selectedDate > currentDate )
            {
                RandevuDal randevuDal = new RandevuDal();
                int HastaId = Convert.ToInt32(textBox6.Text);
                int DoktorId = Convert.ToInt32(textBox4.Text);
                //string tarih = Tarih.ToString();
                string brans = comboBox3.Text;
                randevuDal.Insert(HastaId, DoktorId, selectedDate);
                MessageBox.Show("Randevu Başarıyla Kaydedildi!");
            }
            else
            {
                MessageBox.Show("Lütfen ileri bir tarih seçiniz!");
            }
           
        }

      

        private void geri_btn_Click(object sender, EventArgs e)
        {
            SekreterIslemleri sekreterislem = new SekreterIslemleri();
            sekreterislem.Show();
            this.Hide();
        }

      
    }
}

