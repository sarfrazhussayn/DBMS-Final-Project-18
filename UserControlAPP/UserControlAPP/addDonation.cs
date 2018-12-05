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
    public partial class addDonation : Form
    {
        public addDonation()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-RHD68V9\SQLEXPRESS;Initial Catalog=TestDB;Persist Security Info=True;User ID=sa;Password=abc123abc");
        public void addDonation_Load(object sender, EventArgs e)
        {
            textBox11.ReadOnly = true;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            //SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM [Donation_final] ", conn);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            //donor_label.Text = dt.Rows[0][0].ToString();
            //this.people_DonorTableAdapter1.Fill(this.testDBDataSet._People_Donor);
            SqlDataAdapter sda1 = new SqlDataAdapter("select [idPeople.Donor] [ID],First_Name +' '+Last_Name [Name],CASE WHEN Gender = 1 then 'Male' WHEN Gender = 0 then 'Female' END [Gender], Blood_Group [Blood Group], CNIC, DATEDIFF(YEAR,DOB,CAST(GETDATE() as DATE)) [Age] from [People.Donor] ", conn);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);

            DataSet ds = new DataSet();
            sda1.Fill(ds, "[People.Donor]");
            dataGridView1.DataSource = ds.Tables[0];
        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            }
            else
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Functionality coming soon");
        }
    }
}
