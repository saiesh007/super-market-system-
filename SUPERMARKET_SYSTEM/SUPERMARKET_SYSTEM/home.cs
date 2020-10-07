using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SUPERMARKET_SYSTEM
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            inventory i = new inventory();
            i.Show();
            Hide();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            product p = new product();
            p.Show();
            Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            billing b = new billing();
            b.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            action a = new action();
            a.Show();
            Hide();
        }
    }
}
