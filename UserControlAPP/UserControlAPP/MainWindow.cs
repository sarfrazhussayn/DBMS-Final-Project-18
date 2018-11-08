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
    public partial class MainWindow : Form
    {
        public string branchid;
        public MainWindow()
        {
            InitializeComponent();
        }
        public string show_user;

        public MainWindow(USER_NAME user)
        {
            InitializeComponent();
            show_user = user.User_name;
        }
        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            
            timer1.Start();
            timer1.Interval = 1000;
            landing_Face1.BringToFront();
            label13.Text = show_user;


            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-RHD68V9\SQLEXPRESS;Initial Catalog=TestDB;Persist Security Info=True;User ID=sa;Password=abc123abc");
            SqlDataAdapter sda = new SqlDataAdapter("select p.Branch_idBranch,b.Branch_Name from [People.Staff] p inner join Branch b on b.idBranch = p.Branch_idBranch ", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label2.Text = dt.Rows[0][0].ToString() + ", " + dt.Rows[0][1].ToString();
            branchid = dt.Rows[0][0].ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label1.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Height = button2.Height;
            donors1.BringToFront();
            //MessageBox.Show("Working Button2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Height = button3.Height;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            landing_Face1.BringToFront();
            panel2.Height = button4.Height;
            //MessageBox.Show("Working Button 4");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("button 3 works itself too");
        }

        
    }
}
