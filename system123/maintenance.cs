using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing.Printing;

namespace system123
{
    public partial class maintenance : Form
    {
        public maintenance()
        {
            InitializeComponent();
        }


        private void maintenance_Load(object sender, EventArgs e)
        {
            //if (textBox17.Visible == true)
            //{
            //    MessageBox.Show("This username has been taken Choose another one", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    textBox16.Text = "";
            //}

        }



        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

            
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select servicename,servicetype,price from databaseitu.tblservices where servicename='" + textBox4.Text + "'", conn);
            comm.ExecuteNonQuery();
            MySqlDataReader dr = comm.ExecuteReader();
            string a = textBox1.Text.ToString();
            int aa = Convert.ToInt32(a);
            if (aa <= 100)
            {
                MessageBox.Show("Make your price much more real!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (textBox4.Text == "" || textBox1.Text == "" || comboBox2.Text == "")
                {

                    MessageBox.Show("Please fill-up the blanks", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
                else
                {

                    if (dr.Read())
                    {
                        MessageBox.Show("This Service exists already!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        string y = null;
                        textBox4.Text = "";
                        textBox1.Text = "";
                        comboBox2.Text = y;


                    }
                    else
                    {
                        if (MessageBox.Show("Add Service?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            MySqlConnection conn1 = new MySqlConnection("datasource=localhost;port=3306;username=root");
                            conn1.Open();
                            MySqlCommand comm2 = new MySqlCommand("Insert into databaseitu.tblservices (servicename,servicetype,price) values ('" + textBox4.Text + "','" + comboBox2.Text + "','" + textBox1.Text + "')", conn1);
                            comm2.ExecuteNonQuery();
                            MessageBox.Show("Sucess!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            comboBox5.Items.Add(textBox1.Text);
                            textBox4.Text = "";
                            textBox1.Text = "";
                            string y = null;
                            comboBox4.Text = y;


                        }
                        else
                        {


                        }

                    }

                }
            }
            }
            catch (Exception)
            {
                MessageBox.Show("Please fill-up the blanks", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void button9_Click_2(object sender, EventArgs e)
        {

            try
            {
                


                if (textBox5.Text == "" || textBox9.Text == "" || textBox11.Text == "" || textBox6.Text == "" || comboBox1.Text == "" || textBox17.Text == "")
                {
                    MessageBox.Show("Please fill the blanks", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (textBox17.Visible == true)
                {

                    MessageBox.Show("The Username has been taken choose another one", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox16.Text = "";
                }
                else 
                {
                    MySqlConnection conn2 = new MySqlConnection("datasource=localhost;port=3306;username=root");
                    conn2.Open();
                    MySqlCommand comm3 = new MySqlCommand("Select fname,mname,lname from databaseitu.tbldoctors where fname='" + textBox5.Text + "'and mname='" + textBox8.Text + "'and lname='" + textBox9.Text + "'", conn2);
                    MySqlDataReader dr = comm3.ExecuteReader();

                    if (dr.Read())
                    {
                        MessageBox.Show("This Doctor is already exists!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox5.Text = "";
                        textBox8.Text = "";
                        textBox9.Text = "";
                        textBox11.Text = "";
                        textBox10.Text = "";
                        textBox6.Text = "";
                        string x = null;
                        comboBox1.Text = x;
                    }


                    else
                    {


                        dr.Close();

                        string es = " ";
                        string ez = ",";

                        textBox7.Text = textBox9.Text + ez + es + textBox5.Text + es + textBox8.Text;
                        MySqlCommand comm4 = new MySqlCommand("Insert into databaseitu.users (Username,Password,SecretQuestion,SecretAnswer,usertype,fname,mname,lname,age,address,contactno,gender,doctorsfee,FULLNAME) values ('" + textBox16.Text + "','" + textBox15.Text + "','" + comboBox7.Text + "','" + textBox13.Text + "','" + comboBox8.Text + "','" + textBox5.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox11.Text + "','" + textBox10.Text + "','" + textBox6.Text + "','" + comboBox1.Text + "','" + textBox12.Text + "','" + textBox7.Text + "')", conn2);
                        comm4.ExecuteNonQuery();
                        MessageBox.Show("Registered Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        textBox16.Text = "";
                        textBox15.Text = "";
                        textBox13.Text = "";
                        textBox5.Text = "";
                        textBox8.Text = "";
                        textBox9.Text = "";
                        textBox11.Text = "";
                        textBox10.Text = "";
                        textBox6.Text = "";
                        string x = null;
                        comboBox1.Text = x;





                    }


                    conn2.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("that Username has been taken Choose anotherone", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int myAge =
           DateTime.Today.Year - dateTimePicker1.Value.Year; // CurrentYear - YourBirthDate

            textBox11.Text = myAge.ToString();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string actualdata = string.Empty;
            char[] entereddata = textBox6.Text.ToCharArray();
            foreach (char aChar in entereddata.AsEnumerable())
            {
                if (Char.IsDigit(aChar))
                {
                    actualdata = actualdata + aChar;
                    // MessageBox.Show(aChar.ToString());
                }
                else
                {
                    MessageBox.Show(aChar + " is not numeric");
                    actualdata.Replace(aChar, ' ');
                    actualdata.Trim();
                }
            }
            textBox6.Text = actualdata;
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            string actualdata = string.Empty;
            char[] entereddata = textBox11.Text.ToCharArray();
            foreach (char aChar in entereddata.AsEnumerable())
            {
                if (Char.IsDigit(aChar))
                {
                    actualdata = actualdata + aChar;
                    // MessageBox.Show(aChar.ToString());
                }
                else
                {
                    MessageBox.Show(aChar + " is not numeric");
                    actualdata.Replace(aChar, ' ');
                    actualdata.Trim();
                }
            }
            textBox11.Text = actualdata;
        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox8.Text == "Employee")
            {
                textBox12.ReadOnly = true;
            }else
            {
                textBox12.ReadOnly = false;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

            try
            {


                MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();

                MySqlCommand comm = new MySqlCommand("Select Username from databaseitu.users where Username='" + textBox16.Text + "'", conn);
                comm.ExecuteNonQuery();
                MySqlDataReader dr = comm.ExecuteReader();


                if (dr.Read())
                {

                    textBox17.Visible = true;
                    textBox18.Visible = false;
                }
                else if (textBox16.Text == "")
                {
                    textBox18.Visible = false;
                }
                else
                {
                    textBox17.Visible = false;
                    textBox18.Visible = true;
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }





        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            try
            {


                if (textBox15.Text == textBox14.Text)
                {
                    textBox19.Visible = false;
                    textBox20.Visible = true;

                }



                else if (textBox14.Text == "")
                {
                    textBox20.Visible = false;
                    textBox19.Visible = false;
                }
                else
                {
                    textBox19.Visible = true;
                    textBox20.Visible = false;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //saveFileDialog1.Filter = "SQL Files (*.sql)|*.sql|All Files (*.*)|*.*";


            //if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFileDialog1.FileName.Length > 0)
            //{
            //    string path = saveFileDialog1.FileName.ToString();
            //    backup1.Text = path;
            //    backup1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            //}
        }
    }
}
