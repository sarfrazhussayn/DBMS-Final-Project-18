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

        public string show_user;

        public addDonation(USER_NAME user)
        {
            InitializeComponent();
            show_user = user.User_name;
        }

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-RHD68V9\SQLEXPRESS;Initial Catalog=TestDB;Persist Security Info=True;User ID=sa;Password=abc123abc");
        public void addDonation_Load(object sender, EventArgs e)
        {
            
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
            textBox11.Text = show_user;
            //textBox11.ReadOnly = true;
        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public int approval;
        private void button5_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                approval = 1;
            }
            else
            {
                approval = 0;
            }
            if (!String.IsNullOrEmpty(textBox1.Text) & !String.IsNullOrEmpty(textBox2.Text))
            {
                try
                {
                    SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-RHD68V9\SQLEXPRESS;Initial Catalog=TestDB;Persist Security Info=True;User ID=sa;Password=abc123abc");
                    SqlCommand add = new SqlCommand("begin transaction insert into Donation_final([Depository.Main_Depository_idDepository],[Deposit.Deposit_Category_idDeposit.Deposit_Cat],[Deposit.Blood_Type_idBlood_TYPE],[People.Donor_idPeople.Donor],[People.Staff_idStaff], IsApproved, Expiry, Donation_Date, IsDonated, IsExpired) Values(1, '" + comboBox1.Text + "', '" + textBox3.Text + "', '" + textBox2.Text + "', 3, '" + approval + "', GETDATE() + 20, GETDATE(), 0, 0)commit", conn);

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
            else
            {
                MessageBox.Show("Please Specify Details", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name LIKE '%{0}%'", textBox9.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda1 = new SqlDataAdapter("select [idPeople.Donor] [ID],First_Name +' '+Last_Name [Name],CASE WHEN Gender = 1 then 'Male' WHEN Gender = 0 then 'Female' END [Gender], Blood_Group [Blood Group], CNIC, DATEDIFF(YEAR,DOB,CAST(GETDATE() as DATE)) [Age] from [People.Donor] ", conn);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);

            DataSet ds = new DataSet();
            sda1.Fill(ds, "[People.Donor]");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addDonor add = new addDonor();
            add.Show();
        }
    }
}
