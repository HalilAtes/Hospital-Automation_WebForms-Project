using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation_Layer
{
    public partial class HastaPdf : Form
    {
        public HastaPdf()
        {
            InitializeComponent();
        }
        private void verileri_goruntule()
        {
            DoktorManager doktorManager = new DoktorManager(new HastaDal(),new KayitDal());
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

        private void HastaGetir_btn_Click(object sender, EventArgs e)
        {
            verileri_goruntule();
        }

        private void HastaPdf_Load(object sender, EventArgs e)
        {

        }

        private void kaydıGetir_btn_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Hasta İd boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }
            DoktorManager doktorManager = new DoktorManager(new HastaDal(), new KayitDal());
            int hastaId = Convert.ToInt32(textBox3.Text);
            Kayit kayitNesne = doktorManager.GetKayitByHastaId(hastaId);
            textBox3.Text = kayitNesne.HastaId.ToString();
            textBox1.Text = kayitNesne.Gorus;
            textBox2.Text = kayitNesne.Sonuc;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Hasta İd boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Görüşme Kaydı boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Tahlil Sonucu boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
                return;
            }
            DoktorManager doktorManager = new DoktorManager(new HastaDal(), new KayitDal());
            int id = Convert.ToInt32(textBox3.Text);
            string gorus = textBox1.Text;
            string sonuc = textBox2.Text;
            Kayit updatedkayit = new Kayit { HastaId = id, Gorus = gorus, Sonuc = sonuc };
            doktorManager.UpdateKayit(updatedkayit);
            //verileri_goruntule();
            MessageBox.Show("Görüşme Kaydı Başarıyla Güncellendi!");
        }

        private void temizle_btn_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SekreterManager sekretermanager12 = new SekreterManager(new DoktorDal(), new HastaDal(), new SekreterDal());

            int idhasta1 = Convert.ToInt32(textBox3.Text);
            Hasta hasta12 = sekretermanager12.GetPatientById(idhasta1);
            string hastax = hasta12.Ad;
            
            string pdfFile = @"C:\Users\mazen\source\repos\Hastane_Otomasyon\Presentation_Layer\PDF\"+hastax+".pdf";

            // Create a new pdf document
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(pdfFile, FileMode.Create));
            doc.Open();

            // Add the text from the textbox to the pdf

            SekreterManager sekretermanager1 = new SekreterManager(new DoktorDal(), new HastaDal(), new SekreterDal());
            //int id = Convert.ToInt32(textBox4.Text);
            //Doktor doktor = sekretermanager1.GetDoctorById(id);
            //string doktorbilgi = "Doktor Bilgileri";
            //string doktorAd = doktor.Ad;
            //string doktorSoyad = doktor.Soyad;
            //string doktorBolum = doktor.Brans;

            string hastabilgi = "Hasta Bilgileri";
            int idhasta = Convert.ToInt32(textBox3.Text);
            Hasta hasta = sekretermanager1.GetPatientById(idhasta);
            string hastaAd = hasta.Ad;
            string hastaSoyad = hasta.Soyad;


            Paragraph para = new Paragraph();
            Chunk chunk1 = new Chunk(textBox1.Text);
            Chunk chunk1label = new Chunk(label1.Text);
            Chunk chunk2 = new Chunk(textBox2.Text);
            Chunk chunk2label = new Chunk(label2.Text);

            //Chunk chunkdoktorbilgi = new Chunk(doktorbilgi);
            //Chunk chunkdoktorAd = new Chunk(doktorAd);
            //Chunk chunkdoktorSoyad = new Chunk(doktorSoyad);
            //Chunk chunkdoktorBolum = new Chunk(doktorBolum);

            Chunk chunkhastabilgi = new Chunk(hastabilgi);
            Chunk chunkhastaAd = new Chunk(hastaAd);
            Chunk chunkhastaSoyad = new Chunk(hastaSoyad);

            para.Add(chunkhastabilgi);
            para.Add(Chunk.TABBING);
            para.Add(chunkhastaAd);
            para.Add(Chunk.TABBING);
            para.Add(chunkhastaSoyad);
            para.Add(Chunk.NEWLINE);
            para.Add(Chunk.NEWLINE);
            para.Add(Chunk.NEWLINE);

            //para.Add(chunkdoktorbilgi);
            //para.Add(Chunk.TABBING);
            //para.Add(chunkdoktorAd);
            //para.Add(Chunk.TABBING);
            //para.Add(chunkdoktorSoyad);
            //para.Add(Chunk.TABBING);
            //para.Add(chunkdoktorBolum);
            para.Add(Chunk.NEWLINE);
            para.Add(Chunk.NEWLINE);
            para.Add(Chunk.NEWLINE);

            para.Add(chunk1label);
            para.Add(Chunk.TABBING);
            para.Add(chunk1);
            para.Add(Chunk.NEWLINE);
            para.Add(Chunk.NEWLINE);
            para.Add(Chunk.NEWLINE);
            para.Add(chunk2label);
            para.Add(Chunk.TABBING);
            para.Add(chunk2);
            doc.Add(para);
            MessageBox.Show("Pdf başarıyla oluşturuldu!");

            doc.Close();
        }
        string DosyaYolu;
        private void button1_Click_1(object sender, EventArgs e)
        {
            SmtpClient sc = new SmtpClient();
            sc.Port = 587;
            sc.Host = "smtp.office365.com";
            sc.EnableSsl = true;


            string kime = "ateshalil1010@hotmail.com";
            string konu = "SELALEYKEE iBooo";
            string icerik = "cxbxcvcxvxcv";

            sc.Credentials = new NetworkCredential("ateshalil1010@hotmail.com", "ateshalil42");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("ateshalil1010@hotmail.com", "Halil Ateş");
            mail.To.Add(kime);
            //mail.To.Add("alici2@mail.com");
            mail.Subject = konu;
            mail.IsBodyHtml = true;
            mail.Body = icerik;
            //mail.Attachments.Add(new Attachment(DosyaYolu));
            sc.Send(mail);
        }

        private void DosyaEkle_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Title = "www.yazilimkodlama.com";
            dosya.ShowDialog();
            DosyaYolu = dosya.FileName;
            label3.Text = "Dosya Eklendi";
        }

        private void geri_btn_Click(object sender, EventArgs e)
        {
            Doktorİslemleri doktorislem = new Doktorİslemleri();
            doktorislem.Show();
            this.Hide();
        }

      
    }
}

