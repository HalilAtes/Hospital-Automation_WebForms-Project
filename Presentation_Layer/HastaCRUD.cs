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
    public partial class HastaCRUD : Form
    {
        public HastaCRUD()
        {
            InitializeComponent();
        }
        private void verileri_goruntule()
        {
            DoktorManager doktorManager = new DoktorManager(new HastaDal(), new KayitDal());
            List<Hasta> hastalar = doktorManager.GetAllPatients();

            listView1.Items.Clear();
            foreach (Hasta hasta in hastalar)
            {
                ListViewItem item = new ListViewItem();
                item.Text = hasta.Id.ToString();
                item.SubItems.Add(hasta.Ad);
                item.SubItems.Add(hasta.Soyad);
                item.SubItems.Add(hasta.TelNo);
                item.SubItems.Add(hasta.GittigiBolum);
                listView1.Items.Add(item);
            }
        }

        private void hastalariGetir_btn_Click(object sender, EventArgs e)
        {
            verileri_goruntule();
        }

        private void hasta_ekle_btn_Click(object sender, EventArgs e)
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
            SekreterManager sekretermanager1 = new SekreterManager(new DoktorDal(), new HastaDal(), new SekreterDal());
            string ad = textBox1.Text;
            string soyad = textBox2.Text;
            string telNo = maskedTextBox1.Text;
            string bolum = comboBox1.SelectedValue.ToString();
            Hasta hasta = new Hasta { Ad = ad, Soyad = soyad, TelNo = telNo, GittigiBolum = bolum, };
            sekretermanager1.Add(hasta);
            verileri_goruntule();
            MessageBox.Show("Hasta Başarıyla Eklendi!");
        }

        private void HastaCRUD_Load(object sender, EventArgs e)
        {

            SekreterManager sekreterManager = new SekreterManager(new DoktorDal(), new HastaDal(), new SekreterDal());
            List<string> branslar = sekreterManager.GetBranches();
            comboBox1.DataSource = branslar;

        }

        private void guncelle_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Hasta İd boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }
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
            int id = Convert.ToInt32(textBox3.Text);
            SekreterManager sekretermanagercntrl1 = new SekreterManager(new DoktorDal(), new HastaDal(), new SekreterDal());
            bool varmi = sekretermanagercntrl1.CheckIfIdExistsPatient(id);
            if (varmi == false)
            {
                MessageBox.Show("Girdiğiniz İd'ye sahip bir Hasta bulunamadı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }
            if (true)
            {
                SekreterManager sekretermanager1 = new SekreterManager(new DoktorDal(), new HastaDal(), new SekreterDal());
                string ad = textBox1.Text;
                string soyad = textBox2.Text;
                string brans = comboBox1.SelectedValue.ToString();
                string telNo = maskedTextBox1.Text;
                Hasta updatedhasta = new Hasta { Id = id, Ad = ad, Soyad = soyad, GittigiBolum = brans, TelNo = telNo };
                sekretermanager1.UpdatePatient(updatedhasta);
                verileri_goruntule();
                MessageBox.Show("Hasta Başarıyla Güncellendi!");
            }
           
        }

        private void HastaGetir_btn_Click(object sender, EventArgs e)
        {
            SekreterManager sekretermanager1 = new SekreterManager(new DoktorDal(), new HastaDal(), new SekreterDal());

            int id = Convert.ToInt32(textBox3.Text);

            Hasta hasta = sekretermanager1.GetPatientById(id);
            if (hasta != null)
            {
                textBox3.Text = hasta.Id.ToString();
                textBox1.Text = hasta.Ad;
                textBox2.Text = hasta.Soyad;
                comboBox1.Text = hasta.GittigiBolum;
                maskedTextBox1.Text = hasta.TelNo;
            }
            else
            {
                MessageBox.Show("Bu Id'ye sahip bir hasta bulunamadı.");
            }
        }

        private void sil_btn_Click(object sender, EventArgs e)
        {
            if(textBox3.Text == null)
            {
                MessageBox.Show("Lütfen bir Id değeri giriniz!");
            }
            else
            {
                int id = Convert.ToInt32(textBox3.Text);
                SekreterManager sekretermanager1 = new SekreterManager(new DoktorDal(), new HastaDal(), new SekreterDal());
                sekretermanager1.DeletePatient(id);
                verileri_goruntule();
                MessageBox.Show("Hasta Başarıyla Silindi.");

            }
           
        }

        private void temizle_btn_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1;
            maskedTextBox1.Clear();
            textBox3.Clear();
        }

        private void geri_btn_Click(object sender, EventArgs e)
        {
            SekreterIslemleri sekreterislem = new SekreterIslemleri();
            sekreterislem.Show();
            this.Hide();
        }
    }
}
