using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketManagementSystem.PAL
{
    public partial class ViewSearchFlightBooking : Form
    {
        public ViewSearchFlightBooking()
        {
            InitializeComponent();
        }

        private void ViewSearchFlightTickets_Load(object sender, EventArgs e)
        {
            DataSet DS = DAL.DataAccessLayer.AdapterFlight();
            dataGridView1.DataSource = DS.Tables["tbl_Flight_Table"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Flight FH = new Flight();
            this.Hide();
            FH.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string CNIC = textBox1.Text;
            BAL.FlightClass SF = new BAL.FlightClass(CNIC);
            DataSet ds = DAL.DataAccessLayer.SearchFlightBooking(SF);
            dataGridView1.DataSource = ds.Tables["Flight_tbl"];
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            DataSet DS = DAL.DataAccessLayer.AdapterFlight();
            dataGridView1.DataSource = DS.Tables["tbl_Flight_Table"];
        }

        
        private void button1_Click_1(object sender, EventArgs e)
        {
            Home H = new Home();
            this.Hide();
            H.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFlight_Click(object sender, EventArgs e)
        {
            
        }

        private void Logout_Exit_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Flight obj = new Flight();
            this.Hide();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CancelFlightBooking obj = new CancelFlightBooking();
            this.Hide();
            obj.Show();
        }

    }
}
