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
    public partial class FormModify : Form
    {
        public FormModify()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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


                textBox5.Text = cname;
                textBox2.Text = cmake;
                textBox3.Text = cmodel;
                textBox4.Text = cnum;

            }
            else
            {
                label11.Text = "No Car Found!";
                textBox5.Text = "";
                textBox3.Text = "";
                textBox2.Text = "";
                textBox4.Text = "";
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-3S4DF6K\SQLEXPRESS;Initial Catalog=Car_dealership;Integrated Security=True");
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand("update car_info set car_number = '" + textBox4.Text + "' where car_number = '" + textBox1.Text.Trim() + "' ", sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlCommand cmd1 = new SqlCommand("update car_info set car_name = '" + textBox5.Text + "' where car_number = '" + textBox1.Text.Trim() + "' ", sqlcon);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            SqlCommand cmd2 = new SqlCommand("update car_info set car_make = '" + textBox2.Text + "' where car_number = '" + textBox1.Text.Trim() + "' ", sqlcon);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            SqlCommand cmd3 = new SqlCommand("update car_info set car_model = '" + textBox3.Text + "' where car_number = '" + textBox1.Text.Trim() + "' ", sqlcon);
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
            SqlCommand cmd = new SqlCommand("delete from car_info where car_number = '" + textBox1.Text + "' ", sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds);
            MessageBox.Show("Deleted Record Succesfully");

        }

        private void button4_Click(object sender, EventArgs e)
        {
          
        }
    }
}
