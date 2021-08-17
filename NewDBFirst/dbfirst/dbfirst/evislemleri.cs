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
    public partial class evislemleri : Form
    {
        public evislemleri()
        {
            InitializeComponent();
        }
        dbemlakEntities2 db = new dbemlakEntities2();
        private void evislemleri_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.ev.ToList();
           
        }

        private void yeni_Click(object sender, EventArgs e)
        {
            tbev_id.Text = "";
            tbadres.Text = "";
            tbbanyo.Text = "";
            tbcephe.Text = "";
            tbfiyat.Text = "";
            tbisitma.Text = "";
            tbkat.Text = "";
            tbmetrekare.Text = "";
            tboda.Text = "";
            tbev_id.Focus();
        }

        private void duzenle_Click(object sender, EventArgs e)
        {
            int  ev_id = int.Parse(tbev_id.Text);
            var x = db.ev.Find(ev_id); //**************
            x.adres = tbadres.Text;
            x.banyosayisi = int.Parse(tbbanyo.Text.ToString());
            x.cephe = tbcephe.Text;
            x.ev_id = int.Parse(tbev_id.Text);
            x.fiyat = int.Parse(tbfiyat.Text.ToString());
            x.isitma = tbisitma.Text;
            x.kat = int.Parse(tbkat.Text.ToString());
            x.metrekare = int.Parse(tbmetrekare.Text.ToString());
            x.odasayisi = int.Parse(tboda.Text.ToString());

            db.SaveChanges();
            dataGridView1.DataSource = db.ev.ToList();
            MessageBox.Show("Yeni Ev Başarılı Bir Şekilde Güncellendi");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
                tbev_id.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                tbadres.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                tbisitma.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                tbbanyo.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                tbfiyat.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                tbkat.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                tboda.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                tbcephe.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                tbmetrekare.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            }
        }

        private void kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                string durum1 = "False";
                ev x = new ev();
                x.adres = tbadres.Text;
                x.banyosayisi = int.Parse(tbbanyo.Text.ToString());
                x.cephe = tbcephe.Text;
               // x.ev_id = int.Parse(tbev_id.Text);
                x.fiyat = int.Parse(tbfiyat.Text.ToString());
                x.isitma = tbisitma.Text;
                x.kat = int.Parse(tbkat.Text.ToString());
                x.metrekare = int.Parse(tbmetrekare.Text.ToString());
                x.odasayisi = int.Parse(tboda.Text.ToString());
                x.durum = durum1;
                db.ev.Add(x);
                db.SaveChanges();
                dataGridView1.DataSource = db.ev.ToList();
                MessageBox.Show("Yeni Ev Başarılı Bir Şekilde Eklendi");
            }
            catch
            {
                MessageBox.Show("Aynı Ev_Id ile birden \nfazla kayıt oluşturulamaz !!! ");
            }
        }

        private void sil_Click(object sender, EventArgs e)
        {
            int ev_id = int.Parse(tbev_id.Text.ToString());
            var x = db.ev.Find(ev_id);
            db.ev.Remove(x);
            db.SaveChanges();
            dataGridView1.DataSource = db.ev.ToList();
            MessageBox.Show("Ev Sistemden Silinmiştir.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rbfiyat.Checked)
            {
                List<ev> liste2 = db.ev.OrderBy(p => p.fiyat).ToList();
                dataGridView1.DataSource = liste2;
            }
            else if (rbadres.Checked)
            {
                dataGridView1.DataSource = db.ev.Where(x => x.adres == textBox8.Text).ToList();
            }
            else if (rbcephe.Checked)
            {
                dataGridView1.DataSource = db.ev.Where(x => x.cephe == textBox8.Text).ToList();
            }
            else if (rbilk.Checked)
            {
                List<ev> liste2 = db.ev.OrderBy(p => p.ev_id).Take(5).ToList();
                dataGridView1.DataSource = liste2;
            }
            else if (rbsn.Checked)
            {
                dataGridView1.DataSource = db.ev.Where(x => x.durum == "False").ToList();
            }
            else if (rbsp.Checked)
            {
                dataGridView1.DataSource = db.ev.Where(x => x.durum == "True").ToList();
            }
        }
    }
}
