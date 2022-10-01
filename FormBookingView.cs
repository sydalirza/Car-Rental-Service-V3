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
    public partial class FormBookingView : Form
    {
        public FormBookingView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-3S4DF6K\SQLEXPRESS;Initial Catalog=Car_dealership;Integrated Security=True");
            string query = "Select * from user_info Where cnic = '" + textBox1.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                label11.Text = "Booking Found!";
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand("Select u_name from user_info where cnic = '" + textBox1.Text + "' ", sqlcon);
                string cname = cmd.ExecuteScalar().ToString();
                SqlCommand cmd1 = new SqlCommand("Select phone from user_info where cnic = '" + textBox1.Text + "' ", sqlcon);
                string cphone = cmd1.ExecuteScalar().ToString();
                SqlCommand cmd2 = new SqlCommand("Select email from user_info where cnic = '" + textBox1.Text + "' ", sqlcon);
                string cEmail = cmd2.ExecuteScalar().ToString();
                SqlCommand cmd3 = new SqlCommand("Select car_number from user_info where cnic = '" + textBox1.Text + "' ", sqlcon);
                string cnum = cmd3.ExecuteScalar().ToString();


                textBox5.Text = cname;
                textBox2.Text = cphone;
                textBox3.Text = cEmail;
                textBox4.Text = cnum;

            }
            else
            {
                label11.Text = "No Booking Found!";
                textBox5.Text = "";
                textBox3.Text = "";
                textBox2.Text = "";
                textBox4.Text = "";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-3S4DF6K\SQLEXPRESS;Initial Catalog=Car_dealership;Integrated Security=True");
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand("update user_info set u_name = '" + textBox5.Text + "' where cnic = '" + textBox1.Text.Trim() + "' ", sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlCommand cmd1 = new SqlCommand("update user_info set phone = '" + textBox2.Text + "' where cnic = '" + textBox1.Text.Trim() + "' ", sqlcon);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            SqlCommand cmd2 = new SqlCommand("update user_info set email = '" + textBox3.Text + "' where cnic = '" + textBox1.Text.Trim() + "' ", sqlcon);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            SqlCommand cmd3 = new SqlCommand("update user_info set car_number = '" + textBox4.Text + "' where cnic = '" + textBox1.Text.Trim() + "' ", sqlcon);
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);

            DataSet ds = new DataSet();
            da.Fill(ds);
            da1.Fill(ds);
            da2.Fill(ds);
            da3.Fill(ds);
            MessageBox.Show("Modified Record Succesfully");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-3S4DF6K\SQLEXPRESS;Initial Catalog=Car_dealership;Integrated Security=True");
            sqlcon.Open();
            SqlCommand cmd3 = new SqlCommand("Select car_number from user_info where cnic = '" + textBox1.Text.Trim() + "' ", sqlcon);
            string cstat = cmd3.ExecuteScalar().ToString();
            SqlCommand cmd4 = new SqlCommand("update car_info set car_status = 'Not Booked' where car_number = '" + cstat + "' ", sqlcon);
            SqlDataAdapter da3 = new SqlDataAdapter(cmd4);
            DataSet ds1 = new DataSet();
            da3.Fill(ds1);
            SqlCommand cmd = new SqlCommand("delete from user_info where cnic = '" + textBox1.Text + "' ", sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            MessageBox.Show("Deleted Record Succesfully");

        }
    }
}
