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
    public partial class delete : Form
    {
        OracleConnection CON1;
        OracleCommand CMD;
        string QUERY;
        int TEMP, I;
        public delete()
        {
            InitializeComponent();
            CON1 = new OracleConnection("Data Source=localhost;User ID=SUPERMARKET_SYSTEM;Password=SUPERMARKET_SYSTEM");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            action a = new action();
            a.Show();
            Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
                if (TextBox1.Text == "")
                {
                    MessageBox.Show("Enter the id ");
                }

                else
                {
                DialogResult dr;
                dr = MessageBox.Show("ARE YOU SURE YOU WANT TO DELETE THE RECORD?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    CON1.Open();
                    QUERY = "delete from registration where EMP_ID=('" + TextBox1.Text + "')";
                    CMD = new OracleCommand(QUERY, CON1);
                    CMD.CommandType = CommandType.Text;
                    try
                    {
                        TEMP = CMD.ExecuteNonQuery();
                        if (TEMP > 0)

                            MessageBox.Show(" RECORD deleted SUCESSFULLY");
                        else
                            MessageBox.Show("delete OPERATION FAILED ");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Employee ID already exists");
                    }
                    TextBox1.Text = "";
                    CON1.Close();
                }
            }

            }
        
    }
}
