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

        public List<BookingTime> BookingTimes { get; set; }

        public int Count { get { return _bookingsList.Count; } }

        public BookingRepository()
        {
            _bookingsList = MockData.BookingData;

            BookingTimes = new List<BookingTime>(); // SKAL NOK VÆRE ET ANDET STED?
            BookingTimes.Add(new BookingTime("11:00", "11:55"));
            BookingTimes.Add(new BookingTime("12:00", "12:55"));
            BookingTimes.Add(new BookingTime("13:00", "13:55"));
            BookingTimes.Add(new BookingTime("14:00", "14:55"));
            BookingTimes.Add(new BookingTime("15:00", "15:55"));
            BookingTimes.Add(new BookingTime("16:00", "16:55"));
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

        public void NewBooking(string date, string startTime, string endTime, string place, Boat boat, Member member)
        {
            Booking newBooking = new Booking(date, startTime, endTime, place, boat, member);
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
