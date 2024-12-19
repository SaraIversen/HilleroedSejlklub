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

        int Count { get; }

        List<Booking> GetAllBookings();
        Booking GetBookingById(int id);
        Booking NewBooking(DateTime date, BookingTime bookingTime, string place, Boat boat, Member member);
        bool ValidateBookingTime(DateTime date, BookingTime bookingTime, BoatType boatType);
        void RemoveBooking(int id);
        List<Booking> SortBookingsByDate();
        List<Booking> SortBookingsByBoatName();
        List<Booking> SortBookingsByTime();
        List<Booking> SortBookingsByDateAndTime();
        List<Booking> SortBookingsByName();
        List<Booking> FilterByBoatType(BoatType boatType);
        List<Booking> FilterByMember(Member member);
        void PrintAllBookings();
    }
}
