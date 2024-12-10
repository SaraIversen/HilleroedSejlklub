using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;

namespace Razor.Pages.Bookings
{
    public class DeleteBookingModel : PageModel
    {
        public IBookingRepository _bookingRepository;

        public Member Member { get; set; }
        public Booking Booking { get; set; }

        public DeleteBookingModel(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public void OnGet(int id)
        {
            Booking = _bookingRepository.GetBookingById(id);
            Member = Booking.Member;
        }

        public IActionResult OnPostDeleteBooking(int id)
        {
            _bookingRepository.RemoveBooking(id);
            return RedirectToPage("ShowBookings");
        }
    }
}
