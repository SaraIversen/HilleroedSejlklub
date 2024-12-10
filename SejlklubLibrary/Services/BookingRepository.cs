using SejlklubLibrary.Data;
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

        public Member CurrentMember { get; set; } // Ligesom da vi lavede ShoppingBasket, skal vi have et sted at gemme det nuværende medlem der prøver at booke.  

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

        public bool NewBooking(string date, string startTime, string endTime, string place, Boat boat, Member member)
        {
            if (!ValidateBooking(date, startTime, boat)) return false;

            Booking newBooking = new Booking(date, startTime, endTime, place, boat, member);
            _bookingsList.Add(newBooking);
            return true;
        }

        private bool ValidateBooking(string date, string startTime, Boat boat)
        {
            foreach (Booking booking in _bookingsList)
            {
                if (booking.Boat.BoatType == boat.BoatType 
                    && booking.Date == date 
                    && booking.StartTime == startTime)
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
                _bookingsList.Remove(foundBooking);
            }
        }

/*        public void UpdateBooking(Booking booking)
        {
            throw new NotImplementedException();
        }

        public void BookBoat(Booking booking, Member member)
        {
            booking.Member = member;
            booking.IsAvailable = false;
        }*/

        public void PrintAllBookings()
        {
            throw new NotImplementedException();
        }
    }
}
