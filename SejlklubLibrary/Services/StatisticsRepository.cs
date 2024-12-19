using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Services
{
    public static class StatisticsRepository
    {
        public static Dictionary<Member, int> MemberBookingsCount = new Dictionary<Member, int>();
        public static Dictionary<Boat, int> BoatBookingsCount = new Dictionary<Boat, int>();
        public static Dictionary<BookingTime, int> BookingTimesCount = new Dictionary<BookingTime, int>();

        public static void RegisterBooking(Booking booking)
        {
            RegisterMemberBooking(booking.Member);
            RegisterBoatBooking(booking.Boat);
            RegisterBookingTime(booking.BookingTime);
        }

        private static void RegisterMemberBooking(Member member)
        {
            if (!MemberBookingsCount.ContainsKey(member))
            {
                MemberBookingsCount.Add(member, 0);
            }
            MemberBookingsCount[member] += 1;
        }
        private static void RegisterBoatBooking(Boat boat)
        {
            if (!BoatBookingsCount.ContainsKey(boat))
            {
                BoatBookingsCount.Add(boat, 0);
            }
            BoatBookingsCount[boat] += 1;
        }
        private static void RegisterBookingTime(BookingTime bookingTime)
        {
            if (!BookingTimesCount.ContainsKey(bookingTime))
            {
                BookingTimesCount.Add(bookingTime, 0);
            }
            BookingTimesCount[bookingTime] += 1;
        }

        public static void UnregisterBooking(Booking booking)
        {
            UnregisterMemberBooking(booking.Member);
            UnregisterBoatBooking(booking.Boat);
            UnregisterBookingTime(booking.BookingTime);
        }

        private static void UnregisterMemberBooking(Member member)
        {
            if (MemberBookingsCount.ContainsKey(member) && MemberBookingsCount[member] > 0)
            {
                MemberBookingsCount[member] -= 1;
            }
        }
        private static void UnregisterBoatBooking(Boat boat)
        {
            if (BoatBookingsCount.ContainsKey(boat) && BoatBookingsCount[boat] > 0)
            {
                BoatBookingsCount[boat] -= 1;
            }
        }
        private static void UnregisterBookingTime(BookingTime bookingTime)
        {
            if (BookingTimesCount.ContainsKey(bookingTime) && BookingTimesCount[bookingTime] > 0)
            {
                BookingTimesCount[bookingTime] -= 1;
            }
        }

        public static Member GetMemberWithMostBookings()
        {
            if (MemberBookingsCount.Count == 0) return null; // Return null if there are no bookings

            KeyValuePair<Member, int> foundMember = MemberBookingsCount.OrderByDescending(entry => entry.Value).FirstOrDefault();
            if (foundMember.Value <= 0) return null;

            return foundMember.Key;
        }

        public static Boat GetBoatWithMostBookings()
        {
            if (BoatBookingsCount.Count == 0) return null; // Return null if there are no bookings

            KeyValuePair<Boat, int> foundBoat = BoatBookingsCount.OrderByDescending(entry => entry.Value).FirstOrDefault();
            if (foundBoat.Value <= 0) return null;

            return foundBoat.Key;
        }

        public static BookingTime GetMostBookedTime()
        {
            if (BookingTimesCount.Count == 0) return null; // Return null if there are no bookings

            KeyValuePair<BookingTime, int> foundBookingTime = BookingTimesCount.OrderByDescending(entry => entry.Value).FirstOrDefault();
            if (foundBookingTime.Value <= 0) return null;

            return foundBookingTime.Key;
        }
    }
}
