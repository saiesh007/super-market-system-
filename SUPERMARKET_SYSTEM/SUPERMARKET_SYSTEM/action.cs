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
    public partial class action : Form
    {
        public action()
        {
            InitializeComponent();
        }

        private void action_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            add a = new add();
            a.Show();
            Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            delete d = new delete();
            d.Show();
            Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            home h = new home();
            h.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            update u = new update();
            u.Show();
            Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            view v = new view();
            v.Show();
            Hide();

        }
    }
}
