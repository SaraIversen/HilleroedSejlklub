using SejlklubLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Models
{
    public class Booking : IBooking
    {
        private static int _counter = 0;

        public int Id { get; }
        public DateTime Date { get; }
        public BookingTime BookingTime { get; }
        public string Place { get; }
        public Boat Boat { get; }
        public Member Member { get; }

        public Booking(DateTime date, BookingTime bookingTime, string place, Boat boat, Member member)
        {
            Id = _counter;
            _counter+=1;

            Date = date;
            BookingTime = bookingTime;
            Place = place;
            Boat = boat;
            Member = member;
        }

        public override string ToString()
        {
            return ($"\nId: {Id}, " +
                    $"\nDate: {Date.ToString("d")}, " +
                    $"\nBookingTime: {BookingTime.ToString()}, " +
                    $"\nLocation: {Place}, " +
                    $"\nBoatType: {Boat.BoatType}, " +
                    $"\nBoatName: {Boat.Name} " +
                    $"\nMember: {Member.Name}");
        }
    }
}
