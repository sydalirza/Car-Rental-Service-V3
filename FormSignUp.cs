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
    public partial class FormSignUp : Form
    {
        public FormSignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-3S4DF6K\SQLEXPRESS;Initial Catalog=Car_dealership;Integrated Security=True");
            string cmd = "Select * from login_info where user_id = '" + textBox2.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(cmd, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                MessageBox.Show("Username is already in use!");
            }         
            else if (textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("Passwords donot Match!");
            }
            else
            {
                SqlCommand cmd1 = new SqlCommand("Insert into login_info(f_name,user_id,password)values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", sqlcon);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                MessageBox.Show("Account Created!");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.UseSystemPasswordChar = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.UseSystemPasswordChar = true;
        }
    }
}
