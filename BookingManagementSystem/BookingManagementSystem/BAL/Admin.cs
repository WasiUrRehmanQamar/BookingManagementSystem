using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystem.BAL
{
    class Admin
    {
        public string CNIC;
        public string Password;

        public Admin(string CNIC,string Password)
        {
            this.CNIC = CNIC;
            this.Password = Password;
        }
    }
}
