using SejlklubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Interfaces
{
    public interface IBookingRepository
    {
        // Ligesom da vi lavede ShoppingBasket, skal vi have et sted at gemme de nuværende data fra dem der prøver at booke.  
        Member CurrentMember { get; set; }
        Boat CurrentBoat { get; set; }
        public DateTime CurrentDate { get; set; }

        int CountBookings { get; }
        int CountBookingTimes { get; } 

        List<Booking> GetAllBookings();
        List<BookingTime> GetAllBookingTimes();
        Booking GetBookingById(int id);
        bool NewBooking(string date, BookingTime bookingTime, string place, Boat boat, Member member);
        bool ValidateBooking(string date, BookingTime bookingTime, BoatType boatType);
        void RemoveBooking(int id);
        void PrintAllBookings();
        string ToString();
    }
}
