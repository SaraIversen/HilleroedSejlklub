using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Exceptions.Bookings
{
    public class InvalidBookingDateException : Exception
    {
        public InvalidBookingDateException() 
        { 

        }

        public InvalidBookingDateException(string message) : base(message)
        {

        }
    }
}
