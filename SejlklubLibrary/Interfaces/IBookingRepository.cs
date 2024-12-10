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
        Member CurrentMember { get; set; } // Ligesom da vi lavede ShoppingBasket, skal vi have et sted at gemme det nuværende medlem der prøver at booke. 
        int CountBookings { get; }
        int CountBookingTimes { get; } 

        List<Booking> GetAllBookings();
        List<BookingTime> GetAllBookingTimes();
        Booking GetBookingById(int id);
        bool NewBooking(string date, string startTime, string endTime, string place, Boat boat, Member member);
        void RemoveBooking(int id);
        //void UpdateBooking(Booking booking);
        //void BookBoat(Booking booking, Member member);
        void PrintAllBookings();
        string ToString();
    }
}
