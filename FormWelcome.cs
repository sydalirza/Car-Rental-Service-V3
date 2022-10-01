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

namespace CarDealershipDB
{
    public partial class FormWelcome : Form
    {
        public string name;
        public FormWelcome(string uname)
        {
            InitializeComponent();
            name = uname;
        }
        public void FormWelcome_Load(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-3S4DF6K\SQLEXPRESS;Initial Catalog=Car_dealership;Integrated Security=True");
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand("Select f_name from login_info where user_id = '" + name + "' ", sqlcon);
            string fname = cmd.ExecuteScalar().ToString();
            label1.Text ="Welcome " + fname + ", ";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormMain objFormMain = new FormMain();
            objFormMain.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormSearch objFormMain = new FormSearch();
            objFormMain.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormModify objFormMain = new FormModify();
            
            objFormMain.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormBooking objFormMain = new FormBooking();
            
            objFormMain.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormView objFormMain = new FormView();

            objFormMain.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormBookingView objFormMain = new FormBookingView();

            objFormMain.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
