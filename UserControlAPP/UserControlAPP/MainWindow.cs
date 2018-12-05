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
            panel4.Height = button3.Height;
            panel4.Visible = false;
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
            panel4.Height = button2.Height;
            panel4.Top = button2.Top;
            donors1.BringToFront();
            //MessageBox.Show("Working Button2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //panel2.Height = button3.Height;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            landing_Face1.BringToFront();
            
            //MessageBox.Show("Working Button 4");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel4.Height = button3.Height;
            panel4.Top = button3.Top;
            view_Donation1.BringToFront();
        }

        private void staff1_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel4.Height = button7.Height;
            panel4.Top = button7.Top;
            requests1.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PassWord pass = new PassWord();
            pass.Show();
        }

        private void button8_click(object sender, EventArgs e)
        {
            staff1.BringToFront();
            panel4.Visible = false;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel4.Height = button5.Height;
            panel4.Top = button5.Top;
        }
    }
}
