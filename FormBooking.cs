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
using System.Net;
using System.Net.Mail;

namespace CarDealershipDB
{
    public partial class FormBooking : Form
    {
        
        public FormBooking()
        {
            InitializeComponent();
            button1.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-3S4DF6K\SQLEXPRESS;Initial Catalog=Car_dealership;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Insert into user_info(u_name,cnic,phone,email,bookingdate,returndate,car_number)values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + dateTimePicker1.Value.ToString() + "','" + dateTimePicker2.Value.ToString() + "','" + textBox5.Text + "')", sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            //string to, from, pass, messageBody, sub;
            //MailMessage message = new MailMessage();
            //to = textBox4.Text;
            //from = "abc.carrentals@yahoo.com";
            //pass = "ABCCarRentals";
            //messageBody = "Greetings " + textBox1.Text + "!,<br>"+  
                //"Your booking for Car # " + textBox5.Text + "<br> From:  " + dateTimePicker1.Value.ToString() + "<br> Till:  " + dateTimePicker2.Value.ToString() + "<br>" +
                //"is successful!<br>" +
                //"Regards, <br>" +
                //"ABC Car Rentals";
            //sub = "Booking Confirmation Email | ABC Car Rentals";
            //message.To.Add(to);
            //message.From = new MailAddress(from);
            //message.Body = messageBody;
            //message.Subject = sub;
            //message.IsBodyHtml = true;
            //SmtpClient smtp = new SmtpClient("smtp.mail.yahoo.com");
            //smtp.EnableSsl = true;
            //smtp.Port = 465;
            //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtp.Credentials = new NetworkCredential(from, pass);
            //MessageBox.Show("Please wait while we send you your booking details via Email!");
            //try
            //{
                //smtp.Send(message);
                //DialogResult code = MessageBox.Show("Verification Email Sent");
            //}
            //catch
            //{
                //MessageBox.Show("Email Not Sent");
            //}
            SqlCommand cmd3 = new SqlCommand("update car_info set car_status = 'Booked' where car_number = '" + textBox5.Text.Trim() + "' ", sqlcon);
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            DataSet ds1 = new DataSet();
            da3.Fill(ds1);
            MessageBox.Show("Created Booking Succesfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-3S4DF6K\SQLEXPRESS;Initial Catalog=Car_dealership;Integrated Security=True");
            string query = "Select * from car_info Where car_number = '" + textBox5.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                MessageBox.Show("Car Found!");
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand("Select car_status from car_info where car_number = '" + textBox5.Text.Trim() + "' ", sqlcon);
                string cstat = cmd.ExecuteScalar().ToString();
                if (cstat == "Booked")
                {
                    MessageBox.Show("Car is unavailable!");
                }
                else
                {
                    button1.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Car Not Found! Enter Valid Number Plate");

            }
        }
    }
}
