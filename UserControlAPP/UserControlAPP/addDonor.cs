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

        private void addDonor_Load(object sender, EventArgs e)
        {
            idfunction("Select Max([idPeople.Donor]) from [People.Donor]");
            textBox12.Enabled = false;
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
                    textBox12.Text = value.ToString();
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
            /*try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-RHD68V9\SQLEXPRESS;Initial Catalog=TestDB;Persist Security Info=True;User ID=sa;Password=abc123abc");
                conn.Open();
                SqlCommand command1 = new SqlCommand("Insert into Doctor([Doctor_ID],[Name],[CNIC_or_Password],[Contact#],[Email],[Blood_Group],[Age],[Gender],[Room_ID],[Doc_Fees_Pkr],[Doc_Day1],[Doc_Day2]) values(@docid,@name,@cnic,@contact,@email,@blood,@age,@gender,@roomid,@fees,@day1,@day2)", conn);
                command1.Parameters.AddWithValue("@docid", textBox1.Text); ; command1.Parameters.AddWithValue("@name", textBox2.Text); command1.Parameters.AddWithValue("@cnic", textBox3.Text); command1.Parameters.AddWithValue("@contact", textBox4.Text); command1.Parameters.AddWithValue("@email", textBox5.Text); command1.Parameters.AddWithValue("@blood", textBox6.Text);
                command1.Parameters.AddWithValue("@age", textBox7.Text); command1.Parameters.AddWithValue("@gender", comboBox1.Text); command1.Parameters.AddWithValue("@roomid", textBox9.Text); command1.Parameters.AddWithValue("@fees", textBox10.Text);
                command1.Parameters.AddWithValue("@day1", comboBox2.Text);
                command1.Parameters.AddWithValue("@day2", comboBox3.Text);
                command1.ExecuteNonQuery();
                command1.Parameters.Clear();
                MessageBox.Show("Table1 entry");
                SqlCommand command2 = new SqlCommand("INSERT INTO Doc_Further_Details ([Doctor_ID],[Doc_Speacialization],[Doc_Research]) values(@docid,@specialization,@research)", conn);
                command2.Parameters.AddWithValue("@docid", textBox1.Text);
                command2.Parameters.AddWithValue("@specialization", textBox12.Text);
                command2.Parameters.AddWithValue("@research", richTextBox1.Text);
                command2.ExecuteNonQuery();
                command2.Parameters.Clear();
                MessageBox.Show("Table 2 Entry");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/

        }
    }
}
