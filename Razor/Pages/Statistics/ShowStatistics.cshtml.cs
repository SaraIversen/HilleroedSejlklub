using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SejlklubLibrary.Models;
using SejlklubLibrary.Services;

namespace Razor.Pages.Statistics
{
    public class ShowStatisticsModel : PageModel
    {
        public Member Member { get; set; }
        public Boat Boat { get; set; }
        public BookingTime BookingTime { get; set; }

        public void OnGet()
        {
            Member = StatisticsRepository.GetMemberWithMostBookings();
            Boat = StatisticsRepository.GetBoatWithMostBookings();
            BookingTime = StatisticsRepository.GetMostBookedTime();
        }
    }
}
