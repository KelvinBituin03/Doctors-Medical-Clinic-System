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
    public partial class Main : Form
    {

        
        public static string proceedname;
        public static string proceeddrname;
        double x = 0;
        int pw;
        bool hided;
        public Main()
        {
            InitializeComponent();
            Fillcombo();
            pw = spanel.Width;
            hided = false;
        }


        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

       

        void Fillcombo()
        {
            try
            {

            
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select * from databaseitu.tblservices", conn);
            comm.ExecuteNonQuery();
            MySqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {

                string sname = dr.GetString("servicename");
                comboBox2.Items.Add(sname);
                

            }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error2", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage1);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

            
            patientID.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            fname.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            mname.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            lname.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dob.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            age.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            address.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            contactno.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
            gender.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
            fullname.Text = this.dataGridView1.CurrentRow.Cells[9].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error3", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




            

        }

        private void button5_Click(object sender, EventArgs e)
        {   
             if (MessageBox.Show("Are you sure you want to Logout?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
             {
                 Form1 from = new Form1();
                 this.Close();
                 from.Show();
                 
                  
             }
            
        }

        private void Main_Load(object sender, EventArgs e)
        {

            try
            {

            
            textBox13.Text = Form1.username;
            password.Text = Form1.password;
            
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();

            MySqlCommand comm = new MySqlCommand("Select * from databaseitu.users where Username='" + textBox13.Text + "'", conn);
            MySqlDataReader dr = comm.ExecuteReader();

            if (dr.Read())
            {
                textBox13.Text = dr["FULLNAME"].ToString();
                textBox14.Text = dr["Username"].ToString();



            }

                 MySqlConnection conn2 = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn2.Open();

                MySqlConnection conn3 = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn3.Open();

                MySqlCommand comm2 = new MySqlCommand("Select Username,Password from databaseitu.users where FULLNAME='" + textBox13.Text + "'and Password='" + password.Text + "'", conn2); 
                comm2.ExecuteNonQuery();
                MySqlDataReader dr2 = comm2.ExecuteReader();

                MySqlCommand comm3 = new MySqlCommand("Select * from databaseitu.users where usertype = (select usertype from databaseitu.users where FULLNAME = '" + textBox13.Text + "' and usertype = 'Doctor')", conn3);
                comm3.ExecuteNonQuery();
                MySqlDataReader dr3 = comm3.ExecuteReader();



                if (dr2.Read())
                {
                    if (dr3.Read())
                    {
                        maintenancebutton.Visible = false;
                        reportbutton.Visible = false;
                        logoutbutton2.Visible = true;
                        logoutbutton.Visible = false;
                    }
                    else
                    {
                        maintenancebutton.Visible = true;
                        reportbutton.Visible = true;
                        logoutbutton2.Visible = false;
                        logoutbutton.Visible = true;
                    }

















                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error4", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //DGVPatient();
           
        }

        public void DGVPatient()
        {
            //MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            //conn.Open();

            //MySqlCommand cmd = new MySqlCommand("Select PatientID,QueueID,fname,lname,mname,status from databaseitu.queinglist,databaseitu.tblpatient ", conn);
            //MySqlDataAdapter sda = new MySqlDataAdapter();
            //sda.SelectCommand = cmd;
            //DataTable dbdataset = new DataTable();
            //sda.Fill(dbdataset);
            //BindingSource bsource = new BindingSource();

            //bsource.DataSource = dbdataset;
            //dataGridView2.DataSource = bsource;
            //sda.Update(dbdataset);



        }
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {
            try
            {


                MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();
                MySqlCommand comm = new MySqlCommand("Select PatientID,fname,mname,lname,DOB,age,address,contactNo,gender,FULLNAME  from  databaseitu.tblpatient where FULLNAME like '%" + textBox1.Text + "%'", conn);


                MySqlDataAdapter adapt = new MySqlDataAdapter();
                adapt.SelectCommand = comm;
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;


                patientID.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                fname.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                mname.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                lname.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                dob.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                age.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
                address.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
                contactno.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
                gender.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
                fullname.Text = this.dataGridView1.CurrentRow.Cells[9].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("No search Found", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          

        }
        private void Form2_Load(object sender, EventArgs e)
        {

                    }

        private void viewRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void contextMenuStrip1(object sender, EventArgs e)
        {



        }

        private void viewRecordsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            patientsrecords f2 = new patientsrecords();

            f2.PatientID.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            f2.textBox9.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();

            f2.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            addpatient from = new addpatient();
            from.Show();
        }

        private void addToListToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage6);



            textBox4.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage3);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage2);
    
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //tabControl1.SelectTab(tabPage5);
            maintenance from = new maintenance();
          
            from.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage4);
        }

        private void button10_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();

            MySqlCommand comm = new MySqlCommand("Select * from databaseitu.tblservices where servicename='" + comboBox2.Text + "'", conn);
            MySqlDataReader dr = comm.ExecuteReader();

            if (dr.Read())
            {
                textBox6.Text = dr["servicetype"].ToString();
                textBox5.Text = dr["price"].ToString();
                


            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error5", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button12_Click(object sender, EventArgs e)
        {
            
            timer1.Start(); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {

            
            if (hided)
            {
                spanel.Width = spanel.Width + 50;
                if (spanel.Width >= pw)
                {
                    timer1.Stop();
                    hided = false;
                    button12.Text = "";
                    this.Refresh();
                }
            }
            else
            {
                spanel.Width = spanel.Width - 50;
                if (spanel.Width <= 0)
                {
                    timer1.Stop();
                    hided = true;
                    button12.Text = "Menu";
                    this.Refresh();
                }

            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error6", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
           
            timer1.Start();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form1 from = new Form1();
            this.Close();
            from.Show();
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            try { 
            if (MessageBox.Show("Are you sure you want to Logout?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 from = new Form1();
                this.Close(); 
                from.Show();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error7", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void button6_Click_1(object sender, EventArgs e)
        {
            Form1 from = new Form1();
            this.Close();
            from.Show();
        }

       

        private void paymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            
        }

        private void button11_Click(object sender, EventArgs e)
        {

            try
            {

            
            panel8.Show();
            

            if (comboBox2.Text == "")
            {
                MessageBox.Show("Please Select a service", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                int n = dataGridView5.Rows.Add();
                
                dataGridView5.Rows[n].Cells[0].Value = comboBox2.Text;
                dataGridView5.Rows[n].Cells[1].Value = textBox5.Text;

                string num = textBox5.Text.ToString();
                double num2 = Convert.ToDouble(num);

                x += num2;
                textBox11.Text = x.ToString();
                
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error8", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button18_Click(object sender, EventArgs e)
        {
            
            x = 0;
            textBox11.Clear();
            dataGridView5.Rows.Clear();
            dataGridView5.Refresh();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            try
            {

            
            if (comboBox2.Text == "" || textBox5.Text == "" )
            {
                MessageBox.Show("Please Select a service", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                
                MessageBox.Show("Transaction Submited", "Succesfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error9", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

           
            

           
            
        }

        private void performTreatmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
            try
            {




                MySqlConnection conn2 = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn2.Open();
                MySqlCommand comm2 = new MySqlCommand("select * from databaseitu.tblquelist where status='Ongoing' and PatientFK='" + textBox12.Text + "'", conn2);
                comm2.ExecuteNonQuery();
                MySqlDataReader dr2 = comm2.ExecuteReader();



                if (dr2.Read())
                {


                    MessageBox.Show("Patient Is In Ongoing status", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {


                    MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand("Update databaseitu.tblquelist set status= 'Ongoing' where PatientFK='" + textBox24.Text + "'", conn);
                    comm.ExecuteNonQuery();
                    MySqlDataReader dr = comm.ExecuteReader();
                    proceedname = textBox13.Text;
                    proceeddrname = textBox16.Text;

                    patientsrecords f3 = new patientsrecords();

                    f3.PatientID.Text = this.dataGridView6.CurrentRow.Cells[0].Value.ToString();
                    f3.textBox9.Text = this.dataGridView6.CurrentRow.Cells[6].Value.ToString();

                    f3.ShowDialog();


                }
            }
            catch (Exception)
            {
                MessageBox.Show("No patient Selected", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
       
        }

        private void forConsultationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            //    conn.Open();
            //    MySqlCommand comm2 = new MySqlCommand("Select FULLNAME from databaseitu.tblpatient where PatientID='" + dataGridView1.SelectedRows + "'", conn);
            //    comm2.ExecuteNonQuery();
            //    MySqlDataReader dr = comm2.ExecuteReader();
            //dataGridView1.CurrentRow.Cells[0].Value.ToString();


            try
            {

            
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("select * from databaseitu.tblquelist where status='waitingforcheckup' and PatientFK = '"+ patientID.Text +"' ", conn);
            comm.ExecuteNonQuery();
            MySqlDataReader dr = comm.ExecuteReader();

             if (dr.Read())
             {
                 MessageBox.Show("This Patient is already in Queue For Checkup", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }else
             {
                 string w = "waitingforcheckup";
                 MySqlConnection conn2 = new MySqlConnection("datasource=localhost;port=3306;username=root");
                 conn2.Open();
                 MySqlCommand comm2 = new MySqlCommand("Insert into databaseitu.tblquelist (PatientFK,status) values ('" + patientID.Text + "','" + w + "')", conn2);
                 comm2.ExecuteNonQuery();
                 MessageBox.Show("data added", "data added", MessageBoxButtons.OK, MessageBoxIcon.Information);

                 
             }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error10", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



           

            
           
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {

            
            textBox24.Text = this.dataGridView2.CurrentRow.Cells[0].Value.ToString();

            textBox16.Text = this.dataGridView2.CurrentRow.Cells[6].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to Reorder Column", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox24.Text = this.dataGridView2.CurrentRow.Cells[0].Value.ToString();
          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {



        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            


        }

        private void button10_Click_1(object sender, EventArgs e)
        {

            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("SELECT DISTINCT PatientFK,queID,fname,mname,lname,status,FULLNAME from databaseitu.tblquelist,databaseitu.tblpatient where PatientFK = PatientID and status= 'waitingforcheckup'", conn);


            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = comm;
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();
        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            try
            { 
            if (fname.Text == "" || lname.Text == "" || address.Text == "")
            {
                MessageBox.Show("Select Patient", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();
                MySqlCommand comm = new MySqlCommand("Update databaseitu.tblpatient set fname='" + fname.Text + "'where PatientID='" + patientID.Text + "'", conn);
                comm.ExecuteNonQuery();
                MySqlCommand comm2 = new MySqlCommand("Update databaseitu.tblpatient set mname='" + mname.Text + "'where PatientID='" + patientID.Text + "'", conn);
                comm2.ExecuteNonQuery();
                MySqlCommand comm3 = new MySqlCommand("Update databaseitu.tblpatient set lname='" + lname.Text + "'where PatientID='" + patientID.Text + "'", conn);
                comm3.ExecuteNonQuery();
                MySqlCommand comm4 = new MySqlCommand("Update databaseitu.tblpatient set DOB='" + dob.Text + "'where PatientID='" + patientID.Text + "'", conn);
                comm3.ExecuteNonQuery();
                MySqlCommand comm5 = new MySqlCommand("Update databaseitu.tblpatient set age='" + age.Text + "'where PatientID='" + patientID.Text + "'", conn);
                comm4.ExecuteNonQuery();
                MySqlCommand comm6 = new MySqlCommand("Update databaseitu.tblpatient set address='" + address.Text + "'where PatientID='" + patientID.Text + "'", conn);
                comm5.ExecuteNonQuery();
                MySqlCommand comm7 = new MySqlCommand("Update databaseitu.tblpatient set ContactNo='" + contactno.Text + "'where PatientID='" + patientID.Text + "'", conn);
                comm6.ExecuteNonQuery();
                MySqlCommand comm8 = new MySqlCommand("Update databaseitu.tblpatient set Gender='" + gender.Text + "'where PatientID='" + patientID.Text + "'", conn);
                comm7.ExecuteNonQuery();

                                                                //Update databaseitu.tblquelist set status = 'Ongoing' where PatientFK='"+ textBox24.Text +"'",

                MessageBox.Show("Successfully Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fname.ReadOnly = true;
                mname.ReadOnly = true;
                lname.ReadOnly = true;
                address.ReadOnly = true;
                savebutton.Enabled = false;
                button20.Enabled = true;
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error12", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (patientID.Text == "")
            {
                MessageBox.Show("please select a patient!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                savebutton.Enabled = true;
                fname.ReadOnly = false;
                mname.ReadOnly = false;
                lname.ReadOnly = false;
                address.ReadOnly = false;
                contactno.ReadOnly = false;
                button20.Enabled = false;
            }
            
            
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            try
            {


                MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();
                MySqlCommand comm = new MySqlCommand("Select PatientID,fname,mname,lname,DOB,age,address,contactNo,gender,FULLNAME  from  databaseitu.tblpatient where FULLNAME like '%" + textBox1.Text + "%'", conn);


                MySqlDataAdapter adapt = new MySqlDataAdapter();
                adapt.SelectCommand = comm;
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;


                //patientID.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                //fname.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                //mname.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                //lname.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                //dob.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                //age.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
                //address.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
                //contactno.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
                //gender.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
                //fullname.Text = this.dataGridView1.CurrentRow.Cells[9].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error13", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void button23_Click(object sender, EventArgs e)
        {

            try
            {


               

            MySqlConnection conn2 = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn2.Open();
            MySqlCommand comm2 = new MySqlCommand("select * from databaseitu.tblquelist where status='Ongoing' and PatientFK='" + textBox24.Text + "'", conn2);
            comm2.ExecuteNonQuery();
            MySqlDataReader dr2 = comm2.ExecuteReader();

            MySqlConnection conn3 = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn3.Open();
            MySqlCommand comm3 = new MySqlCommand("select * from databaseitu.tblquelist where status='Hold' and PatientFK='" + textBox24.Text + "'", conn3);
            comm3.ExecuteNonQuery();
            MySqlDataReader dr3 = comm3.ExecuteReader();



            if (dr2.Read())
            {
                
                                MessageBox.Show("Patient Is In Ongoing status", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
            }
            else if (dr3.Read())
            {
                MessageBox.Show("This patient is on Hold status please refresh your database", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                

            }
            else
            {
                
      
                MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();
                MySqlCommand comm = new MySqlCommand("Update databaseitu.tblquelist set status= 'Ongoing' where PatientFK='" + textBox24.Text + "'", conn);
                comm.ExecuteNonQuery();
                MySqlDataReader dr = comm.ExecuteReader();
                proceedname = textBox13.Text;
                proceeddrname = textBox16.Text;

                patientsrecords f3 = new patientsrecords();

                f3.PatientID.Text = this.dataGridView2.CurrentRow.Cells[0].Value.ToString();
                f3.textBox9.Text = this.dataGridView2.CurrentRow.Cells[6].Value.ToString();

                f3.ShowDialog();
 

            }
                       }
            catch (Exception)
            {
                MessageBox.Show("No patient Selected", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int myAge =
            DateTime.Today.Year - dob.Value.Year; // CurrentYear - YourBirthDate

            age.Text = myAge.ToString();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {

            
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("SELECT DISTINCT PatientFK,queID,fname,mname,lname,status,FULLNAME from databaseitu.tblquelist,databaseitu.tblpatient where PatientFK = PatientID and status= 'Hold'", conn);


            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = comm;
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView6.DataSource = dt;

           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void forVitalSignToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {


                MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();
                MySqlCommand comm = new MySqlCommand("select * from databaseitu.tblquelist where status='waitingforvitalsign' and PatientFK = '" + patientID.Text + "' ", conn);
                comm.ExecuteNonQuery();
                MySqlDataReader dr = comm.ExecuteReader();


                MySqlConnection conn2 = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn2.Open();
                MySqlCommand comm2 = new MySqlCommand("select * from databaseitu.tblquelist where status='waitingforcheckup' and PatientFK = '" + patientID.Text + "' ", conn2);
                comm2.ExecuteNonQuery();
                MySqlDataReader dr2 = comm2.ExecuteReader();



                MySqlConnection conn3 = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn3.Open();
                MySqlCommand comm3 = new MySqlCommand("select * from databaseitu.tblquelist where status='Ongoing' and PatientFK = '" + patientID.Text + "' ", conn3);
                comm3.ExecuteNonQuery();
                MySqlDataReader dr3 = comm3.ExecuteReader();


                if (dr.Read())
                {
                    MessageBox.Show("This Patient is already in Queue For Vital sign", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (dr2.Read())
                {
                    MessageBox.Show("This Patient is already in Waiting for doctor's checkup", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (dr3.Read())
                {
                    MessageBox.Show("This Patient is in On going status", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string w = "waitingforvitalsign";
                    MySqlConnection conn4 = new MySqlConnection("datasource=localhost;port=3306;username=root");
                    conn4.Open();
                    MySqlCommand comm4 = new MySqlCommand("Insert into databaseitu.tblquelist (PatientFK,status) values ('" + patientID.Text + "','" + w + "')", conn4);
                    comm4.ExecuteNonQuery();
                    MessageBox.Show("Queue For Vital Sign Station", "data added", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Main_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void button6_Click_3(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; 
        }

        private void logoutbutton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Logout?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 from = new Form1();
                this.Close();
                from.Show();
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {

            try
            {




                MySqlConnection conn2 = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn2.Open();
                MySqlCommand comm2 = new MySqlCommand("select * from databaseitu.tblquelist where status='Ongoing' and PatientFK='" + textBox12.Text + "'", conn2);
                comm2.ExecuteNonQuery();
                MySqlDataReader dr2 = comm2.ExecuteReader();



                if (dr2.Read())
                {


                    MessageBox.Show("Patient Is In Ongoing status", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {


                    MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand("Update databaseitu.tblquelist set status= 'Ongoing' where PatientFK='" + textBox24.Text + "'", conn);
                    comm.ExecuteNonQuery();
                    MySqlDataReader dr = comm.ExecuteReader();
                    proceedname = textBox13.Text;
                    proceeddrname = textBox16.Text;

                    patientsrecords f3 = new patientsrecords();

                    f3.PatientID.Text = this.dataGridView6.CurrentRow.Cells[0].Value.ToString();
                    f3.textBox9.Text = this.dataGridView6.CurrentRow.Cells[6].Value.ToString();

                    f3.ShowDialog();


                }
            }
            catch (Exception)
            {
                MessageBox.Show("No patient Selected", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button22_Click(object sender, EventArgs e)
        {
            try
            {

            
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();

            MySqlCommand comm = new MySqlCommand("DELETE from databaseitu.tbldiagnosis where queID='" + textBox12.Text + "'", conn);
            comm.ExecuteNonQuery();

            dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void contactno_TextChanged(object sender, EventArgs e)
        {
            string actualdata = string.Empty;
            char[] entereddata = contactno.Text.ToCharArray();
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
            contactno.Text = actualdata;

        }

        private void contactno_KeyDown(object sender, KeyEventArgs e)
        {

            
            
        }

        private void fname_TextChanged(object sender, EventArgs e)
        {
            //string actualdata = string.Empty;
            //char[] entereddata = fname.Text.ToCharArray();
            //foreach (char aChar in entereddata.AsEnumerable())
            //{
            //    if (Char.IsDigit(aChar))
            //    {
            //        actualdata = actualdata + aChar;
            //        // MessageBox.Show(aChar.ToString());
            //    }
            //    else
            //    {
            //        MessageBox.Show(aChar + " is not numeric");
            //        actualdata.Replace(aChar, ' ');
            //        actualdata.Trim();
            //    }
            //}
            //fname.Text = actualdata;
        }

        private void dataGridView6_SelectionChanged(object sender, EventArgs e)
        {
            try
            {


                textBox12.Text = this.dataGridView6.CurrentRow.Cells[0].Value.ToString();

                textBox15.Text = this.dataGridView6.CurrentRow.Cells[6].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to Reorder Column", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
