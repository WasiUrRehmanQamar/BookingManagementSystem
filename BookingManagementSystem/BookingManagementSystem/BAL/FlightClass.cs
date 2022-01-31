using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystem.BAL
{
    class FlightClass
    {

        public string Name;
        public string CNIC;
        public string Departure;
        public string Arrival;
        public int Price;
        public string Date;
        public string Company;
        public string Class;
        public string SeatNumber;
        public string FlightNo;

        public FlightClass(string CNIC)
        {
            this.CNIC = CNIC;
        }

        public FlightClass(string CNIC, string Date, string SeatNumber)
        {
            this.CNIC = CNIC;
            this.Date = Date;
            this.SeatNumber = SeatNumber;
        }

        public FlightClass(string CNIC , string Date)
        {
            this.CNIC = CNIC;
            this.Date = Date;
        }

        public FlightClass(string SeatNumber, string FlightNo, string Date, string Company)
        {
            this.SeatNumber = SeatNumber;
            this.FlightNo = FlightNo;
            this.Date = Date;
            this.Company = Company;
        }

        public FlightClass(string Name, string CNIC, string Departure, string Arrival, string Class, int Price, string Company, string Date, string SeatNumber, string FlightNo)
        {
            this.Name = Name;
            this.CNIC = CNIC;
            this.Departure = Departure;
            this.Arrival = Arrival;
            this.Price = Price;
            this.Date = Date;
            this.Company = Company;
            this.Class = Class;
            this.SeatNumber = SeatNumber;
            this.FlightNo = FlightNo;
        }
    }
}
