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
    using Oracle.DataAccess.Client;


    public partial class add : Form
    {
        OracleConnection CON1;
        OracleCommand CMD;
        string QUERY;
        int TEMP, I;

        public add()
        {
            InitializeComponent();
            CON1 = new OracleConnection("Data Source=localhost;User ID=SUPERMARKET_SYSTEM;Password=SUPERMARKET_SYSTEM");
        }

        private void add_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            action a = new action();
            a.Show();
            Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox4.Text == "")
            {
                MessageBox.Show("Enter All the Details ");
            }
            else if (I == 1)
            {
                MessageBox.Show(" username exists");
                TextBox1.Text = " ";
                TextBox1.Focus();
            }
            else
            {
                CON1.Open();
                QUERY = "Insert into registration values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox4.Text + "')";
                CMD = new OracleCommand(QUERY, CON1);
                CMD.CommandType = CommandType.Text;
                try
                {
                    TEMP = CMD.ExecuteNonQuery();
                    if (TEMP > 0)

                        MessageBox.Show(" RECORD ADDED SUCESSFULLY");
                    else
                        MessageBox.Show("INSERT OPERATION FAILED ");
                }
                catch (Exception)
                {
                    MessageBox.Show("Employee ID already exists");
                }
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox4.Text = "";
                CON1.Close();
            }

        }
    }
}
    

//        private void button3_Click(object sender, EventArgs e)
//        {
//            if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox4.Text == "")
//            {
//                MessageBox.Show("Enter All the Details ");
//            }
//            else
//            {
//                CON1.Open();
//                QUERY = "Update registration Set PHONE_NO='" + TextBox4.Text + "', Where ID='" + TextBox1.Text + "'"; 
//                CMD = new OracleCommand(QUERY, CON1);
//                CMD.CommandType = CommandType.Text;
//                try
//                {
//                    TEMP = CMD.ExecuteNonQuery();
//                    if (TEMP > 0)

//                        MessageBox.Show(" RECORD updated SUCESSFULLY");
//                    else
//                        MessageBox.Show("update OPERATION FAILED ");
//                }
//                catch (Exception)
//                {
//                    MessageBox.Show("Employee ID already exists");
//                }
//                TextBox1.Text = "";
//                TextBox2.Text = "";
//                TextBox4.Text = "";
//            }

//        }

//    }

//}


            
        
   

       

