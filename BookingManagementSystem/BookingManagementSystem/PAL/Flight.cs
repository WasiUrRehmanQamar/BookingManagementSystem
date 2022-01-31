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
using TicketManagementSystem.BAL;

namespace TicketManagementSystem.PAL
{
    public partial class Flight : Form
    {
        public Flight()
        {
            InitializeComponent();
        }

        private void Flight_Load(object sender, EventArgs e)
        {
            SqlDataReader reader = DAL.DataAccessLayer.GetDefaultData();
            while (reader.Read())
            {
                cmbDeparture.Items.Add(reader["Departure"].ToString());
                cmbArrival.Items.Add(reader["Arrival"].ToString());
                cmbClass.Items.Add(reader["Class"].ToString());
                cmbCompany.Items.Add(reader["FlightCompany"].ToString());
                cmbPrice.Items.Add(reader["FlightPrice"].ToString());
                comboBox_FN.Items.Add(reader["FlightNo"].ToString());
            }

            SqlDataReader reader1 = DAL.DataAccessLayer.GetSeats();
            while (reader1.Read())
            {
                comboBox_seat.Items.Add(reader1["SeatNumber"].ToString());
            }

            DataSet DS = DAL.DataAccessLayer.AdapterFlightPrice();
            dataGridView1.DataSource = DS.Tables["tbl_Flight_Table_Price"];

        }

        

       
        private void button6_Click(object sender, EventArgs e)
        {
            string Name = txtName.Text;
            string CNIC = txtCNIC.Text;
            string Departure = cmbDeparture.Text;
            string Arrival = cmbArrival.Text;
            string Class = cmbClass.Text;
            int Price = int.Parse(cmbPrice.Text);
            string Company = cmbCompany.Text;
            string SeatNumber = comboBox_seat.Text;
            string FlightNo = comboBox_FN.Text;
            string Date = dateTimePicker1.Text;

            FlightClass ANF = new FlightClass(Name, CNIC, Departure, Arrival, Class, Price, Company, Date, SeatNumber, FlightNo);
            try
            {
                DAL.DataAccessLayer.FlightBooking(ANF);
                MessageBox.Show("Your Flight Ticket Has Been Booked");
            }
            catch (Exception)
            {
                MessageBox.Show("Error In Booking !");
            }
        }

        private void Back_Flight_Button_Click(object sender, EventArgs e)
        {
            Home HM = new Home();
            this.Hide();
            HM.Show();
        }

        private void View_Search_Flight_Button_Click(object sender, EventArgs e)
        {
            ViewSearchFlightBooking VSFT = new ViewSearchFlightBooking();
            this.Hide();
            VSFT.Show();
        }

        private void Cancel_Flight_Button_Click(object sender, EventArgs e)
        {
            CancelFlightBooking OBJ = new CancelFlightBooking();
            this.Hide();
            OBJ.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home H = new Home();
            this.Hide();
            H.Show();
        }

        private void btnFlight_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CancelFlightBooking obj = new CancelFlightBooking();
            this.Hide();
            obj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewSearchFlightBooking obj = new ViewSearchFlightBooking();
            this.Hide();
            obj.Show();
        }

        private void Logout_Exit_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox_seat_TextChanged(object sender, EventArgs e)
        {

        }

        private void TBSeatStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_seat_Leave(object sender, EventArgs e)
        {
            
        }

        private void comboBox_seat_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_FN_TextChanged(object sender, EventArgs e)
        {
            string SeatNumber = comboBox_seat.Text;
            string FlightNo = comboBox_FN.Text;
            string Date = dateTimePicker1.Text;
            string Company = cmbCompany.Text;

            BAL.FlightClass CF = new BAL.FlightClass(SeatNumber, FlightNo, Date, Company);
            DAL.DataAccessLayer.SearchSeat(CF);

            SqlDataReader myreader = DAL.DataAccessLayer.SearchSeat(CF);
            while (myreader.Read())
            {
                    textBox_SS.Text = "Booked";
            }
        }

        private void comboBox_FN_Leave(object sender, EventArgs e)
        {
            textBox_SS.Text = "Seat Available";
        }

       
        
    }
}
