using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirst
{
    public partial class acilis : Form
    {
        public acilis()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            musteriislemleri mi = new musteriislemleri();
            mi.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            evislemleri ei = new evislemleri();
            ei.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            satisislemleri si = new satisislemleri();
            si.ShowDialog();
        }
    }
}
