using SejlklubLibrary.Data;
using SejlklubLibrary.Exceptions.Bookings;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SejlklubLibrary.Services
{
    public class BookingRepository : IBookingRepository
    {
        private List<Booking> _bookingsList = new List<Booking>();

        // Ligesom da vi lavede ShoppingBasket, skal vi have et sted at gemme de nuværende data fra dem der prøver at booke.  
        public Member CurrentMember { get; set; } 
        public Boat CurrentBoat { get; set; }
        public DateTime CurrentDate { get; set; } = DateTime.Now;

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

        public string NewBooking(DateTime date, BookingTime bookingTime, string location, Boat boat, Member member)
        {
            try
            {
                if (ValidateBooking(date, bookingTime, location, boat, member))
                {
                    Booking newBooking = new Booking(date, bookingTime, location, boat, member);
                    AddBooking(newBooking);
                }
            }
            catch (NullException nullEx)
            {
                return ($"Please make sure all fields are filled out: " + nullEx.Message);
            }
            catch (InvalidBookingDateException invBookDateEx)
            {
                return ($"Please select a valid date - it is not possible to book in the present: " + invBookDateEx.Message);
            }
            catch (InvalidBookingTimeException invBookTimeEx)
            {
                return ($"Please select a free time period: " + invBookTimeEx.Message);
            }

            return "";
        }

        private void AddBooking(Booking booking)
        {
            _bookingsList.Add(booking);
            StatisticsRepository.RegisterBooking(booking);
        }

        public bool ValidateBooking(DateTime date, BookingTime bookingTime, string location, Boat boat, Member member)
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
                StatisticsRepository.UnRegisterBooking(foundBooking);
                _bookingsList.Remove(foundBooking);
            }
        }

        public List<Booking> FilterBookingsByDate()
        {
            List<Booking> filterList = _bookingsList;
            filterList.Sort((d1, d2) => d1.Date.CompareTo(d2.Date));

            return filterList;
        }

        public List<Booking> FilterBookingsByBoatName()
        {
            List<Booking> filterList = _bookingsList;
            filterList.Sort((b1, b2) => b1.Boat.Name.CompareTo(b2.Boat.Name));

            return filterList;
        }

        public List<Booking> FilterBookingsByTime()
        {
            List<Booking> filterList = _bookingsList;
            filterList.Sort((t1, t2) => t1.BookingTime.StartTime.CompareTo(t2.BookingTime.StartTime));

            return filterList;
        }

        public List<Booking> FilterBookingsByDateAndTime()
        {
            List<Booking> filterList = _bookingsList;

            filterList.Sort((b1, b2) =>
            { 
                // Sort by date first
                int compareDateResult = b1.Date.CompareTo(b2.Date);
                if (compareDateResult == 0) // If dates are the same, then compare by StartTime
                    return b1.BookingTime.StartTime.CompareTo(b2.BookingTime.StartTime);
                return compareDateResult;
            });

            return filterList;
        }

        public List<Booking> FilterBookingsByName()
        {
            List<Booking> filterList = _bookingsList;
            filterList.Sort((n1, n2) => n1.Member.Name.CompareTo(n2.Member.Name));

            return filterList;
        }

        public void PrintAllBookings()
        {
            throw new NotImplementedException();
        }
    }
}
