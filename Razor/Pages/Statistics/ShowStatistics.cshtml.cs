using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SejlklubLibrary.Models;
using SejlklubLibrary.Services;

namespace Razor.Pages.Statistics
{
    public class ShowStatisticsModel : PageModel
    {
        public Member Member { get; set; }
        public int MemberCount { get; set; }

        public Boat Boat { get; set; }
        public int BoatCount { get; set; }

        public BookingTime BookingTime { get; set; }
        public int BookingTimeCount { get; set; }

        public void OnGet()
        {
            Member = StatisticsRepository.GetMemberWithMostBookings();
            if (Member != null) MemberCount = StatisticsRepository.MemberBookingsCount[Member];
            Boat = StatisticsRepository.GetBoatWithMostBookings();
            if (Boat != null) BoatCount = StatisticsRepository.BoatBookingsCount[Boat];
            BookingTime = StatisticsRepository.GetMostBookedTime();
            if (BookingTime != null) BookingTimeCount = StatisticsRepository.BookingTimesCount[BookingTime];
        }
    }
}
