using SejlklubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Services
{
    public static class BookingTimesRepository
    {
        public static List<BookingTime> BookingTimes { get; } = new List<BookingTime>()
            {
                new BookingTime("11:00", "11:55"),
                new BookingTime("12:00", "12:55"),
                new BookingTime("13:00", "13:55"),
                new BookingTime("14:00", "14:55"),
                new BookingTime("15:00", "15:55"),
                new BookingTime("16:00", "16:55")
            };
    }
}
