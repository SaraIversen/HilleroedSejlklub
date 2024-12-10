using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Models
{
    public class BookingTime
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public BookingTime(string startTime, string endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
