﻿using SejlklubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Interfaces
{
    public interface IBookingRepository
    {
        List<BookingTime> BookingTimes { get; set; }
        int Count { get; }

        List<Booking> GetAll();
        Booking GetBookingById(int id);
        void NewBooking(string date, string startTime, string endTime, string place, Boat boat, Member member);
        void RemoveBooking(int id);
        //void UpdateBooking(Booking booking);
        //void BookBoat(Booking booking, Member member);
        void PrintAllBookings();
        string ToString();
    }
}
