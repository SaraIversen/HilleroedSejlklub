using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;

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
            Bookings = _bookingRepository.GetAll();
        }
    }
}
