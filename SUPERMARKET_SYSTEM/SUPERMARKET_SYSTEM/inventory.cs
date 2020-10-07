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
    public partial class inventory : Form
    {
        OracleConnection CON1;
        OracleCommand CMD;
        OracleDataReader reader2;
        string QUERY;
        int TEMP, I;
        OracleDataAdapter da;
        DataSet d;
        public inventory()
        {
            InitializeComponent();
            CON1 = new OracleConnection("Data Source=localhost;User ID=SUPERMARKET_SYSTEM;Password=SUPERMARKET_SYSTEM");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            home h = new home();
            h.Show();
            Hide();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void inventory_Load(object sender, EventArgs e)
        {
            CON1 = new OracleConnection("Data Source=localhost;User ID=SUPERMARKET_SYSTEM;Password=SUPERMARKET_SYSTEM");
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = " dd-MMM-yyyy  ";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = " dd-MMM-yyyy  ";

        }
        
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            QUERY = "select * from INVENTORY where PRODUCT_ID='" + TextBox1.Text + "' ";
            CMD = new OracleCommand(QUERY, CON1);
            CON1.Open();
            reader2 = CMD.ExecuteReader();

            while (reader2.Read())
            {
                TextBox1.Text = Convert.ToString(reader2["PRODUCT_ID"]);
                TextBox2.Text = Convert.ToString(reader2["NAME_OF_PRODUCT"]);
                TextBox3.Text = Convert.ToString(reader2["QUANTITY"]);
                dateTimePicker1.Text = Convert.ToString(reader2["MFG_DATE"]);
                dateTimePicker2.Text = Convert.ToString(reader2["EXP_DATE"]);
                TextBox6.Text = Convert.ToString(reader2["PRICE"]);

            }
            reader2.Close();
            
            CON1.Close();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            QUERY = "select * from INVENTORY";
            CMD = new OracleCommand(QUERY, CON1);
            try
            {
                CON1.Open();
                da = new OracleDataAdapter(QUERY, CON1);
                d = new DataSet();
                da.Fill(d, "test");


                dataGridView1.DataSource = d.Tables[0];
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);

            }
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox6.Text = "";
            dateTimePicker1.Text = Convert.ToString(System.DateTime.Now);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = " dd-MMM-yyyy  ";
            dateTimePicker2.Text = Convert.ToString(System.DateTime.Now);
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = " dd-MMM-yyyy  ";


            CON1.Close();


        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox3.Text == "" || TextBox6.Text == ""|| dateTimePicker1.Text == ""|| dateTimePicker2.Text == "")
            {
                MessageBox.Show("Enter All the Details ");
            }
           
            else
            {
                QUERY = "Insert into INVENTORY values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + TextBox6.Text + "')";
                CMD = new OracleCommand(QUERY, CON1);
                CMD.CommandType = CommandType.Text;
                try
                {
                    CON1.Open();
                    CMD.ExecuteNonQuery();
                    MessageBox.Show("Record ADDED successfully", "MESSAGE");
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }

                finally
                {
                    CON1.Close();

                }
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox6.Text = "";
                dateTimePicker1.Text = Convert.ToString(System.DateTime.Now);
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = " dd-MMM-yyyy  ";
                dateTimePicker2.Text = Convert.ToString(System.DateTime.Now);
                dateTimePicker2.Format = DateTimePickerFormat.Custom;
                dateTimePicker2.CustomFormat = " dd-MMM-yyyy  ";



            }

        }

    }


}

        
