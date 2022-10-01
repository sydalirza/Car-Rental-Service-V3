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
    public partial class FormSearch : Form
    {
        public FormSearch()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void label8_Click(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-3S4DF6K\SQLEXPRESS;Initial Catalog=Car_dealership;Integrated Security=True");
            string query = "Select * from car_info Where car_number = '" + textBox1.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                label11.Text = "Car Found!";
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand("Select car_name from car_info where car_number = '" + textBox1.Text.Trim() + "' ", sqlcon);
                string cname = cmd.ExecuteScalar().ToString();
                SqlCommand cmd1 = new SqlCommand("Select car_make from car_info where car_number = '" + textBox1.Text.Trim() + "' ", sqlcon);
                string cmake = cmd1.ExecuteScalar().ToString();
                SqlCommand cmd2 = new SqlCommand("Select car_model from car_info where car_number = '" + textBox1.Text.Trim() + "' ", sqlcon);
                string cmodel = cmd2.ExecuteScalar().ToString();
                SqlCommand cmd3 = new SqlCommand("Select car_number from car_info where car_number = '" + textBox1.Text.Trim() + "' ", sqlcon);
                string cnum = cmd3.ExecuteScalar().ToString();
                SqlCommand cmd4 = new SqlCommand("Select car_status from car_info where car_number = '" + textBox1.Text.Trim() + "' ", sqlcon);
                string cstat = cmd4.ExecuteScalar().ToString();

                label4.Text = cname;
                label5.Text = cmake;
                label7.Text = cmodel;
                label10.Text = cnum;
                label13.Text = cstat;

            }
            else
            {
                label11.Text = "No Car Found!";
                label4.Text = "";
                label5.Text = "";
                label7.Text = "";
                label10.Text = "";
                label13.Text = "";
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
