using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace UserControlAPP
{
    
    public partial class addDonor : Form
    {
        public string id;
        public addDonor()
        {
            InitializeComponent();
        }
        int gender;
        private void addDonor_Load(object sender, EventArgs e)
        {
            //idfunction("Select Max([idPeople.Donor]) from [People.Donor]");
            //textBox12.Enabled = false;
            gender = 1;
            //textBox12.Text = gender.ToString();
        }
        
        public void idfunction(string retrieveid)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-RHD68V9\SQLEXPRESS;Initial Catalog=TestDB;Persist Security Info=True;User ID=sa;Password=abc123abc");
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand(retrieveid, conn);
                SqlDataReader sda = cmd.ExecuteReader();
                while (sda.Read())
                {
                    double value = Convert.ToDouble(sda[0].ToString()) + 1;
                    //textBox12.Text = value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string count;
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-RHD68V9\SQLEXPRESS;Initial Catalog=TestDB;Persist Security Info=True;User ID=sa;Password=abc123abc");
                SqlDataAdapter check = new SqlDataAdapter("select COUNT(*) from [People.Donor] where CNIC = '"+textBox5.Text+"'", conn);
                DataTable dt = new DataTable();
                check.Fill(dt);
                count = dt.Rows[0][0].ToString();
                if (Convert.ToInt32(count)==0)
                {
                    SqlCommand add = new SqlCommand("begin transaction declare @donorId int; insert into [People.Donor] (Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration],CNIC,Gender,Blood_Group) values (2,'" + this.textBox9.Text + "','" + this.textBox6.Text + "','" + this.maskedTextBox1.Text + "','" + this.maskedTextBox2.Text + "','" + this.textBox5.Text + "','" + gender + "','" + this.comboBox4.Text + "'); select @donorId = SCOPE_IDENTITY(); insert into [People.Address] ([People.Donor_idPeople.Donor],Address_Line1,Address_Line2,Address_Line3,Address_Type,City,Zip_PostCode) values (@donorId,'" + this.textBox2.Text + "','" + this.textBox1.Text + "','" + this.textBox4.Text + "','" + this.comboBox5.Text + "','" + this.textBox7.Text + "','" + this.textBox3.Text + "'); insert into [Donor.Phone] ([People.Donor_idPeople.Donor],Phone_No,Phone_Type) values (@donorId,'" + this.textBox11.Text + "','" + this.comboBox2.Text + "');commit", conn);
                    SqlDataReader reader;
                    conn.Open();
                    reader = add.ExecuteReader();
                    MessageBox.Show("Record Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (reader.Read())
                    {

                    }
                }
                else
                {
                    MessageBox.Show("CNIC error already in the Database");
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);

            }
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Male")
            {
                gender = 1;
                //textBox12.Text = "Male";
            }
            else if (comboBox1.Text == "Female")
            {
                gender = 0;
                //textBox12.Text = "Female";
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            this.Text = gender.ToString();
        }
    }
}
