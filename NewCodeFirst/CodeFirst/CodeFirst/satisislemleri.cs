using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodeFirst.Entity;
namespace CodeFirst
{
    public partial class satisislemleri : Form
    {
        public satisislemleri()
        {
            InitializeComponent();
        }
        Context db = new Context();
        private void satisislemleri_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Musteri.ToList();
            dataGridView2.DataSource = db.Ev.Where(x => x.durum == "False").ToList();
            dataGridView3.DataSource = db.Satislar.ToList();
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

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                dataGridView3.Rows[e.RowIndex].Selected = true;
                tbsatis_id.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
                tbtckimlik.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
                tbev_id.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
                button2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string durum1 = "True";
                Satislar m = new Satislar();
                m.evid = tbev_id.Text;
                m.tc_kimlik = tbtckimlik.Text;
               // m.satis_id = tbsatis_id.Text;
                db.Satislar.Add(m);
                db.SaveChanges();
                dataGridView3.DataSource = db.Satislar.ToList();

                int ev_id = int.Parse(tbev_id.Text);
                var x = db.Ev.Find(ev_id);
                x.durum = "True";
                db.SaveChanges();
                dataGridView2.DataSource = db.Ev.Where(z => z.durum == "False").ToList();
                MessageBox.Show("Satış Başarılı Bir Şeklilde Yapıldı..");
            }
            catch
            {
                MessageBox.Show("Veya Aynı Ev Birden Fazla Kişiye Satılamaz...");
                tbsatis_id.Text = "";

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int satisno = int.Parse(tbsatis_id.Text.ToString());
            var x = db.Satislar.Find(satisno);
            db.Satislar.Remove(x);
            db.SaveChanges();
            dataGridView3.DataSource = db.Satislar.ToList();
            if (rbsad.Checked)
            {
                tbev_id.Text = aranan8.Text;
            }
            int ev_id = int.Parse(tbev_id.Text);
            var y = db.Ev.Find(ev_id);
            y.durum = "False";
            db.SaveChanges();
            dataGridView2.DataSource = db.Ev.Where(w => w.durum == "False").ToList();
            MessageBox.Show("Satış Başarılı Bir Şeklilde İptal Edildi...");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rbadi.Checked)
            {
                List<Musteri> liste1 = db.Musteri.OrderBy(p => p.ad).ToList();
                dataGridView1.DataSource = liste1;
            }
            if (rbsoyadi.Checked)
            {
                List<Musteri> liste2 = db.Musteri.OrderBy(p => p.soyad).ToList();
                dataGridView1.DataSource = liste2;
            }
            if (rbyasi.Checked)
            {
                List<Musteri> liste3 = db.Musteri.OrderBy(p => p.yas).ToList();
                dataGridView1.DataSource = liste3;
            }
        }

        private void aranan1_TextChanged(object sender, EventArgs e)
        {
            if (rbad.Checked)
            { //dataGridView1.DataSource = db.musteri.Where(x => x.ad == aranan1.Text).ToList();
                string aranan = aranan1.Text;
                var degerler = from item in db.Musteri
                               where item.ad.Contains(aranan)
                               select item;
                dataGridView1.DataSource = degerler.ToList();
            }
            else if (rbsoyad.Checked)
            {
                //dataGridView1.DataSource = db.musteri.Where(x => x.soyad == aranan1.Text).ToList(); 
                string aranan = aranan1.Text;
                var degerler = from item in db.Musteri
                               where item.soyad.Contains(aranan)
                               select item;
                dataGridView1.DataSource = degerler.ToList();
            }
            else if (rbtc.Checked)
            {
                //   dataGridView1.DataSource = db.musteri.Where(x => x.tckimlik == aranan1.Text).ToList();
                string aranan = aranan1.Text;
                var degerler = from item in db.Musteri
                               where item.tckimlik.Contains(aranan)
                               select item;
                dataGridView1.DataSource = degerler.ToList();
            }
            else
                MessageBox.Show("Bir Arama Kriteri Seçiniz...");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (rbfiyat.Checked)
            {
                List<Ev> liste1 = db.Ev.OrderBy(p => p.fiyat).ToList();
                dataGridView2.DataSource = liste1;
            }
            if (rboda.Checked)
            {
                List<Ev> liste2 = db.Ev.OrderBy(p => p.odasayisi).ToList();
                dataGridView2.DataSource = liste2;
            }
            if (rbmetre.Checked)
            {
                List<Ev> liste3 = db.Ev.OrderBy(p => p.metrekare).ToList();
                dataGridView2.DataSource = liste3;
            }
        }

        private void aranan2_TextChanged(object sender, EventArgs e)
        {
            if (rbadres.Checked)
            { //dataGridView1.DataSource = db.musteri.Where(x => x.ad == aranan1.Text).ToList();
                string aranan = aranan2.Text;
                var degerler = from item in db.Ev
                               where item.adres.Contains(aranan)
                               select item;
                dataGridView2.DataSource = degerler.ToList();
            }
            else if (rbisitma.Checked)
            {
                //dataGridView1.DataSource = db.musteri.Where(x => x.soyad == aranan1.Text).ToList(); 
                string aranan = aranan2.Text;
                var degerler = from item in db.Ev
                               where item.isitma.Contains(aranan)
                               select item;
                dataGridView2.DataSource = degerler.ToList();
            }
            else if (radioButton5.Checked)
            {
                //   dataGridView1.DataSource = db.musteri.Where(x => x.tckimlik == aranan1.Text).ToList();
                string aranan = aranan2.Text;
                var degerler = from item in db.Ev
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
                dataGridView3.DataSource = db.Satislar.Where(x => x.tc_kimlik == aranan8.Text).ToList();
            }
            else if (rbsad.Checked)
            {
                dataGridView3.DataSource = db.Satislar.Where(x => x.evid == aranan8.Text).ToList();
            }
        }
    }
}
