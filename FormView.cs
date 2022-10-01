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
    public partial class FormView : Form
    {
        public FormView()
        {
            InitializeComponent();
        }

        private void FormView_Load(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-3S4DF6K\SQLEXPRESS;Initial Catalog=Car_dealership;Integrated Security=True");
            string query = "Select * from user_info";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-3S4DF6K\SQLEXPRESS;Initial Catalog=Car_dealership;Integrated Security=True");
            sqlcon.Open();
            
            string query = "Select car_number from user_info where returndate = '" + DateTime.Now.ToString("MM/dd/yyyy") + "' ";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            int number = dtbl.Rows.Count;
            for(int i = number; i > 0; i--)
            {
                SqlCommand cmd3 = new SqlCommand("Select top 1 car_number from user_info where returndate = '" + DateTime.Now.ToString("MM/dd/yyyy") + "' ", sqlcon);
                string cstat = cmd3.ExecuteScalar().ToString();
                SqlCommand cmd4 = new SqlCommand("update car_info set car_status = 'Not Booked' where car_number = '" + cstat + "' ", sqlcon);
                SqlDataAdapter da3 = new SqlDataAdapter(cmd4);
                DataSet ds1 = new DataSet();
                da3.Fill(ds1);
            }
            SqlCommand cmd = new SqlCommand("delete from user_info where returndate <= '" + DateTime.Now.ToString("MM/dd/yyyy") + "' ", sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
        }
    }
}
