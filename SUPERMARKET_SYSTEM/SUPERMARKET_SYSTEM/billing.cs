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
    public partial class billing : Form
    {
        OracleConnection CON1;
        OracleCommand CMD;
        OracleDataReader reader2;
        string QUERY;
        int TEMP, I;
        OracleDataAdapter da;
        DataSet d;

        public billing()
        {
            InitializeComponent();
           // CON1 = new OracleConnection("Data Source=localhost;User ID=SUPERMARKET_SYSTEM;Password=SUPERMARKET_SYSTEM");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            home h = new home();
            h.Show();
            Hide();
        }

        private void billing_Load(object sender, EventArgs e)
        {
            FillComboBox();
            textBox2.Text = "";
            comboBox1.Text = "";
            textBox3.Text = "";
            dateTimePicker1.Text = Convert.ToString(System.DateTime.Now);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = " dd-MMM-yyyy  ";
            dateTimePicker2.Text = Convert.ToString(System.DateTime.Now);
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = " dd-MMM-yyyy  ";

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        protected void FillComboBox()
        {
            CON1 = new OracleConnection(" Data Source=localhost;User ID=SUPERMARKET_SYSTEM;Password=SUPERMARKET_SYSTEM");

            DataSet d = new DataSet();
            try
            {
                CON1.Open();
                OracleCommand cmd = new OracleCommand("select NAME_OF_PRODUCT from INVENTORY ORDER BY PRODUCT_ID", CON1);
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(d);
                comboBox1.DisplayMember = "NAME_OF_PRODUCT";
                comboBox1.ValueMember = "PRODUCT_ID";
                comboBox1.DataSource = d.Tables[0];
            }
            catch (Exception e)
            {

            }
            finally
            {
                CON1.Close();
                CON1.Dispose();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string search;
            CON1 = new OracleConnection("Data Source=localhost;User ID=SUPERMARKET_SYSTEM;Password=SUPERMARKET_SYSTEM");
            OracleDataReader reader2;
            search = "select * from INVENTORY where NAME_OF_PRODUCT ='" + comboBox1.Text + "' ";
            CMD = new OracleCommand(search, CON1);

            CON1.Open();
            reader2 = CMD.ExecuteReader();

            while (reader2.Read())
            {
                string NAME_OF_PRODUCT = (string)reader2["NAME_OF_PRODUCT"].ToString();
                comboBox1.Text = NAME_OF_PRODUCT;

                string PRODUCT_ID = (string)reader2["PRODUCT_ID"].ToString();
                textBox3.Text = PRODUCT_ID;

                string MFG_DATE = (string)reader2["MFG_DATE"].ToString();
                dateTimePicker1.Text = MFG_DATE;

                string EXP_DATE = (string)reader2["EXP_DATE"].ToString();
                dateTimePicker2.Text = EXP_DATE;

            }
            reader2.Close();
            CON1.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CON1 = new OracleConnection("Data Source=localhost;User ID=SUPERMARKET_SYSTEM;Password=SUPERMARKET_SYSTEM");
            QUERY = "select * from INVENTORY WHERE PRODUCT_ID= '" + TextBox1.Text + " '";
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

            CON1.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string search;
            CON1 = new OracleConnection("Data Source=localhost;User ID=SUPERMARKET_SYSTEM;Password=SUPERMARKET_SYSTEM");
            OracleDataReader reader2;
            search = "select * from INVENTORY where PRODUCT_ID ='" + textBox3.Text + "' ";
            CMD = new OracleCommand(search, CON1);

            CON1.Open();
            reader2 = CMD.ExecuteReader();

            while (reader2.Read())
            {
                string PRICE = (string)reader2["PRICE"].ToString();
                TextBox6.Text = PRICE;

            }
            reader2.Close();
           
            int T1 = Convert.ToInt16(textBox4.Text);
            int T2 = Convert.ToInt16(TextBox6.Text);
            TextBox6.Text = Convert.ToString(T1 *T2 );
            CON1.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        { 


        }

        private void button5_Click(object sender, EventArgs e)
        {

            QUERY = "select * from billing WHERE BILL_NO= '" + textBox2.Text + " '";
            CON1 = new OracleConnection("Data Source=localhost;User ID=SUPERMARKET_SYSTEM;Password=SUPERMARKET_SYSTEM");
            CMD = new OracleCommand(QUERY, CON1);
            try
            {
                CON1.Open();
                da = new OracleDataAdapter(QUERY, CON1);
                d = new DataSet();
                da.Fill(d, "test");
                dataGridView2.DataSource = d.Tables[0];
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);

            }

            CON1.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string search;
            CON1 = new OracleConnection("Data Source=localhost;User ID=SUPERMARKET_SYSTEM;Password=SUPERMARKET_SYSTEM");
            OracleDataReader reader2;
            search = "select * from INVENTORY where PRODUCT_ID ='" + textBox3.Text + "' ";
            CMD = new OracleCommand(search, CON1);

            CON1.Open();
            reader2 = CMD.ExecuteReader();

            while (reader2.Read())
            {
                string QUANTITY = (string)reader2["QUANTITY"].ToString();
                textBox5.Text = QUANTITY;

            }

            reader2.Close();
            int T1 = Convert.ToInt16(textBox5.Text);
            int T2 = Convert.ToInt16(textBox4.Text);
            textBox4.Text = Convert.ToString(T2 *1);

            if (T2>T1)
            {
                MessageBox.Show("not allowed");
            }
            else
            {
                MessageBox.Show(" allowed");
                int V1 = Convert.ToInt16(textBox5.Text);
                int V2 = Convert.ToInt16(textBox4.Text);
                textBox5.Text = Convert.ToString(V1-V2);
                CON1 = new OracleConnection("Data Source=localhost;User ID=SUPERMARKET_SYSTEM;Password=SUPERMARKET_SYSTEM");
                QUERY = "Update INVENTORY Set QUANTITY='" + textBox5.Text + "' Where PRODUCT_ID='" + textBox3.Text + "'";
                CMD = new OracleCommand(QUERY, CON1);
                CMD.CommandType = CommandType.Text;
                try
                {
                    CON1.Open();
                    CMD.ExecuteNonQuery();
                    MessageBox.Show("Record updated successfully", "MESSAGE");
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }

                finally
                {
                    CON1.Close();

                }

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CON1 = new OracleConnection("Data Source=localhost;User ID=SUPERMARKET_SYSTEM;Password=SUPERMARKET_SYSTEM");
            QUERY = "select * from BILLING where BILL_NO='" + textBox2.Text + "' ";
            CMD = new OracleCommand(QUERY, CON1);
            CON1.Open();
            reader2 = CMD.ExecuteReader();

            while (reader2.Read())
            {
                comboBox1.Text= Convert.ToString(reader2["NAME_OF_PRODUCT"]);
                dateTimePicker1.Text= Convert.ToString(reader2["MFG_DATE"]);
                dateTimePicker2.Text = Convert.ToString(reader2["EXP_DATE"]);
                textBox3.Text = Convert.ToString(reader2["PRODUCT_ID_P"]);
                textBox4.Text = Convert.ToString(reader2["QUANTITY"]);
                TextBox6.Text = Convert.ToString(reader2["PRICE"]);

            }
            reader2.Close();
            CON1.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || TextBox6.Text == "" || dateTimePicker1.Text == "" || dateTimePicker2.Text == "")
            {
                MessageBox.Show("Enter All the Details ");
            }

            else
            {
                QUERY = "Insert into BILLING values('" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + textBox4.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + TextBox6.Text + "')";
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
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                TextBox6.Text = "";
                dateTimePicker1.Text = Convert.ToString(System.DateTime.Now);
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = " dd-MMM-yyyy  ";
                dateTimePicker2.Text = Convert.ToString(System.DateTime.Now);
                dateTimePicker2.Format = DateTimePickerFormat.Custom;
                dateTimePicker2.CustomFormat = " dd-MMM-yyyy  ";
                comboBox1.Text = "";
                textBox5.Text = "";
               
            }

        }

    }

}


    

