using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbfirst
{
    public partial class satisislemleri : Form
    {
        public satisislemleri()
        {
            InitializeComponent();
        }
        dbemlakEntities2 db = new dbemlakEntities2();
        private void satisislemleri_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.musteri.ToList();
            dataGridView2.DataSource = db.satilmayan_evler();
            dataGridView3.DataSource = db.satilanlar();
            
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
                tbtckimlik.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                button2.Enabled = true;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                dataGridView2.Rows[e.RowIndex].Selected = true;
                tbev_id.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try {
                string durum1 = "True";
                satis m = new satis();
                m.ev_id = int.Parse(tbev_id.Text);
                m.tc_kimlik = tbtckimlik.Text;
               // m.satis_id = int.Parse(tbsatis_id.Text);
                db.satis.Add(m);
                db.SaveChanges();
                dataGridView3.DataSource = db.satilanlar();

                int ev_id = int.Parse(tbev_id.Text);
                var x = db.ev.Find(ev_id);
                x.durum = "True";
                db.SaveChanges();
                dataGridView2.DataSource = db.satilmayan_evler();
                MessageBox.Show("Satış Başarılı Bir Şeklilde Yapıldı..");
         }
            catch
            {
                MessageBox.Show("Aynı Satış Numarası İle Birden Fazla Kayıt Oluşturulamaz \nVeya Aynı Ev Birden Fazla Kişiye Satılamaz...");
                tbsatis_id.Text = "";
               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string durumm = "False";
                int satisno = int.Parse(tbsatis_id.Text);
                var x = db.satis.Find(satisno);
                db.satis.Remove(x);
                db.SaveChanges();
                dataGridView3.DataSource = db.satilanlar();
                if (rbsad.Checked)
                {
                    tbev_id.Text = aranan8.Text;
                }
                int ev_id = int.Parse(tbev_id.Text);
                var y = db.ev.Find(ev_id);
                y.durum = durumm;
                db.SaveChanges();
                dataGridView2.DataSource = db.satilmayan_evler();
                MessageBox.Show("Satış Başarılı Bir Şeklilde İptal Edildi...");
            
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                dataGridView3.Rows[e.RowIndex].Selected = true;
                tbsatis_id.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
                tbtckimlik.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
                tbev_id.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
                button2.Enabled = false;
            }
        }

        private void btnprodesur_Click(object sender, EventArgs e)
        {

        }

        private void btnbul_Click(object sender, EventArgs e)
        {
            if (rbad.Checked)
                dataGridView1.DataSource = db.musteri.Where(x => x.ad == aranan1.Text).ToList();
            else if (rbsoyad.Checked)
                dataGridView1.DataSource = db.musteri.Where(x => x.soyad == aranan1.Text).ToList();
            else if (rbtc.Checked)
                dataGridView1.DataSource = db.musteri.Where(x => x.tckimlik == aranan1.Text).ToList();
           
      

        }
        
        private void aranan1_TextChanged(object sender, EventArgs e)
        {
            if (rbad.Checked)
            { //dataGridView1.DataSource = db.musteri.Where(x => x.ad == aranan1.Text).ToList();
            string aranan = aranan1.Text;
            var degerler = from item in db.musteri
                           where item.ad.Contains(aranan)
                           select item;
            dataGridView1.DataSource = degerler.ToList();
            }
            else if (rbsoyad.Checked)
            { 
                //dataGridView1.DataSource = db.musteri.Where(x => x.soyad == aranan1.Text).ToList(); 
                string aranan = aranan1.Text;
                var degerler = from item in db.musteri
                               where item.soyad.Contains(aranan)
                               select item;
                dataGridView1.DataSource = degerler.ToList();
            }
            else if (rbtc.Checked)
            {
             //   dataGridView1.DataSource = db.musteri.Where(x => x.tckimlik == aranan1.Text).ToList();
                string aranan = aranan1.Text;
                var degerler = from item in db.musteri
                               where item.tckimlik.Contains(aranan)
                               select item;
                dataGridView1.DataSource = degerler.ToList();
            }
            else
                MessageBox.Show("Bir Arama Kriteri Seçiniz...");
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(rbfiyat.Checked)
            {
                List<ev> liste1=db.ev.OrderBy(p=>p.fiyat).ToList();
                dataGridView2.DataSource = liste1;
            }
            if (rboda.Checked)
            {
                List<ev> liste2 = db.ev.OrderBy(p => p.odasayisi).ToList();
                dataGridView2.DataSource = liste2;
            }
            if (rbmetre.Checked)
            {
                List<ev> liste3 = db.ev.OrderBy(p => p.metrekare).ToList();
                dataGridView2.DataSource = liste3;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rbadi.Checked)
            {
                List<musteri> liste1 = db.musteri.OrderBy(p => p.ad).ToList();
                dataGridView1.DataSource = liste1;
            }
            if (rbsoyadi.Checked)
            {
                List<musteri> liste2 = db.musteri.OrderBy(p => p.soyad).ToList();
                dataGridView1.DataSource = liste2;
            }
            if (rbyasi.Checked)
            {
                List<musteri> liste3 = db.musteri.OrderBy(p => p.yas).ToList();
                dataGridView1.DataSource = liste3;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (rbadres.Checked)
            { //dataGridView1.DataSource = db.musteri.Where(x => x.ad == aranan1.Text).ToList();
                string aranan = aranan2.Text;
                var degerler = from item in db.ev
                               where item.adres.Contains(aranan)
                               select item;
                dataGridView2.DataSource = degerler.ToList();
            }
            else if (rbisitma.Checked)
            {
                //dataGridView1.DataSource = db.musteri.Where(x => x.soyad == aranan1.Text).ToList(); 
                string aranan = aranan2.Text;
                var degerler = from item in db.ev
                               where item.isitma.Contains(aranan)
                               select item;
                dataGridView2.DataSource = degerler.ToList();
            }
            else if (radioButton5.Checked)
            {
                //   dataGridView1.DataSource = db.musteri.Where(x => x.tckimlik == aranan1.Text).ToList();
                string aranan = aranan2.Text;
                var degerler = from item in db.ev
                               where item.cephe.Contains(aranan)
                               select item;
                dataGridView2.DataSource = degerler.ToList();
            }
            else
                MessageBox.Show("Bir Arama Kriteri Seçiniz...");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (rbstc.Checked)
            {
                dataGridView3.DataSource = db.satis.Where(x => x.tc_kimlik == aranan8.Text).ToList();
            }
            else if(rbsad.Checked)
            {
                dataGridView3.DataSource = db.satis.Where(x => x.ev_id == int.Parse(aranan8.Text)).ToList();
            }
        }
    }
}
