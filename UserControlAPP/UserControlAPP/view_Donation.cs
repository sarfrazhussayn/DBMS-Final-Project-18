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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-RHD68V9\SQLEXPRESS;Initial Catalog=TestDB;Persist Security Info=True;User ID=sa;Password=abc123abc");

        private void view_Donation_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM [Donation_final] ", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            donor_label.Text = dt.Rows[0][0].ToString();
            //this.people_DonorTableAdapter1.Fill(this.testDBDataSet._People_Donor);
            SqlDataAdapter sda1 = new SqlDataAdapter("select d.[idTransaction.Donation][Donation_ID],dd.First_Name +' '+ dd.Last_Name [Name of Donor],d.Donation_Date,d.[Deposit.Blood_Type_idBlood_TYPE][Type],d.[Deposit.Deposit_Category_idDeposit.Deposit_Cat] [Donation Category],CASE WHEN d.IsApproved = 0 then 'No' when d.IsApproved = 1 then 'Yes'  end [Approved],CASE WHEN d.IsExpired = 0 then 'No' when d.IsExpired = 1 then 'Yes'  end[Expired], d.Expiry[ValidTill] from Donation_final d inner join [People.Donor] dd on dd.[idPeople.Donor] = d.[People.Donor_idPeople.Donor]", conn);
            DataTable dt1 = new DataTable();
            //sda1.Fill(dt1);

            DataSet ds = new DataSet();
            sda1.Fill(ds, "[Donation]");
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void button2_Click(object sender, EventArgs e)
        {
            addDonation donate = new addDonation();
            donate.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
