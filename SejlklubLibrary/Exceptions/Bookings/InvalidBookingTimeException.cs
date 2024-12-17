using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Exceptions.Bookings
{
    public class InvalidBookingTimeException : Exception
    {
        public InvalidBookingTimeException()
        {

        }

        public InvalidBookingTimeException(string message) : base(message)
        {

        }
    }
}
