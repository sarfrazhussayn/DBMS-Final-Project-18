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

        private void Landing_Face_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-RHD68V9\SQLEXPRESS;Initial Catalog=TestDB;Persist Security Info=True;User ID=sa;Password=abc123abc");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM [People.Donor] ", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label3.Text = dt.Rows[0][0].ToString();
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
            MessageBox.Show("This Functionality should be coming soon :)");
        }
    }
}
