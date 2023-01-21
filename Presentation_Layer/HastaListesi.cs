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
    public partial class HastaListesi : Form
    {  
        public HastaListesi()
        {
            InitializeComponent();
        }

        private void verileri_goruntule()
        {
            int doktorId = Convert.ToInt32(textBox3.Text);
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Doktor İd boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }
            DoktorManager doktorManager = new DoktorManager(new HastaDal(), new KayitDal());
            List<Hasta> hastalar = doktorManager.GetPatientsByDoctorId(doktorId);

            listView1.Items.Clear();
            foreach (Hasta hasta in hastalar)
            {
                ListViewItem item = new ListViewItem();
                item.Text = hasta.Ad.ToString();
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


        private void geri_btn_Click(object sender, EventArgs e)
        {
            Doktorİslemleri doktorislem = new Doktorİslemleri();
            doktorislem.Show();
            this.Hide();
        }

        private void HastaListesi_Load(object sender, EventArgs e)
        {

        }
    }
}
