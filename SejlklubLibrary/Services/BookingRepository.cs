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

        public int Count { get { return _bookingsList.Count; } }

        public BookingRepository()
        {
            _bookingsList = MockData.BookingData;
        }

        public List<Booking> GetAll()
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

        public void NewBooking(string date, string startTime, string endTime, string place, Boat boat)
        {
            Booking newBooking = new Booking(DateTime.Parse(date), DateTime.Parse(startTime), DateTime.Parse(endTime), place, boat);
            _bookingsList.Add(newBooking);
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
