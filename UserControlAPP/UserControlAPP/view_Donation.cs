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
    public partial class view_Donation : UserControl
    {
        public view_Donation()
        {
            InitializeComponent();
        }
        public string show_user;

        public view_Donation(USER_NAME user)
        {
            InitializeComponent();
            show_user = user.User_name;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-RHD68V9\SQLEXPRESS;Initial Catalog=TestDB;Persist Security Info=True;User ID=sa;Password=abc123abc");

        private void view_Donation_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select COUNT(*) from [Donation_final] where IsDonated=0 and Expiry>GETDATE() ", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            donor_label.Text = dt.Rows[0][0].ToString();
            //this.people_DonorTableAdapter1.Fill(this.testDBDataSet._People_Donor);
           /* SqlDataAdapter sda1 = new SqlDataAdapter("select top 100 CAST(dd.[idPeople.Donor] as varchar)+'-'+CAST(d.[idTransaction.Donation] as varchar)[Donation_ID],dd.First_Name +' '+ dd.Last_Name[Name of Donor],d.Donation_Date,d.[Deposit.Blood_Type_idBlood_TYPE][Type],d.[Deposit.Deposit_Category_idDeposit.Deposit_Cat] [Donation Category],CASE WHEN d.IsApproved = 0 then 'No' when d.IsApproved = 1 then 'Yes'  end [Approved],CASE WHEN GetDate()<Expiry then 'No' when GetDate()>Expiry then 'Yes'  end[Expired], d.Expiry[ValidTill] from Donation_final d inner join [People.Donor] dd on dd.[idPeople.Donor] = d.[People.Donor_idPeople.Donor]  where IsDonated=0 and Expiry>GETDATE()", conn);
            DataTable dt1 = new DataTable();
            //sda1.Fill(dt1);

            DataSet ds = new DataSet();
            sda1.Fill(ds, "[Donation]");
            dataGridView1.DataSource = ds.Tables[0];*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addDonation donate = new addDonation();
            //MainWindow menu = new MainWindow(user);
            donate.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //(dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Type] LIKE '%{0}%'", textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select COUNT(*) from [Donation_final] where IsDonated=0 and Expiry>GETDATE() ", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            donor_label.Text = dt.Rows[0][0].ToString();
            //this.people_DonorTableAdapter1.Fill(this.testDBDataSet._People_Donor);
            SqlDataAdapter sda1 = new SqlDataAdapter("select top 100 CAST(dd.[idPeople.Donor] as varchar)+'-'+CAST(d.[idTransaction.Donation] as varchar),dd.First_Name +' '+ dd.Last_Name [Name of Donor],d.Donation_Date,d.[Deposit.Blood_Type_idBlood_TYPE][Type],d.[Deposit.Deposit_Category_idDeposit.Deposit_Cat] [Donation Category],CASE WHEN d.IsApproved = 0 then 'No' when d.IsApproved = 1 then 'Yes'  end [Approved],CASE WHEN d.IsExpired = 0 then 'No' when d.IsExpired = 1 then 'Yes'  end[Expired], d.Expiry[ValidTill] from Donation_final d inner join [People.Donor] dd on dd.[idPeople.Donor] = d.[People.Donor_idPeople.Donor]  where IsDonated=0 and Expiry>GETDATE()", conn);
            DataTable dt1 = new DataTable();
            //sda1.Fill(dt1);

            DataSet ds = new DataSet();
            sda1.Fill(ds, "[Donation]");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-RHD68V9\SQLEXPRESS;Initial Catalog=TestDB;Persist Security Info=True;User ID=sa;Password=abc123abc"))
                {
                    conn.Open();

                    //create a command object identifying the stored procedure
                    SqlCommand cmd = new SqlCommand("search_donation", conn);

                    //set the command object so it knows to execute a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    //3.add parameter to command, which will be passed to the stored procedure
                    //cmd.Parameters.Add(new SqlParameter("@request", Convert.ToInt32(textBox1.Text))); //value 1
                    cmd.Parameters.Add(new SqlParameter("@btype", textBox1.Text)); //value 2
                    //cmd.Parameters.Add(new SqlParameter("@quantity", Convert.ToInt32(textBox5.Text))); //value 3
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "[Donation]");
                    dataGridView1.DataSource = ds.Tables[0];
                    // execute the command
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        while (rdr.Read())
                        {

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
