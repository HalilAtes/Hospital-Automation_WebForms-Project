using Business.Concrete;
using DataAccess.Abstract;
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
    public partial class DoktorCRUD : Form
    {
        public DoktorCRUD()
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
        private void doktorlariGetir_btn_Click(object sender, EventArgs e)
        {
                verileri_goruntule();


        }

        private void doktor_ekle_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Doktor İsmi boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Doktor Soyİsmi boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(maskedTextBox1.Text) || (maskedTextBox1.Text.Length < 10))
            {
                MessageBox.Show("Telefon numarası boş olamaz ve en az 10 haneli olmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBox1.Focus();
                return;
            }
            SekreterManager sekretermanager1 = new SekreterManager(new DoktorDal(), new HastaDal(), new SekreterDal());
            string ad = textBox1.Text;
            string soyad = textBox2.Text;
            string brans = comboBox1.SelectedValue.ToString();
            string telNo = maskedTextBox1.Text;
            Doktor doktor = new Doktor { Ad = ad, Soyad = soyad, Brans = brans , TelNo = telNo};
            sekretermanager1.Add(doktor);
            verileri_goruntule();
            MessageBox.Show("Doktor Başarıyla Eklendi!");
        }

        private void DoktorCRUD_Load(object sender, EventArgs e)
        {
            SekreterManager sekreterManager = new SekreterManager(new DoktorDal(), new HastaDal(), new SekreterDal());
            List<string> branslar = sekreterManager.GetBranches();
            comboBox1.DataSource = branslar;
        }

        private void guncelle_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Doktor İd boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Doktor İsmi boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Doktor Soyİsmi boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }
        
            if (string.IsNullOrWhiteSpace(maskedTextBox1.Text) || (maskedTextBox1.Text.Length < 10))
            {
                MessageBox.Show("Telefon numarası boş olamaz ve en az 10 haneli olmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBox1.Focus();
                return;
            }

            int id = Convert.ToInt32(textBox3.Text);
            SekreterManager sekretermanagercntrl1 = new SekreterManager(new DoktorDal(), new HastaDal(), new SekreterDal());
            bool varmi = sekretermanagercntrl1.CheckIfIdExistsDoctor(id);
            if (varmi == false)
            {
                MessageBox.Show("Girdiğiniz İd'ye sahip bir Doktor bulunamadı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }
            if (varmi == true)
            {
                SekreterManager sekretermanager1 = new SekreterManager(new DoktorDal(), new HastaDal(), new SekreterDal());
                string ad = textBox1.Text;
                string soyad = textBox2.Text;
                string brans = comboBox1.SelectedValue.ToString();
                string telNo = maskedTextBox1.Text;
                Doktor updatedDoktor = new Doktor { Id = id, Ad = ad, Soyad = soyad, Brans = brans, TelNo = telNo };
                sekretermanager1.Update(updatedDoktor);
                verileri_goruntule();
                MessageBox.Show("Doktor Başarıyla Güncellendi!");
            }
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox3.Text);
            SekreterManager sekretermanager1 = new SekreterManager(new DoktorDal(), new HastaDal(), new SekreterDal());
            sekretermanager1.Delete(id);
            verileri_goruntule();
            MessageBox.Show("Doktor Başarıyla Silindi.");
        }

        private void DoktorGetir_btn_Click(object sender, EventArgs e)
        {
            SekreterManager sekretermanager1 = new SekreterManager(new DoktorDal(), new HastaDal(), new SekreterDal());
            int id = Convert.ToInt32(textBox3.Text);
            Doktor doktor = sekretermanager1.GetDoctorById(id);
            if (doktor != null)
            {
                textBox3.Text = doktor.Id.ToString();
                textBox1.Text = doktor.Ad;
                textBox2.Text = doktor.Soyad;
                comboBox1.Text = doktor.Brans;
                maskedTextBox1.Text = doktor.TelNo;
            }
            else
            {
                MessageBox.Show("Bu Id'ye sahip bir doktor bulunamadı.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;
            maskedTextBox1.Clear();

        }

        private void geri_btn_Click(object sender, EventArgs e)
        {
            SekreterIslemleri sekreterislem = new SekreterIslemleri();
            sekreterislem.Show();
            this.Hide();
        }
    }
}
