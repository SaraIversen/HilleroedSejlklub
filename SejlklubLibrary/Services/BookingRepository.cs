﻿using SejlklubLibrary.Data;
using SejlklubLibrary.Exceptions.Bookings;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SejlklubLibrary.Services
{
    public class BookingRepository : IBookingRepository
    {
        private List<Booking> _bookingsList = new List<Booking>();

        // Ligesom da vi lavede ShoppingBasket, skal vi have et sted at gemme de nuværende data fra dem der prøver at booke.  
        public Member CurrentMember { get; set; } // Bruges kun til RazorPages.
        public Boat CurrentBoat { get; set; } // Bruges kun til RazorPages.
        public DateTime CurrentDate { get; set; } = DateTime.Now; // Bruges kun til RazorPages.

        public int Count { get { return _bookingsList.Count; } }

        public BookingRepository()
        {
            MockData.InitializeBookingMockData(this);
        }

        public List<Booking> GetAllBookings()
        {
            return _bookingsList;
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

        public Booking NewBooking(DateTime date, BookingTime bookingTime, string location, Boat boat, Member member)
        {
            if (ValidateBooking(date, bookingTime, location, boat, member))
            {
                Booking newBooking = new Booking(date, bookingTime, location, boat, member);
                AddBooking(newBooking);
                return newBooking;
            }
            return null;
        }

        private void AddBooking(Booking booking)
        {
            _bookingsList.Add(booking);
            StatisticsRepository.RegisterBooking(booking);
        }

        private bool ValidateBooking(DateTime date, BookingTime bookingTime, string location, Boat boat, Member member)
        {
            if (member == null)
            {
                throw new NullException($"Member could not be found.");
            }
            if (boat == null)
            {
                throw new NullException($"Boat could not be found.");
            }
            if (date < DateTime.Today) // Tjek om datoen er før dags dato.
            {
                throw new InvalidBookingDateException($"The chosen date was: {date.ToString("d")}.");
            }
            if (string.IsNullOrEmpty(location))
            {
                throw new NullException($"Location could not be found.");
            }
            if (bookingTime == null)
            {
                throw new NullException($"Time period could not be found.");
            }
            if (!ValidateBookingTime(date, bookingTime, boat.BoatType)) // Tjek om tidspunktet for båden og datoen er ledig.
            {
                throw new InvalidBookingTimeException($"The chosen date & time period was: {date.ToString("d")} {bookingTime.ToString()}.");
            }

            return true;
        }

        public bool ValidateBookingTime(DateTime date, BookingTime bookingTime, BoatType boatType)
        {
            foreach (Booking booking in _bookingsList)
            {
                if (booking.Boat.BoatType == boatType
                    && booking.Date.ToString("d") == date.ToString("d")
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
                StatisticsRepository.UnregisterBooking(foundBooking);
                _bookingsList.Remove(foundBooking);
            }
        }

        #region Sort & Filtering Methods
        public List<Booking> SortBookingsByDate()
        {
            List<Booking> sortList = _bookingsList;
            sortList.Sort((d1, d2) => d1.Date.CompareTo(d2.Date));

            return sortList;
        }

        public List<Booking> SortBookingsByBoatName()
        {
            List<Booking> sortList = _bookingsList;
            sortList.Sort((b1, b2) => b1.Boat.Name.CompareTo(b2.Boat.Name));

            return sortList;
        }

        public List<Booking> SortBookingsByTime()
        {
            List<Booking> sortList = _bookingsList;
            sortList.Sort((t1, t2) => t1.BookingTime.StartTime.CompareTo(t2.BookingTime.StartTime));

            return sortList;
        }

        public List<Booking> SortBookingsByDateAndTime()
        {
            List<Booking> sortList = _bookingsList;

            sortList.Sort((b1, b2) =>
            { 
                // Sort by date first
                int compareDateResult = b1.Date.CompareTo(b2.Date);
                if (compareDateResult == 0) // If dates are the same, then compare by StartTime
                    return b1.BookingTime.StartTime.CompareTo(b2.BookingTime.StartTime);
                return compareDateResult;
            });

            return sortList;
        }

        public List<Booking> SortBookingsByName()
        {
            List<Booking> sortList = _bookingsList;
            sortList.Sort((n1, n2) => n1.Member.Name.CompareTo(n2.Member.Name));

            return sortList;
        }

        public List<Booking> FilterByBoatType(BoatType boatType)
        {
            List<Booking> filterList = new List<Booking>();
            foreach (Booking booking in _bookingsList)
            {
                if (booking.Boat.BoatType == boatType)
                {
                    filterList.Add(booking);
                }
            }
            return filterList;
        }

        public List<Booking> FilterByMember(Member member)
        {
            List<Booking> filterList = new List<Booking>();
            foreach (Booking booking in _bookingsList)
            {
                if (booking.Member == member)
                {
                    filterList.Add(booking);
                }
            }
            return filterList;
        }
        #endregion

        public void PrintAllBookings()
        {
            foreach (Booking booking in _bookingsList)
            {
                Console.WriteLine($"Booking data - {booking.ToString()}\n");
            }
        }
    }
}
