using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;
using SejlklubLibrary.Services;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Razor.Pages.Bookings
{
    public class ShowBookingsModel : PageModel
    {
        public IBookingRepository _bookingRepository;

        public List<Booking> Bookings { get; set; }


        public ShowBookingsModel(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public void OnGet()
        {
            Bookings = _bookingRepository.GetAllBookings();
        }

        public IActionResult OnPostFilterBookingsDate()
        {
            Bookings = _bookingRepository.FilterBookingsByDate();
            return Page();
        }
        public IActionResult OnPostFilterBookingsBoat()
        {
            Bookings = _bookingRepository.FilterBookingsByBoatName();
            return Page();
        }
        public IActionResult OnPostFilterBookingsTime()
        {
            Bookings = _bookingRepository.FilterBookingsByTime();
            return Page();
        }
        public IActionResult OnPostFilterBookingsDateAndTime()
        {
            Bookings = _bookingRepository.FilterBookingsByDateAndTime();
            return Page();
        }
        public IActionResult OnPostFilterBookingsMemberName()
        {
            Bookings = _bookingRepository.FilterBookingsByName();
            return Page();
        }
    }
}
