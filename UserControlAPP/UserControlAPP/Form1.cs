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
    
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            panel3.BringToFront();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            panel2.BringToFront();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public string GetMD5(string text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                str.Append(result[i].ToString("x2"));
            }

            return str.ToString();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            USER_NAME user = new USER_NAME(this.textBox1.Text);
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-RHD68V9\SQLEXPRESS;Initial Catalog=TestDB;Persist Security Info=True;User ID=sa;Password=abc123abc");
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM [Application.Credentials] WHERE User_name = '" + textBox1.Text + "' and Hashed_Password = '" + GetMD5(textBox2.Text) + "'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1")
                {
                    //MessageBox.Show("Login Successful");
                    this.Hide();
                    MainWindow menu = new MainWindow(user);
                    //UserDisplayName.displayName = textBox1.Text;
                    menu.Show();
                }
                else
                {
                    MessageBox.Show("Authentication Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    public class USER_NAME
    {
        public string User_name;
        public USER_NAME(string show_name)
        {
            this.User_name = show_name;
        }
    }
}
