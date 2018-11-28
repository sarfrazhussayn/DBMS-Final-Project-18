using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace UserControlAPP
{
    public partial class addStaff : Form
    {
        public addStaff()
        {
            InitializeComponent();
        }

        int Working = 1;
        
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void addStaff_Load(object sender, EventArgs e)
        {

        }
        public string GetMD5(string text)
        {
            MD5CryptoServiceProvider mD5 = new MD5CryptoServiceProvider();
            mD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = mD5.Hash;
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                str.Append(result[i].ToString("x2"));
            }
            return str.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(this.textBox1.Text!="" && this.textBox2.Text != "" && this.textBox3.Text != "" && this.textBox5.Text != "" && this.textBox6.Text != "" && this.textBox9.Text != "" && this.textBox11.Text != "" && this.maskedTextBox1.Text != "" && this.maskedTextBox2.Text != "" && this.comboBox1.Text != "" && this.comboBox2.Text != "" && this.comboBox3.Text != "" && this.comboBox2.Text != "")
            {
                try
                {
                    string pass = GetMD5(this.textBox1.Text);
                    SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-RHD68V9\SQLEXPRESS;Initial Catalog=TestDB;Persist Security Info=True;User ID=sa;Password=abc123abc");
                    SqlCommand add = new SqlCommand("begin transaction declare @staffId int; insert into [People.Staff] (Branch_idBranch,[People.Staff_Category_idPeople.Staff_Category],First_Name,Last_Name,DOB,[Date_of_Joining],IsActive,CNIC,Gender,Salary,Remarks) values ('" + this.comboBox4.Text + "','" + this.comboBox3.Text + "','" + this.textBox9.Text + "','" + this.textBox6.Text + "','" + this.maskedTextBox1.Text + "','" + this.maskedTextBox2.Text + "','" + Working + "','" + this.textBox5.Text + "','" + this.comboBox1.Text + "','" + this.textBox3.Text + "','" + this.richTextBox1.Text + "');select @staffId = SCOPE_IDENTITY(); insert into [Application.Credentials] ([People.Staff_idStaff],[User_name],Hashed_Password,DateCreated) values (@staffId,'" + this.textBox2.Text + "','" + pass + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "');commit", conn);

                    SqlDataReader reader;
                    conn.Open();
                    reader = add.ExecuteReader();
                    MessageBox.Show("Record Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (reader.Read())
                    {

                    }
                }

                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);

                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                Working = 1;
            }
            else if (checkBox1.Checked == false)
            {
                Working = 0;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
