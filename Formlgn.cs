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
    public partial class Formlgn : Form
    {
        public Formlgn()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Formlgn_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uname = textBox1.Text.ToString();
            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-3S4DF6K\SQLEXPRESS;Initial Catalog=Car_dealership;Integrated Security=True");
            string query = "Select * from login_info Where user_id = '" + textBox1.Text.Trim() + "' and password = '" + textBox2.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                FormWelcome objFormMain = new FormWelcome(uname);
                this.Hide();
                objFormMain.Show();
                
            }
            else
            {
                MessageBox.Show("Check your username and password");
             
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormSignUp objFormMain = new FormSignUp();

            objFormMain.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }
    }
}
