using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketManagementSystem.PAL
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void Login_Submit_Button_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = DAL.DataAccessLayer.Connection();
                string query = "Select * From ADMIN where CNIC = @CNIC AND Password=@Password";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@CNIC", Login_CNIC_Textbox.Text);
                cmd.Parameters.AddWithValue("@Password", Login_Password_Textbox.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    Home obj = new Home();
                    obj.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login Failed!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Login_CNIC_Textbox_Enter(object sender, EventArgs e)
        {
            if (Login_CNIC_Textbox.Text == "CNIC")
            {
                Login_CNIC_Textbox.Text = "";
                Login_CNIC_Textbox.ForeColor = Color.Black;
            }
        }

        private void Login_CNIC_Textbox_Leave(object sender, EventArgs e)
        {
            if (Login_CNIC_Textbox.Text == "")
            {
                Login_CNIC_Textbox.Text = "CNIC";
                Login_CNIC_Textbox.ForeColor = Color.Silver;
            }
        }

        private void Login_Password_Textbox_Leave(object sender, EventArgs e)
        {
            if (Login_Password_Textbox.Text == "")
            {
                Login_Password_Textbox.Text = "Enter Password";
                Login_Password_Textbox.ForeColor = Color.Silver;
            }
        }

        private void Login_Password_Textbox_Enter(object sender, EventArgs e)
        {
            if (Login_Password_Textbox.Text == "Enter Password")
            {
                Login_Password_Textbox.Text = "";
                Login_Password_Textbox.ForeColor = Color.Black;
            }
        }

        private void Login_Submit_Button_Click_1(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = DAL.DataAccessLayer.Connection();
                string query = "Select * From ADMIN where CNIC = @CNIC AND Password=@Password";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@CNIC", Login_CNIC_Textbox.Text);
                cmd.Parameters.AddWithValue("@Password", Login_Password_Textbox.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    Home obj = new Home();
                    obj.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login Failed!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
