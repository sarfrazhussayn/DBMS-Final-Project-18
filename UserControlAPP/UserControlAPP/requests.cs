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
    public partial class requests : UserControl
    {
        public requests()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-RHD68V9\SQLEXPRESS;Initial Catalog=TestDB;Persist Security Info=True;User ID=sa;Password=abc123abc");

        private void requests_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select COUNT(*) from [Request] where IsCompleted=0 ", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            donor_label.Text = dt.Rows[0][0].ToString();
            //this.people_DonorTableAdapter1.Fill(this.testDBDataSet._People_Donor);
            SqlDataAdapter sda1 = new SqlDataAdapter("select r.[idTransaction.Request][Request ID],dd.First_Name+' '+dd.Last_Name[Requested By],r.[Deposit.Blood_Type_idBlood_TYPE][Blood Group],r.[Deposit.Deposit_Category_idDeposit.Deposit_Cat][Request Type],r.Quantity,r.Request_Date[Requested On],r.IsCompleted[Completed] from Request r inner join [People.Donor] dd on dd.[idPeople.Donor] = r.[People.Donor_idPeople.Donor] where IsCompleted = 0", conn);
            DataTable dt1 = new DataTable();
            //sda1.Fill(dt1);

            DataSet ds = new DataSet();
            sda1.Fill(ds, "[Request]");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addRequest add = new addRequest();
            add.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Requested By] LIKE '%{0}%'", textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select COUNT(*) from [Request] where IsCompleted=0 ", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            donor_label.Text = dt.Rows[0][0].ToString();
            //this.people_DonorTableAdapter1.Fill(this.testDBDataSet._People_Donor);
            SqlDataAdapter sda1 = new SqlDataAdapter("select r.[idTransaction.Request][Request ID],dd.First_Name+' '+dd.Last_Name[Requested By],r.[Deposit.Blood_Type_idBlood_TYPE][Blood Group],r.[Deposit.Deposit_Category_idDeposit.Deposit_Cat][Request Type],r.Quantity,r.Request_Date[Requested On],r.IsCompleted[Completed] from Request r inner join [People.Donor] dd on dd.[idPeople.Donor] = r.[People.Donor_idPeople.Donor] where IsCompleted = 0", conn);
            DataTable dt1 = new DataTable();
            //sda1.Fill(dt1);

            DataSet ds = new DataSet();
            sda1.Fill(ds, "[Request]");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            request request = new request(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), dataGridView1.SelectedRows[0].Cells[1].Value.ToString(), dataGridView1.SelectedRows[0].Cells[2].Value.ToString(), dataGridView1.SelectedRows[0].Cells[3].Value.ToString(), dataGridView1.SelectedRows[0].Cells[4].Value.ToString(), dataGridView1.SelectedRows[0].Cells[5].Value.ToString(), dataGridView1.SelectedRows[0].Cells[6].Value.ToString());
            request_fulfill req = new request_fulfill(request);
            req.Show();
        }
        public class request
        {
            public string id, deposit_type, blood_group, person_id, IsCompleted, Date, Quantity;
            public request(string id,string deposit_type,string blood_group, string person_id, string IsCompleted, string Date, string Quantity)
            {
                this.id = id;
                this.deposit_type = deposit_type;
                this.blood_group = blood_group;
                this.person_id = person_id;
                this.IsCompleted = IsCompleted;
                this.Date = Date;
                this.Quantity = Quantity;
            }
        }
    }
}
