using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;




namespace system123
{
    public partial class Form1 : Form
    {

        public static string username;
        public static string password;
        public static string useridentifyer;
        



        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {


                MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();

                MySqlConnection conn2 = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn2.Open();

                MySqlConnection conn3 = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn3.Open();

                MySqlCommand comm = new MySqlCommand("Select Username,Password from databaseitu.users where Username='" + textBox1.Text + "'and Password='" + textBox2.Text + "'", conn);
                comm.ExecuteNonQuery();
                MySqlDataReader dr = comm.ExecuteReader();

                MySqlCommand comm1 = new MySqlCommand("Select * from databaseitu.users where usertype = (select usertype from databaseitu.users where Username = '" + textBox1.Text + "' and usertype = 'Admin')", conn2);
                comm1.ExecuteNonQuery();
                MySqlDataReader dr1 = comm1.ExecuteReader();

                MySqlCommand comm3 = new MySqlCommand("Select * from databaseitu.users where usertype = (select usertype from databaseitu.users where Username = '" + textBox1.Text + "' and usertype = 'Doctor')", conn3);
                comm3.ExecuteNonQuery();
                MySqlDataReader dr3 = comm3.ExecuteReader();

                if (dr.Read())
                {
                    if (dr1.Read())
                    {
                        Main from = new Main();
                        username = textBox1.Text;
                        password = textBox2.Text;
                        this.Hide();
                        from.Show();
                    }
                    else if (dr3.Read())
                    {
                        Main from = new Main();
                        username = textBox1.Text;
                        password = textBox2.Text;
                        this.Hide();
                        from.Show();
                    }
                    else
                    {
                        employeeform from = new employeeform();
                        username = textBox1.Text;
                        password = textBox2.Text;
                        this.Hide();
                        from.Show();
                    }

                }
                else
                {
                    MessageBox.Show("Incorrect Username or Password", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Text = "";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Incorrect Username or Password", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        //MySqlCommand comm3 = new MySqlCommand("Select * from databaseitu.tblservices", conn);
        //comm3.ExecuteNonQuery();
        //MySqlDataReader dr3 = comm.ExecuteReader();
        //while (dr.Read())

        //if (dr.Read())
        //{


        //    userIdentifier = "admin";
        //    Main from = new Main();
        //    from.MyProperty = userIdentifier;
        //    username = textBox1.Text;
        //    this.Hide();
        //    from.Show();





        //}
        //else
        //{

        //    MySqlCommand comm5 = new MySqlCommand("Select Username,Password from databaseitu.users where Username='" + textBox1.Text + "'and Password='" + textBox2.Text + "'", conn);
        //    comm.ExecuteNonQuery();
        //    MySqlDataReader dr5 = comm5.ExecuteReader();
        //    if (dr.Read())
        //    {

        //        employeeform from = new employeeform();
        //        this.Hide();
        //        from.Show();

        //    }
        //    else
        //    {
        //        MessageBox.Show("Incorrect Username or Password", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    conn.Close();


        //String userIdentifier = "";

        //MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
        //conn.Open();







        //if (textBox1.Text == "admin" && textBox2.Text == "admin")
        //{


        //    userIdentifier = "admin";
        //    Main from = new Main();
        //    from.MyProperty = userIdentifier;
        //    username = textBox1.Text;
        //    this.Hide();
        //    from.Show();





        //}
        //else
        //{

        //    MySqlCommand comm = new MySqlCommand("Select Username,Password from databaseitu.users where Username='" + textBox1.Text + "'and Password='" + textBox2.Text + "'", conn);
        //    comm.ExecuteNonQuery();
        //    MySqlDataReader dr = comm.ExecuteReader();
        //    if (dr.Read())
        //    {

        //        employeeform from = new employeeform();
        //        this.Hide();
        //        from.Show();

        //    }
        //    else
        //    {
        //        MessageBox.Show("Incorrect Username or Password", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    conn.Close();
        //}





        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassword from = new ForgotPassword();
            this.Hide();
            from.Show();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.AcceptButton = button1;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {



               
            
        }
    }

}