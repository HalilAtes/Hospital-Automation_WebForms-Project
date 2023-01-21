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
    public partial class SekreterCRUD : Form
    {
        public SekreterCRUD()
        {
            InitializeComponent();
        }
        private void verileri_goruntule()
        {
            SekreterManager sekretermanager1 = new SekreterManager(new DoktorDal(), new HastaDal(), new SekreterDal());
            List<Sekreter> sekreterler = sekretermanager1.GetAllSecretary();

            listView1.Items.Clear();
            foreach (Sekreter sekreter in sekreterler)
            {
                ListViewItem item = new ListViewItem();
                item.Text = sekreter.Id.ToString();
                item.SubItems.Add(sekreter.Ad);
                item.SubItems.Add(sekreter.Soyad);
                item.SubItems.Add(sekreter.TelNo);
                listView1.Items.Add(item);
            }
        }

        private void SekreterCRUD_Load(object sender, EventArgs e)
        {

        }

        private void sekreter_ekle_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Sekreter İsmi boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Sekreter Soyİsmi boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(maskedTextBox1.Text) || (maskedTextBox1.Text.Length < 10))
            {
                MessageBox.Show("Telefon numarası boş olamaz ve en az 10 haneli olmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBox1.Focus();
                return;
            }
            else
            {
                SekreterManager sekretermanager1 = new SekreterManager(new DoktorDal(), new HastaDal(), new SekreterDal());
                string ad = textBox1.Text;
                string soyad = textBox2.Text;
                string telNo = maskedTextBox1.Text;
                Sekreter sekreter = new Sekreter { Ad = ad, Soyad = soyad, TelNo = telNo };
                sekretermanager1.AddSecretary(sekreter);
                verileri_goruntule();
                MessageBox.Show("Sekreter Başarıyla Eklendi!");
            }

        }

        private void guncelle_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Sekreter İd boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Sekreter İsmi boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Sekreter Soyİsmi boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }
            int id = Convert.ToInt32(textBox3.Text);
            SekreterManager sekretermanagercntrl1 = new SekreterManager(new DoktorDal(), new HastaDal(), new SekreterDal());
            bool varmi = sekretermanagercntrl1.CheckIfIdExistsSecreter(id);

            if (varmi == false)
            {
                MessageBox.Show("Girdiğiniz İd'ye sahip bir sekreter bulunamadı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }

            if (varmi == true)
            {
                SekreterManager sekretermanager1 = new SekreterManager(new DoktorDal(), new HastaDal(), new SekreterDal());
                string ad = textBox1.Text;
                string soyad = textBox2.Text;
                string telNo = maskedTextBox1.Text;
                Sekreter updatedsekreter = new Sekreter { Id = id, Ad = ad, Soyad = soyad, TelNo = telNo };
                sekretermanager1.UpdateSecretary(updatedsekreter);
                verileri_goruntule();
                MessageBox.Show("Sekreter Başarıyla Güncellendi!");
            }
           

        }

        private void sil_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Sekreter İd boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }
            int id = Convert.ToInt32(textBox3.Text);
            SekreterManager sekretermanagercntrl2 = new SekreterManager(new DoktorDal(), new HastaDal(), new SekreterDal());
            bool varmi = sekretermanagercntrl2.CheckIfIdExistsSecreter(id);
            if (varmi == true)
            {

                SekreterManager sekretermanager1 = new SekreterManager(new DoktorDal(), new HastaDal(), new SekreterDal());
                sekretermanager1.DeleteSecretary(id);
                verileri_goruntule();
                MessageBox.Show("Sekreter Başarıyla Silindi.");

            }
            else if (varmi == false)
            {
                MessageBox.Show("Girdiğiniz İd'ye sahip bir sekreter bulunamadı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }
        }

        private void SekreterGetir_btn_Click(object sender, EventArgs e)
        {
            SekreterManager sekretermanager1 = new SekreterManager(new DoktorDal(), new HastaDal(), new SekreterDal());

            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Sekreter İd boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }
            int id = Convert.ToInt32(textBox3.Text);

            Sekreter sekreter = sekretermanager1.GetSecretaryById(id);
            if (sekreter != null)
            {
                textBox3.Text = sekreter.Id.ToString();
                textBox1.Text = sekreter.Ad;
                textBox2.Text = sekreter.Soyad;
                maskedTextBox1.Text = sekreter.TelNo;
            }
            else
            {
                MessageBox.Show("Bu Id'ye sahip bir sekreter bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sekreterleriGetir_btn_Click(object sender, EventArgs e)
        {
            verileri_goruntule();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            maskedTextBox1.Clear();
        }

        private void geri_btn_Click(object sender, EventArgs e)
        {
            SekreterIslemleri sekreterislem = new SekreterIslemleri();
            sekreterislem.Show();
            this.Hide();
        }

        //private void maskedTextBox1_Validating(object sender, CancelEventArgs e)
        //{

        //    if (string.IsNullOrWhiteSpace(maskedTextBox1.Text) || maskedTextBox1.Text.Length < 10)
        //    {
        //        e.Cancel = true;
        //        errorProvider1.SetError(maskedTextBox1, "Telefon numarası boş olamaz ve en az 10 haneli olmalıdır!");
        //    }
        //    else
        //    {
        //        e.Cancel = false;
        //        errorProvider1.SetError(maskedTextBox1, "");
        //    }

        //}
    }
}




