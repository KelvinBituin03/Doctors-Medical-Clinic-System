using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace system123
{
    public partial class addpatient : Form
    {
        public addpatient()
        {
            InitializeComponent();
        }
        private void AddCustomer_Load(object sender, EventArgs e)
        {

            // timer1.Start();
            //timer1.Enabled = true;
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox6.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Please fill the blanks", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                MySqlConnection conn2 = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn2.Open();
                MySqlCommand comm3 = new MySqlCommand("Select fname,mname,lname from databaseitu.tblpatient where fname='" + textBox1.Text + "'and mname='" + textBox2.Text + "'and lname='" + textBox3.Text + "'", conn2);
                MySqlDataReader dr = comm3.ExecuteReader();

                if (dr.Read())
                {
                    MessageBox.Show("Patient is already exists!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox4.Text = "";
                    string x = null;
                    comboBox1.Text = x;
                }
                else
                {
                    dr.Close();

                    string es = " ";
                    string ez = ",";
                    textBox7.Text = textBox3.Text + ez + es + textBox1.Text + es + textBox2.Text;
                    MySqlCommand comm4 = new MySqlCommand("Insert into databaseitu.tblpatient (fname,mname,lname,DOB,age,address,ContactNo,Gender,FULLNAME) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','"+ dateTimePicker1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + comboBox1.Text + "','" + textBox7.Text + "')", conn2);
                    comm4.ExecuteNonQuery();
                    MessageBox.Show("Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox4.Text = "";
                    string x = null;
                    comboBox1.Text = x;





                }
                conn2.Close();
            }

        

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (textBox6.Text.Any(c => c < 48 || c > 57))
                {

                    MessageBox.Show("that is not a Characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox6.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (textBox4.Text.Any(c => c < 48 || c > 57))
                {

                    MessageBox.Show("that is not a Characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox4.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int myAge =
            DateTime.Today.Year - dateTimePicker1.Value.Year; // CurrentYear - YourBirthDate

            textBox4.Text = myAge.ToString();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void addpatient_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
