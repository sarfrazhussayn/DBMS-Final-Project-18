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
using System.Security.Cryptography;

namespace UserControlAPP
{
    public partial class PassWord : Form
    {
        public PassWord()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
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
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-RHD68V9\SQLEXPRESS;Initial Catalog=TestDB;Persist Security Info=True;User ID=sa;Password=abc123abc");
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("update [Application.Credentials] set Hashed_Password = '" + GetMD5(this.textBox8.Text) + "' where [User_name] = '" + this.textBox9.Text + "' and Hashed_Password = '" + GetMD5(this.textBox6.Text) + "'", conn);
                sda.SelectCommand.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Successfully Updated");
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

        private void PassWord_Load(object sender, EventArgs e)
        {

        }
    }
}