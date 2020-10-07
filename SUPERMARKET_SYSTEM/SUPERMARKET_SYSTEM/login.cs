using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;



namespace SUPERMARKET_SYSTEM
{
    public partial class login : Form
    {
        //LOGINBAR L = new LOGINBAR();
        OracleConnection CON1;
        OracleCommand CMD;
        string QUERY;
        OracleDataReader RDR;
        public login()
        {
            InitializeComponent();
            CON1 = new OracleConnection("Data Source=localhost;User ID=SUPERMARKET_SYSTEM;Password=SUPERMARKET_SYSTEM");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if ((TextBox1.Text == " ") || (TextBox2.Text == ""))
            {
                MessageBox.Show("Enter the username and password");
            }

            else
            {

                int FLAG = 0;
                string STR = "";

                QUERY = "select * from login where username ='" + TextBox1.Text + "' ";
                CMD = new OracleCommand(QUERY, CON1);

                CON1.Open();
                RDR = CMD.ExecuteReader();
                while (RDR.Read())
                {
                    STR = (string)RDR["password"];
                    FLAG = 1;
                }
                RDR.Close();

                CON1.Close();
                if (FLAG == 0)
                {
                    MessageBox.Show(" username doesnt exist");
                    clearform();

                }
                else if (TextBox2.Text == STR)
                {
                    //LOGINBAR op = new LOGINBAR();
                    //op.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Username and Password doesnt match.Please enter correct username and Password");
                    TextBox2.Text = " ";
                    TextBox2.Focus();
                }

            }

        }
        void clearform()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox1.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.login;
            TextBox1.Focus();
            var timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_tick);
            timer.Start();
        }
        void timer_tick(object sender ,EventArgs e)
        {
            List<Bitmap> listimage = new List<Bitmap>();

                listimage.Add(Properties.Resources.login);
            var indexbackimage = DateTime.Now.Second % listimage.Count;
            this.BackgroundImage = listimage[indexbackimage];
        }

        private void LOGINBAR_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            if (TextBox1.Text =="KUKI" && TextBox2.Text == "KUKI")
            { action a = new action();
                a.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Invalid password");
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
