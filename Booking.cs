using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinBooking
{
    public class Booking
    {
        public Booking(string customerName, string email, int week) 
        {
            CustomerName = customerName;
            Email = email;
            Week = week;
        }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public int Week { get; set; }
    }
}
