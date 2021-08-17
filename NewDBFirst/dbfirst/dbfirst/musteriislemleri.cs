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
    public partial class musteriislemleri : Form
    {
        public musteriislemleri()
        {
            InitializeComponent();
        }
        dbemlakEntities2 db = new dbemlakEntities2();
        private void musteriislemleri_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.musteri.ToList();
        }

        private void yeni_Click(object sender, EventArgs e)
        {
            tbadi.Text = "";
            tbadres.Text = "";
            tbmail.Text = "";
            tbsoyadi.Text = "";
            tbtc_kimlik.Text = "";
            tbtelefon.Text = "";
            tbyas.Text = "";
            tbtc_kimlik.Focus();
        }

        private void kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                int yas = int.Parse(tbyas.Text.ToString());
                musteri m = new musteri();
                m.ad = tbadi.Text;
                m.adres = tbadres.Text;
                m.email = tbmail.Text;
                m.soyad = tbsoyadi.Text;
                m.telefon = tbtelefon.Text;
                m.yas = yas;
                m.tckimlik = tbtc_kimlik.Text;
                db.musteri.Add(m);
                db.SaveChanges();
                dataGridView1.DataSource = db.musteri.ToList();
                MessageBox.Show("Kayıt Başarılı Bir Şeklilde Eklendi..");
            }
            catch
            {
                MessageBox.Show("Aynı Tc Kimlik Numarası İle Birden Fazla Kayıt Oluşturulamaz...");
                tbadi.Text = "";
                tbadres.Text = "";
                tbmail.Text = "";
                tbsoyadi.Text = "";
                tbtc_kimlik.Text = "";
                tbtelefon.Text = "";
                tbyas.Text = "";
                tbtc_kimlik.Focus();
            }
        }

        private void sil_Click(object sender, EventArgs e)
        {
            string tckimlik = tbtc_kimlik.Text.ToString();
            var x = db.musteri.Find(tckimlik);
            db.musteri.Remove(x);
            db.SaveChanges();
            dataGridView1.DataSource = db.musteri.ToList();
            MessageBox.Show("Müşteri Sistemden Silinmiştir.");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
                tbtc_kimlik.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                tbadi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                tbsoyadi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                tbadres.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                tbtelefon.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                tbmail.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                tbyas.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            }
        }

        private void duzenle_Click(object sender, EventArgs e)
        {
            
            string tckimlik = tbtc_kimlik.Text;
            var x = db.musteri.Find(tckimlik);
            x.tckimlik = tbtc_kimlik.Text;
            x.ad = tbadi.Text;
            x.adres = tbadres.Text;
            x.email = tbmail.Text;
            x.soyad = tbsoyadi.Text;
            x.telefon = tbtelefon.Text;
            x.yas = int.Parse(tbyas.Text.ToString());
            db.SaveChanges();
            dataGridView1.DataSource = db.musteri.ToList();
            MessageBox.Show("Müşteri Bilgileri Başarı İle Güncellendi...");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rbtc.Checked)
            {
                dataGridView1.DataSource = db.musteri.Where(x => x.tckimlik == textBox8.Text).ToList();
            }
            else if (rbad.Checked)
            {
                dataGridView1.DataSource = db.musteri.Where(x => x.ad == textBox8.Text).ToList();
            }
            else if (rbilk.Checked)
            {
                List<musteri> liste1 = db.musteri.OrderBy(p => p.ad).Take(5).ToList();
                dataGridView1.DataSource = liste1;
            }
            else if(rba_z.Checked)
            {
                List<musteri> liste2 = db.musteri.OrderBy(p => p.ad).ToList();
                dataGridView1.DataSource = liste2;
            }
        }
    }
}
