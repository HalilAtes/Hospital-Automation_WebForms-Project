using DataAccess.Concrete;
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
    {   private SekreterDal _sekreterDal;
        public HastaListesi()
        {
            InitializeComponent();
            _sekreterDal = new SekreterDal();
        }

        private void verileri_goruntule()
        {
            int doktorId = Convert.ToInt32(textBox3.Text);
            List<string> hastalar = _sekreterDal.GetPatientsByDoctorId(doktorId);

            listView1.Items.Clear();
            int index = 0;
            foreach (string hasta in hastalar)
            {
                ListViewItem item = new ListViewItem((index + 1).ToString());
                item.SubItems.Add(hasta);
                listView1.Items.Add(item);
                index++;
            }
        }

        private void hastalariGetir_btn_Click(object sender, EventArgs e)
        {
            verileri_goruntule();
        }

        private void HastaListesi_Load(object sender, EventArgs e)
        {

        }

        private void geri_btn_Click(object sender, EventArgs e)
        {
            Doktorİslemleri doktorislem = new Doktorİslemleri();
            doktorislem.Show();
            this.Hide();
        }
    }
}
