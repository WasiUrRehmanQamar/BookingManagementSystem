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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        

        private void btnFlight_Click(object sender, EventArgs e)
        {
            Flight obj = new Flight();
            this.Hide();
            obj.Show();
        }

        

        private void Logout_Exit_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewSearchFlightBooking obj = new ViewSearchFlightBooking();
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
