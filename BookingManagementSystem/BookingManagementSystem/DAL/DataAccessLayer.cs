using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TicketManagementSystem.BAL;
using TicketManagementSystem.PAL;

namespace TicketManagementSystem.DAL
{
    class DataAccessLayer
    {
        public static SqlConnection Connection()
        {
            SqlConnection connection = new SqlConnection(@"Data Source = DESKTOP-8M72HBG\SQLEXPRESS ; Initial Catalog = BookingManagementSystem ; Integrated Security=true ; ");
            try
            {
                connection.Open();
            }
            catch(SqlException)
            {
                MessageBox.Show("Error In Connection Database !");
            }
            return connection;
        }

        public static SqlDataReader Reader()
        {
            string Query = "Select * From Flight ;";
            SqlConnection connection = DataAccessLayer.Connection();
            SqlCommand Command = new SqlCommand(Query, connection);
            return Command.ExecuteReader();
        }

        public static DataSet AdapterFlight()
        {
            string Query = "Select * From Flight ; ";
            SqlConnection connection = DataAccessLayer.Connection();
            SqlCommand Command = new SqlCommand(Query, connection);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(Command);
            adapter.Fill(ds, "tbl_Flight_Table");
            return ds;
        }

        public static DataSet AdapterFlightPrice()
        {
            string Query = "Select * From Price ; ";
            SqlConnection connection = DataAccessLayer.Connection();
            SqlCommand Command = new SqlCommand(Query, connection);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(Command);
            adapter.Fill(ds, "tbl_Flight_Table_Price");
            return ds;
        }

        public static DataSet SearchFlightBooking(FlightClass Object)
        {
            string Query = "SELECT * FROM Flight WHERE CNIC = @CNIC";
            SqlConnection conn = Connection();
            SqlCommand Command = new SqlCommand(Query, conn);
            Command.Parameters.AddWithValue("@CNIC", Object.CNIC);
            SqlDataAdapter adaptor = new SqlDataAdapter(Command);
            DataSet ds = new DataSet();
            adaptor.Fill(ds, "Flight_tbl");
            return ds;
        }

        public static SqlDataReader GetDefaultData()
        {
            string Query = "SELECT * FROM DefaultData";
            SqlConnection connection = Connection();
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.CommandType = CommandType.Text;
            return Command.ExecuteReader();
        }

        public static SqlDataReader GetSeats()
        {
            string Query = "SELECT * FROM SeatN";
            SqlConnection connection = Connection();
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.CommandType = CommandType.Text;
            return Command.ExecuteReader();
        }

        public static void FlightBooking(FlightClass Object)
        {
            string Query = "INSERT INTO Flight VALUES (@Name , @CNIC , @Departure , @Arrival , @Class , @Price , @Company , @Date, @SeatNumber, @FlightNo)";
            SqlConnection connection = DataAccessLayer.Connection();
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@Name", Object.Name);
            Command.Parameters.AddWithValue("@CNIC", Object.CNIC);
            Command.Parameters.AddWithValue("@Departure", Object.Departure);
            Command.Parameters.AddWithValue("@Arrival", Object.Arrival);
            Command.Parameters.AddWithValue("@Class", Object.Class);
            Command.Parameters.AddWithValue("@Price", Object.Price);
            Command.Parameters.AddWithValue("@Company", Object.Company);
            Command.Parameters.AddWithValue("@Date", Object.Date);
            Command.Parameters.AddWithValue("@SeatNumber", Object.SeatNumber);
            Command.Parameters.AddWithValue("@FlightNo", Object.FlightNo);
            Command.ExecuteNonQuery();
        }

        public static SqlDataReader CancelFlight(FlightClass Object)
        {
            string Query = "SELECT Name FROM Flight WHERE [CNIC] = @CNIC AND [Date] = @Date";
            SqlConnection connection = Connection();
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.CommandType = CommandType.Text;
            Command.Parameters.AddWithValue("@CNIC", Object.CNIC);
            Command.Parameters.AddWithValue("@Date", Object.Date);
            return Command.ExecuteReader();
        }

        public static SqlDataReader SearchSeat(FlightClass Object)
        {
            string Query = "SELECT Name FROM Flight WHERE SeatNumber=@SeatNumber AND FlightNo=@FlightNo AND Date=@Date AND Company=@Company;";
            SqlConnection connection = Connection();
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.CommandType = CommandType.Text;
            Command.Parameters.AddWithValue("@SeatNumber", Object.SeatNumber);
            Command.Parameters.AddWithValue("@FlightNo", Object.FlightNo);
            Command.Parameters.AddWithValue("@Date", Object.Date);
            Command.Parameters.AddWithValue("@Company", Object.Company);
            return Command.ExecuteReader();
        }

        public static void DeleteFlightBooking(FlightClass Object)
        {
            string Query = "DELETE FROM Flight WHERE CNIC = @CNIC AND Date = @Date;";
            SqlConnection connection = Connection();
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@CNIC", Object.CNIC);
            Command.Parameters.AddWithValue("@Date", Object.Date);
            Command.ExecuteNonQuery();
        }
       
    }
}
