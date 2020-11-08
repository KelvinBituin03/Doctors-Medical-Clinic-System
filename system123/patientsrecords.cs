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
    public partial class patientsrecords : Form
    {
        public patientsrecords()
        {
            InitializeComponent();
            Fillcombo();
        }

        void Fillcombo()
        {

            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select * from databaseitu.tblservices", conn);
            comm.ExecuteNonQuery();
            MySqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {

                string sname = dr.GetString("servicename");
                comboBoxlab.Items.Add(sname);


            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {


                MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();
                MySqlCommand comm = new MySqlCommand("Select * from  databaseitu.tbldiagnosis where PatientID like '%" + PatientID.Text + "%'", conn);


                MySqlDataAdapter adapt = new MySqlDataAdapter();
                adapt.SelectCommand = comm;
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error1", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void patientsrecords_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                if (PatientID.Text == "" || diagnosistxt.Text == "" || prescriptiontxt.Text == "" || KOTtxt.Text == "" || descriptiontxt.Text == "")
                {
                    MessageBox.Show("Please fill the blanks", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {



                    MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                    conn.Open();
                    MySqlCommand comm2 = new MySqlCommand("Select FULLNAME from databaseitu.tblpatient where PatientID='" + PatientID.Text + "'", conn);
                    comm2.ExecuteNonQuery();
                    MySqlDataReader dr = comm2.ExecuteReader();





                    MySqlConnection conn2 = new MySqlConnection("datasource=localhost;port=3306;username=root");
                    conn2.Open();
                    //MySqlCommand comm = new MySqlCommand("Select diagnosis,Prescription,datediagnosed from databaseitu.tbldiagnosis where diagnosis='" + textBox11.Text + "'and Prescription='" + textBox12.Text + "'and datediagnosed='" + dateTimePicker1.Text + "'and kindoftreatment='" + textBox16.Text + "' and description='" + textBox17.Text + "'and laboratory='" + comboBox2.Text + "' ", conn2);
                    //comm.ExecuteNonQuery();


                    MySqlCommand comm1 = new MySqlCommand("Insert into databaseitu.tbldiagnosis (diagnosis,Prescription,datediagnosed,kindoftreatment,description,laboratory,PatientID) values ('" + diagnosistxt.Text + "','" + prescriptiontxt.Text + "','" + dateTimePickerDOC.Text + "','" + KOTtxt.Text + "','" + descriptiontxt.Text + "','" + comboBoxlab.Text + "','" + PatientID.Text + "')", conn2);
                    comm1.ExecuteNonQuery();
                    MessageBox.Show("data added", "data added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error2", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.Hide();
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }



        private void button5_Click(object sender, EventArgs e)
        {


        }



        private void button14_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {



                MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();

                MySqlCommand comm = new MySqlCommand("Select * from databaseitu.tblservices where servicename='" + comboBoxlab.Text + "'", conn);
                MySqlDataReader dr = comm.ExecuteReader();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error3", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void holdbutton_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
             try
            {


               

            MySqlConnection conn2 = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn2.Open();
            MySqlCommand comm2 = new MySqlCommand("select * from databaseitu.tblquelist where status='Hold' and PatientFK='" + PatientID.Text + "'", conn2);
            comm2.ExecuteNonQuery();
            MySqlDataReader dr2 = comm2.ExecuteReader();



            if (dr2.Read())
            {


                MessageBox.Show("this patient is in Hold status", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
            }
            else  
            {
               
      
                MySqlConnection conn3 = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn3.Open();
                MySqlCommand comm = new MySqlCommand("Update databaseitu.tblquelist set status= 'Hold' where PatientFK='" + PatientID.Text + "'", conn3);
                comm.ExecuteNonQuery();
                MySqlDataReader dr3 = comm.ExecuteReader();

                this.Hide();
                

               
 

            }
                       }
            catch (Exception)
            {
                MessageBox.Show("No patient Selected", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        }
    }
