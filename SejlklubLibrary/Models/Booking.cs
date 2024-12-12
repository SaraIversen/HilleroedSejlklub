﻿using SejlklubLibrary.Interfaces;
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
        public BookingTime BookingTime { get; }
        public string Place { get; }
        public Boat Boat { get; }
        public Member Member { get; }

        public Booking(string date, BookingTime bookingTime, string place, Boat boat, Member member)
        {
            Id = _counter;
            _counter+=1;

            Date = date;
            BookingTime = bookingTime;
            Place = place;
            Boat = boat;
            Member = member;
        }
    }
}
