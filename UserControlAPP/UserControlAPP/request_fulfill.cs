using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static UserControlAPP.requests;
using System.Data.SqlClient;
using System.Configuration;


namespace UserControlAPP
{
    public partial class request_fulfill : Form
    {
        public request_fulfill()
        {
            InitializeComponent();
        }
        public string id1, deposit_type1, blood_group1, person_id1, IsCompleted1, Date1, Quantity1;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-RHD68V9\SQLEXPRESS;Initial Catalog=TestDB;Persist Security Info=True;User ID=sa;Password=abc123abc"))
                {
                    conn.Open();

                    //create a command object identifying the stored procedure
                    SqlCommand cmd = new SqlCommand("fulfill", conn);

                    //set the command object so it knows to execute a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    //3.add parameter to command, which will be passed to the stored procedure
                    cmd.Parameters.Add(new SqlParameter("@request", Convert.ToInt32(textBox1.Text))); //value 1
                    cmd.Parameters.Add(new SqlParameter("@btype", textBox3.Text)); //value 2
                    cmd.Parameters.Add(new SqlParameter("@quantity", Convert.ToInt32(textBox5.Text))); //value 3

                    // execute the command
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        while (rdr.Read())
                        {

                        }
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public request_fulfill(request request)
        {
            InitializeComponent();
            id1 = request.id;
            deposit_type1 = request.deposit_type;
            blood_group1 = request.blood_group;
            person_id1 = request.person_id;
            IsCompleted1 = request.IsCompleted;
            Date1 = request.Date;
            Quantity1 = request.Quantity;
        }

        private void request_fulfill_Load(object sender, EventArgs e)
        {
            textBox1.Text = id1;
            textBox2.Text = deposit_type1;
            textBox3.Text = blood_group1;
            textBox4.Text = person_id1;
            textBox5.Text = IsCompleted1;
            textBox6.Text = Date1;
            textBox7.Text = Quantity1;
        }
    }
}
