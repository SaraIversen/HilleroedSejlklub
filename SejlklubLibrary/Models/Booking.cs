using SejlklubLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Models
{
    public class Booking : IBooking
    {
        private static int _counter = 0;

        public int Id { get; }
        public DateTime Date { get; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get;}
        public string Place { get; }
        public Boat Boat { get; }
        public bool IsAvailable { get; set; } // SKAL MULIGVIS FJERNES ???
        public Member Member { get; set; }

        public Booking(DateTime date, DateTime startTime, DateTime endTime, string place, Boat boat)
        {
            Id = _counter;
            _counter+=1;

            Date = date;
            StartTime = startTime;
            EndTime = endTime;
            Place = place;
            Boat = boat;
            IsAvailable = true;
        }
    }
}
