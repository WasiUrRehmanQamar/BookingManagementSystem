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
namespace TicketManagementSystem.PAL
{
    public partial class CancelFlightBooking : Form
    {
        public string cnic;
        public string date;

        public CancelFlightBooking()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PAL.ViewSearchFlightBooking  VSBT = new  PAL.ViewSearchFlightBooking();
            this.Hide();
            VSBT.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Flight BH = new Flight();
            this.Hide();
            BH.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are You Sure !", "Confirm Deletion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                BAL.FlightClass DF = new BAL.FlightClass(cnic , date);
                DAL.DataAccessLayer.DeleteFlightBooking(DF);
                MessageBox.Show("Deleted");
            }
            else
            {
                MessageBox.Show("Cancelled");
            }
        }

        private void dateTimePicker2_Leave(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Home H = new Home();
            this.Hide();
            H.Show();
        }

        private void btnFlight_Click(object sender, EventArgs e)
        {
            CancelFlightBooking obj = new CancelFlightBooking();
            this.Hide();
            obj.Show();
        }

        private void Logout_Exit_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Flight obj = new Flight();
            this.Hide();
            obj.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewSearchFlightBooking obj = new ViewSearchFlightBooking();
            this.Hide();
            obj.Show();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_Leave_1(object sender, EventArgs e)
        {
            string CNIC = txtCNIC.Text;
            string Date = dateTimePicker2.Text;
            BAL.FlightClass CF = new BAL.FlightClass(CNIC, Date);
            DAL.DataAccessLayer.CancelFlight(CF);

            SqlDataReader myreader = DAL.DataAccessLayer.CancelFlight(CF);
            while (myreader.Read())
            {
                txtName.Text = myreader["Name"].ToString();
            }
            cnic = CNIC;
            date = Date;
        }

    }
}
