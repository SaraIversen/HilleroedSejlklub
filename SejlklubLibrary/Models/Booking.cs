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
        public string Date { get; }
        public string StartTime { get; }
        public string EndTime { get;}
        public string Place { get; }
        public Boat Boat { get; }
        //public bool IsAvailable { get; set; } // SKAL MULIGVIS FJERNES ???
        public Member Member { get; }

        public Booking(string date, string startTime, string endTime, string place, Boat boat, Member member)
        {
            Id = _counter;
            _counter+=1;

            Date = date;
            StartTime = startTime;
            EndTime = endTime;
            Place = place;
            Boat = boat;
            //IsAvailable = true;
            Member = member;
        }
    }
}
