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
    public partial class addRequest : Form
    {
        public addRequest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            string count;
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-RHD68V9\SQLEXPRESS;Initial Catalog=TestDB;Persist Security Info=True;User ID=sa;Password=abc123abc");
                SqlDataAdapter check = new SqlDataAdapter("select COUNT(*) from [Donation_final] where [Deposit.Blood_Type_idBlood_TYPE] = '"+comboBox1.Text+"' and Expiry>GETDATE() and IsDonated = 0", conn);
                DataTable dt = new DataTable();
                check.Fill(dt);
                count = dt.Rows[0][0].ToString();
                if (Convert.ToInt32(count) > Convert.ToInt32(textBox5.Text))
                {
                    SqlCommand add = new SqlCommand("begin transaction insert into Request ([Deposit.Deposit_Category_idDeposit.Deposit_Cat],[Deposit.Blood_Type_idBlood_TYPE],[People.Donor_idPeople.Donor],IsCompleted,Request_Date,Quantity) values ('" + comboBox2.Text+ "','" + comboBox1.Text + "','" + textBox9.Text + "',0,GETDATE(),'" + textBox5.Text + "') commit ", conn);
                    SqlDataReader reader;
                    conn.Open();
                    reader = add.ExecuteReader();
                    MessageBox.Show("Record Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (reader.Read())
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Quantity not in the Database");
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void addRequest_Load(object sender, EventArgs e)
        {

        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-RHD68V9\SQLEXPRESS;Initial Catalog=TestDB;Persist Security Info=True;User ID=sa;Password=abc123abc");
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (conn)
                {
                    conn.Open();

                    //create a command object identifying the stored procedure
                    SqlCommand cmd = new SqlCommand("search_donor", conn);

                    //set the command object so it knows to execute a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    //3.add parameter to command, which will be passed to the stored procedure
                    //cmd.Parameters.Add(new SqlParameter("@request", Convert.ToInt32(textBox1.Text))); //value 1
                    cmd.Parameters.Add(new SqlParameter("@fname", textBox1.Text)); //value 2
                    //cmd.Parameters.Add(new SqlParameter("@quantity", Convert.ToInt32(textBox5.Text))); //value 3
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "[Donor]");
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

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBox9.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }
    }
}
