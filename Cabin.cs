using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinBooking
{
    public class Cabin
    {
        public Cabin(string cabinName, string location, int capacity, bool isBooked = false)
        {
            CabinName = cabinName;
            Location = location;
            Capacity = capacity;
            IsBooked = isBooked;
        }
        public string CabinName { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public bool IsBooked { get; set; }

        public List<Booking> bookings = new List<Booking>();
    }
}
