﻿using SejlklubLibrary.Data;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Services
{
    public class BookingRepository : IBookingRepository
    {
        private List<Booking> _bookingsList;
        private List<BookingTime> _bookingTimes;

        // Ligesom da vi lavede ShoppingBasket, skal vi have et sted at gemme de nuværende data fra dem der prøver at booke.  
        public Member CurrentMember { get; set; } 
        public Boat CurrentBoat { get; set; }
        public DateTime CurrentDate { get; set; } = DateTime.Now;

        public int CountBookings { get { return _bookingsList.Count; } }
        public int CountBookingTimes { get { return _bookingTimes.Count; } }

        public BookingRepository()
        {
            _bookingsList = new List<Booking>();//MockData.BookingData;

            InitializeBookingTimesList();
        }

        private void InitializeBookingTimesList()
        {
            _bookingTimes = new List<BookingTime>();
            _bookingTimes.Add(new BookingTime("11:00", "11:55"));
            _bookingTimes.Add(new BookingTime("12:00", "12:55"));
            _bookingTimes.Add(new BookingTime("13:00", "13:55"));
            _bookingTimes.Add(new BookingTime("14:00", "14:55"));
            _bookingTimes.Add(new BookingTime("15:00", "15:55"));
            _bookingTimes.Add(new BookingTime("16:00", "16:55"));
        }

        public List<Booking> GetAllBookings()
        {
            return _bookingsList;
        }

        public List<BookingTime> GetAllBookingTimes()
        {
            return _bookingTimes;
        }

        public Booking GetBookingById(int id)
        {
            foreach (Booking booking in _bookingsList)
            {
                if (booking.Id == id)
                {
                    return booking;
                }
            }
            return null;
        }

        public bool NewBooking(string date, BookingTime bookingTime, string place, Boat boat, Member member)
        {
            if (!ValidateBooking(date, bookingTime, boat.BoatType)) return false;

            Booking newBooking = new Booking(date, bookingTime, place, boat, member);
            AddBooking(newBooking);
            return true;
        }

        private void AddBooking(Booking booking)
        {
            _bookingsList.Add(booking);
            StatisticsRepository.RegisterBooking(booking);
        }

        public bool ValidateBooking(string date, BookingTime bookingTime, BoatType boatType)
        {
            foreach (Booking booking in _bookingsList)
            {
                if (booking.Boat.BoatType == boatType
                    && booking.Date == date 
                    && booking.BookingTime.StartTime == bookingTime.StartTime)
                {
                    return false;
                }
            }
            return true;
        }

        public void RemoveBooking(int id)
        {
            Booking foundBooking = GetBookingById(id);
            if (foundBooking != null)
            {
                StatisticsRepository.UnRegisterBooking(foundBooking);
                _bookingsList.Remove(foundBooking);
            }
        }

        public void PrintAllBookings()
        {
            throw new NotImplementedException();
        }
    }
}
