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
    public partial class employeeform : Form
    {



        double x = 0;
        int pw;
        bool hided;

        public employeeform()
        {
            InitializeComponent();
            Fillcombo3();
            //Fillcombo4();
            pw = spanel.Width;
            hided = false;
        }

        void Fillcombo3()
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

        //void Fillcombo4()
        //{
        //    MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
        //    conn.Open();
        //    MySqlCommand comm = new MySqlCommand("Select * from databaseitu.tbldoctors", conn);
        //    comm.ExecuteNonQuery();
        //    MySqlDataReader dr = comm.ExecuteReader();
        //    while (dr.Read())
        //    {

        //        string rname = dr.GetString("FULLNAME");
        //        comboBox3.Items.Add(rname);


        //    }

        //}

        


       
        private void paymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button14_Click_1(object sender, EventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {

        }

        private void performTreatmentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
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

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void forConsultationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewRecordsToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void addToListToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtpatientid.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtfname.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtmname.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtlname.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dob2.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtage.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtaddress.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtcontact.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtgender.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtfullname.Text = this.dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void employeeform_Load(object sender, EventArgs e)
        {
           


            textBox13.Text = Form1.username;
           

            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();

            MySqlCommand comm = new MySqlCommand("Select * from databaseitu.users where Username='" + textBox13.Text + "'", conn);
            MySqlDataReader dr = comm.ExecuteReader();

            if (dr.Read())
            {
                textBox13.Text = dr["FULLNAME"].ToString();



            }
            drname.Text = Main.proceeddrname;
            pname.Text = Main.proceedname;
            

            
            
            

        
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Logout?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 from = new Form1();
                this.Close();
                from.Show();
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

        private void button11_Click_1(object sender, EventArgs e)
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

        private void button18_Click_1(object sender, EventArgs e)
        {
            x = 0;
            textBox11.Clear();
            dataGridView5.Rows.Clear();
            dataGridView5.Refresh();
        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select PatientID,fname,mname,lname,DOB,age,address,contactNo,gender,FULLNAME  from  databaseitu.tblpatient where FULLNAME like '%" + textBox1.Text + "%'", conn);


            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = comm;
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;

            txtpatientid.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtfname.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtmname.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtlname.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dob2.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtage.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtaddress.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtcontact.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtgender.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtfullname.Text = this.dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            timer1.Start(); 
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            addpatient from = new addpatient();
            from.Show();
        }

        private void button20_Click_1(object sender, EventArgs e)
        {
            
            MessageBox.Show("You can now update the information", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtfname.ReadOnly = false;
            txtmname.ReadOnly = false;
            txtlname.ReadOnly = false;
            txtaddress.ReadOnly = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {


            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Update databaseitu.tblpatient set fname='" + txtfname.Text + "'where PatientID='" + txtpatientid.Text + "'", conn);
            comm.ExecuteNonQuery();
            MySqlCommand comm2 = new MySqlCommand("Update databaseitu.tblpatient set mname='" + txtmname.Text + "'where PatientID='" + txtpatientid.Text + "'", conn);
            comm2.ExecuteNonQuery();
            MySqlCommand comm3 = new MySqlCommand("Update databaseitu.tblpatient set lname='" + txtlname.Text + "'where PatientID='" + txtpatientid.Text + "'", conn);
            comm3.ExecuteNonQuery();
            MySqlCommand comm4 = new MySqlCommand("Update databaseitu.tblpatient set age='" + txtage.Text + "'where PatientID='" + txtpatientid.Text + "'", conn);
            comm4.ExecuteNonQuery();
            MySqlCommand comm5 = new MySqlCommand("Update databaseitu.tblpatient set address='" + txtaddress.Text + "'where PatientID='" + txtpatientid.Text + "'", conn);
            comm5.ExecuteNonQuery();
            MySqlCommand comm6 = new MySqlCommand("Update databaseitu.tblpatient set ContactNo='" + txtcontact.Text + "'where PatientID='" + txtpatientid.Text + "'", conn);
            comm6.ExecuteNonQuery();
            MySqlCommand comm7 = new MySqlCommand("Update databaseitu.tblpatient set Gender='" + txtgender.Text + "'where PatientID='" + txtpatientid.Text + "'", conn);
            comm7.ExecuteNonQuery();


            MessageBox.Show("Successfully Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {



            //MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            //conn.Open();
            //MySqlCommand comm = new MySqlCommand(


            //MySqlDataAdapter adapt = new MySqlDataAdapter();
            //adapt.SelectCommand = comm;
            //DataTable dt = new DataTable();
            //adapt.Fill(dt);
            //dataGridView1.DataSource = dt;


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

                txtpatientid.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtfname.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtmname.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtlname.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                dob2.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtage.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtaddress.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
                txtcontact.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
                txtgender.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
                txtfullname.Text = this.dataGridView1.CurrentRow.Cells[9].Value.ToString();
              
            }
            catch (Exception)
            {
                MessageBox.Show("No search Found", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          

        }

        private void forConsultationToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("Select fname,lname from databaseitu.tblpatient where fname='" + txtfname.Text + "'and lname='" + txtlname.Text + "'", conn);
            comm.ExecuteNonQuery();
            MySqlDataReader dr = comm.ExecuteReader();

            if (dr.Read())
            {
                MessageBox.Show("This Patient is already in Queue", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string w = "waiting";
                MySqlConnection conn2 = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn2.Open();
                MySqlCommand comm2 = new MySqlCommand("Insert into databaseitu.tblquelist (PatientFK,status) values ('" + txtpatientid.Text + "','" + w + "')", conn2);
                comm2.ExecuteNonQuery();
                MessageBox.Show("data added", "data added", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage1);
        }

        private void addToListToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
           




            textBox4.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
            tabControl1.SelectTab(tabPage5);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage2);
        }

        private void button19_Click_1(object sender, EventArgs e)
        {
            if (comboBox2.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Please Select a service", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                MessageBox.Show("Transaction Submited", "Succesfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage3);
        }

        private void button10_Click(object sender, EventArgs e)
        {

            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("SELECT DISTINCT PatientFK,fname,mname,lname,status,FULLNAME from databaseitu.tblquelist,databaseitu.tblpatient where PatientFK = PatientID", conn);


            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = comm;
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
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

        private void textBox25_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (bloodpresure.Text == "" || pulserate.Text == "" || weight.Text == "" || height.Text == "" || temperature.Text == "" || concern.Text == "")
                {
                    MessageBox.Show("Please fillup the blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                else
                {

                    MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand("Update databaseitu.tblpatient set bloodPresure='" + bloodpresure.Text + "'where PatientID='" + patientID.Text + "'", conn);
                    comm.ExecuteNonQuery();
                    MySqlCommand comm2 = new MySqlCommand("Update databaseitu.tblpatient set pulseRate='" + pulserate.Text + "'where PatientID='" + patientID.Text + "'", conn);
                    comm2.ExecuteNonQuery();
                    MySqlCommand comm3 = new MySqlCommand("Update databaseitu.tblpatient set Height='" + height.Text + "'where PatientID='" + patientID.Text + "'", conn);
                    comm3.ExecuteNonQuery();
                    MySqlCommand comm4 = new MySqlCommand("Update databaseitu.tblpatient set Weight='" + weight.Text + "'where PatientID='" + patientID.Text + "'", conn);
                    comm4.ExecuteNonQuery();
                    MySqlCommand comm5 = new MySqlCommand("Update databaseitu.tblpatient set Temperature='" + temperature.Text + "'where PatientID='" + patientID.Text + "'", conn);
                    comm5.ExecuteNonQuery();
                    MySqlCommand comm6 = new MySqlCommand("Update databaseitu.tblpatient set concern='" + concern.Text + "'where PatientID='" + patientID.Text + "'", conn);
                    comm6.ExecuteNonQuery();
                   
                  
                    MessageBox.Show("Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);



                    forcheckup.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView6_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                patientID.Text = this.dataGridView6.CurrentRow.Cells[0].Value.ToString();
                FULLNAME.Text = this.dataGridView6.CurrentRow.Cells[6].Value.ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("Unable to Reorder Column", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button23_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("SELECT DISTINCT PatientFK,queID,fname,mname,lname,status,FULLNAME from databaseitu.tblquelist,databaseitu.tblpatient where PatientFK = PatientID and status = 'waitingforvitalsign'", conn);


            MySqlDataAdapter adapt = new MySqlDataAdapter();
            adapt.SelectCommand = comm;
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView6.DataSource = dt;
            
        }

        private void button24_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage4);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {


                MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();
                MySqlCommand comm = new MySqlCommand("select * from databaseitu.tblquelist where status='waitingforcheckup' and PatientFK = '" + patientID.Text + "' ", conn);
                comm.ExecuteNonQuery();
                MySqlDataReader dr = comm.ExecuteReader();
                if (patientID.Text == "")
                {
                    MessageBox.Show("No Patient selected", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (dr.Read())
                {
                    MessageBox.Show("This Patient is already in Queue For Checkup", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    
                    MySqlConnection conn2 = new MySqlConnection("datasource=localhost;port=3306;username=root");
                    conn2.Open();
                    MySqlCommand comm2 = new MySqlCommand("Update databaseitu.tblquelist set status= 'waitingforcheckup' where PatientFK='" + patientID.Text + "'", conn2);
                    comm2.ExecuteNonQuery();
                    MySqlDataReader dr2 = comm2.ExecuteReader();
                    MessageBox.Show("Added for checkup", "data added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     
                    FULLNAME.Text = "";
                    bloodpresure.Text = "";
                    pulserate.Text = "";
                    height.Text = "";
                    weight.Text = "";
                    temperature.Text = "";
                    concern.Text = "";


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void bloodpresure_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void patientID_TextChanged(object sender, EventArgs e)
        {

            MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
            conn.Open();
            MySqlCommand comm = new MySqlCommand("select * from databaseitu.tblquelist where PatientFK = '" + patientID.Text + "' ", conn);
            comm.ExecuteNonQuery();
            MySqlDataReader dr = comm.ExecuteReader();

            if (dr.Read())
            {
                savebutton.Enabled = true;
            }
            else
            {
                savebutton.Enabled = false;
            }
        }

        //MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
        //    conn.Open();
        //    MySqlCommand comm = new MySqlCommand("SELECT DISTINCT PatientFK,queID,fname,mname,lname,status,FULLNAME from databaseitu.tblquelist,databaseitu.tblpatient where PatientFK = PatientID and status= 'waitingforcheckup'", conn);


        //    MySqlDataAdapter adapt = new MySqlDataAdapter();
        //    adapt.SelectCommand = comm;
        //    DataTable dt = new DataTable();
        //    adapt.Fill(dt);
        //    dataGridView2.DataSource = dt;
        //Select PatientID,fname,mname,lname,DOB,age,address,contactNo,gender,FULLNAME  from  databaseitu.tblpatient where FULLNAME like '%" + textBox1.Text + "%'", conn);
        private void textBox24_TextChanged_1(object sender, EventArgs e)
        {
            try
            {


                MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                conn.Open();
                MySqlCommand comm = new MySqlCommand("SELECT DISTINCT PatientFK,fname,mname,lname,status,FULLNAME from databaseitu.tblquelist,databaseitu.tblpatient where PatientFK = PatientID and FULLNAME like '%" + textBox24.Text + "%'", conn);


                MySqlDataAdapter adapt = new MySqlDataAdapter();
                adapt.SelectCommand = comm;
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dataGridView2.DataSource = dt;
                textBox25.Text = this.dataGridView2.CurrentRow.Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void paymentsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage6);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage7);
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; 
        }

        private void vitalsignpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void concern_TextChanged(object sender, EventArgs e)
        {

        }

        private void temperature_TextChanged(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void label47_Click(object sender, EventArgs e)
        {

        }

        private void FULLNAME_TextChanged(object sender, EventArgs e)
        {

        }

        private void weight_TextChanged(object sender, EventArgs e)
        {

        }

        private void height_TextChanged(object sender, EventArgs e)
        {

        }

        private void pulserate_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellStyleContentChanged(object sender, DataGridViewCellStyleContentChangedEventArgs e)
        {
            
        }

        private void dataGridView2_CellStyleContentChanged_1(object sender, DataGridViewCellStyleContentChangedEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridView2_SelectionChanged_1(object sender, EventArgs e)
        {
            textBox25.Text = this.dataGridView2.CurrentRow.Cells[0].Value.ToString();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox25.Text = this.dataGridView2.CurrentRow.Cells[0].Value.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox25.Text = this.dataGridView2.CurrentRow.Cells[0].Value.ToString();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtpatientid.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtfname.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtmname.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtlname.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dob2.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtage.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtaddress.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtcontact.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtgender.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtfullname.Text = this.dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (txtpatientid.Text == "")
            {
                MessageBox.Show("please select a patient!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                button4.Enabled = true;
                txtfname.ReadOnly = false;
                txtmname.ReadOnly = false;
                txtlname.ReadOnly = false;
                txtaddress.ReadOnly = false;
                txtcontact.ReadOnly = false;
                button20.Enabled = false;
            }
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtfname.Text == "" || txtlname.Text == "" || txtaddress.Text == "")
                {
                    MessageBox.Show("Select Patient", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root");
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand("Update databaseitu.tblpatient set fname='" + txtfname.Text + "'where PatientID='" + txtpatientid.Text + "'", conn);
                    comm.ExecuteNonQuery();
                    MySqlCommand comm2 = new MySqlCommand("Update databaseitu.tblpatient set mname='" + txtmname.Text + "'where PatientID='" + txtpatientid.Text + "'", conn);
                    comm2.ExecuteNonQuery();
                    MySqlCommand comm3 = new MySqlCommand("Update databaseitu.tblpatient set lname='" + txtlname.Text + "'where PatientID='" + txtpatientid.Text + "'", conn);
                    comm3.ExecuteNonQuery();
                    MySqlCommand comm4 = new MySqlCommand("Update databaseitu.tblpatient set DOB='" + dob2.Text + "'where PatientID='" + txtpatientid.Text + "'", conn);
                    comm3.ExecuteNonQuery();
                    MySqlCommand comm5 = new MySqlCommand("Update databaseitu.tblpatient set age='" + txtage.Text + "'where PatientID='" + txtpatientid.Text + "'", conn);
                    comm4.ExecuteNonQuery();
                    MySqlCommand comm6 = new MySqlCommand("Update databaseitu.tblpatient set address='" + txtaddress.Text + "'where PatientID='" + txtpatientid.Text + "'", conn);
                    comm5.ExecuteNonQuery();
                    MySqlCommand comm7 = new MySqlCommand("Update databaseitu.tblpatient set ContactNo='" + txtcontact.Text + "'where PatientID='" + txtpatientid.Text + "'", conn);
                    comm6.ExecuteNonQuery();
                    MySqlCommand comm8 = new MySqlCommand("Update databaseitu.tblpatient set Gender='" + txtgender.Text + "'where PatientID='" + txtpatientid.Text + "'", conn);
                    comm7.ExecuteNonQuery();

                    //Update databaseitu.tblquelist set status = 'Ongoing' where PatientFK='"+ textBox24.Text +"'",

                    MessageBox.Show("Successfully Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtfname.ReadOnly = true;
                    txtmname.ReadOnly = true;
                    txtlname.ReadOnly = true;
                    txtaddress.ReadOnly = true;
                    button4.Enabled = false;
                    button20.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error12", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Char.IsDigit
        private void txtfname_TextChanged(object sender, EventArgs e)
        {
            //if (txtfname.Text.Any (c => !  (c)))
            //{
            //    MessageBox.Show("that is not a Characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void txtcontact_TextChanged(object sender, EventArgs e)
        {

            try
            {

                if (txtcontact.Text.Any(c => c < 48 || c > 57))
                {

                    MessageBox.Show("that is not a Characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtcontact.Text ="";
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




            //string actualdata = string.Empty;
            //char[] entereddata = txtcontact.Text.ToCharArray();
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
            //txtcontact.Text = actualdata;
        }
    }
}
