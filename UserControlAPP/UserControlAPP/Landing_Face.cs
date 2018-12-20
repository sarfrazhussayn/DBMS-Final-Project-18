using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UserControlAPP
{
    public partial class Landing_Face : UserControl
    {
        public Landing_Face()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-RHD68V9\SQLEXPRESS;Initial Catalog=TestDB;Persist Security Info=True;User ID=sa;Password=abc123abc");
        private void Landing_Face_Load(object sender, EventArgs e)
        {
            

            //Total Donors
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM [People.Donor] ", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label3.Text = dt.Rows[0][0].ToString();


            //Total blood till date
            SqlDataAdapter sda1 = new SqlDataAdapter("SELECT COUNT(*) FROM [Donation_final] ", conn);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            label4.Text = dt1.Rows[0][0].ToString();

            //Total blood available right now
            SqlDataAdapter sda2 = new SqlDataAdapter("SELECT COUNT(*) FROM [Donation_final] where IsDonated = 0 and Expiry > GetDate() ", conn);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            label10.Text = dt2.Rows[0][0].ToString();

            //donated blood
            SqlDataAdapter sda3 = new SqlDataAdapter("SELECT COUNT(*) FROM [Donation_final] where IsDonated = 1 ", conn);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            label6.Text = dt3.Rows[0][0].ToString();

            //Total Requests in the database

            SqlDataAdapter sda4 = new SqlDataAdapter("SELECT COUNT(*) FROM [Request] ", conn);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);
            label3.Text = dt4.Rows[0][0].ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("This Functionality should be coming soon :)");

            PassWord pass = new PassWord();
            pass.Show();
        }
    }
}
