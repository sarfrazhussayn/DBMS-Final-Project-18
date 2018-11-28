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
    public partial class staff : UserControl
    {
        public staff()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-RHD68V9\SQLEXPRESS;Initial Catalog=TestDB;Persist Security Info=True;User ID=sa;Password=abc123abc");
        private void staff_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM [People.Staff] ", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            //donor_label.Text = dt.Rows[0][0].ToString();
            //this.people_DonorTableAdapter1.Fill(this.testDBDataSet._People_Donor);
            SqlDataAdapter sda1 = new SqlDataAdapter("select idStaff [Staff ID],First_Name +' '+ Last_Name [Full Name], [People.Staff_Category_idPeople.Staff_Category] [Employee Category],b.Branch_Name [Branch], Date_of_Joining [Employee Since] from [People.Staff] inner join Branch b on b.idBranch = Branch_idBranch where IsActive = 1 ", conn);
            DataTable dt1 = new DataTable();
            //sda1.Fill(dt1);

            DataSet ds = new DataSet();
            sda1.Fill(ds, "[People.Staff]");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addStaff staff = new addStaff();
            staff.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda2 = new SqlDataAdapter("select idStaff [Staff ID],First_Name +' '+ Last_Name [Full Name], [People.Staff_Category_idPeople.Staff_Category] [Employee Category],b.Branch_Name [Branch], Date_of_Joining [Employee Since] from [People.Staff] inner join Branch b on b.idBranch = Branch_idBranch where IsActive = 1 ", conn);
            DataTable dt2 = new DataTable();
            //sda2.Fill(dt2);

            DataSet ds2 = new DataSet();
            sda2.Fill(ds2, "[People.Staff]");
            dataGridView1.DataSource = ds2.Tables[0];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name LIKE '%{0}%'", textBox1.Text);
        }
    }
}
