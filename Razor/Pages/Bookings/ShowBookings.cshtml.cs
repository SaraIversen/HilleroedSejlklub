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
        public IMemberRepository _memberRepository;
        public IBoatRepository _boatRepository;

        public List<Booking> Bookings { get; set; }

        [BindProperty] public string SearchMemberPhone { get; set; }
        public Member Member { get; set; }

        [BindProperty] public DateTime ChosenDate { get; set; }
        public DateTime Date { get; set; }

        [BindProperty] public int ChosenBoat { get; set; }
        public List<SelectListItem> BoatSelectList { get; set; }

        [BindProperty] public string ChosenPlace { get; set; }
        public string Place { get; set; }

        [BindProperty] public int ChosenTime { get; set; }
        public List<SelectListItem> TimeSelectList { get; set; }


        public ShowBookingsModel(IBookingRepository bookingRepository, IMemberRepository memberRepository, IBoatRepository boatRepository)
        {
            _bookingRepository = bookingRepository;
            _memberRepository = memberRepository;
            _boatRepository = boatRepository;

            CreateBoatSelectList();
            CreateTimeSelectList();
        }

        private void CreateBoatSelectList()
        {
            BoatSelectList = new List<SelectListItem>();
            BoatSelectList.Add(new SelectListItem("Select a boat", "-1"));
            foreach (Boat boat in _boatRepository.GetAll())
            {
                SelectListItem selectListItem = new SelectListItem(boat.Name, boat.Id.ToString());
                BoatSelectList.Add(selectListItem);
            }
        }

        private void CreateTimeSelectList()
        {
            TimeSelectList = new List<SelectListItem>();
            TimeSelectList.Add(new SelectListItem("Select a time", "-1"));
            for (int i = 0; i < _bookingRepository.BookingTimes.Count; i++)
            {
                SelectListItem selectListItem = new SelectListItem($"{_bookingRepository.BookingTimes[i].StartTime}-{_bookingRepository.BookingTimes[i].EndTime}", i.ToString());
                TimeSelectList.Add(selectListItem);
            }
        }

        public void OnGet()
        {
            ChosenDate = DateTime.Now;
            Bookings = _bookingRepository.GetAll();
        }

        public IActionResult OnPostMember()
        {
            Member = _memberRepository.GetMemberByPhone(SearchMemberPhone);
            if (Member == null)
            {
                // Error message ?????
            }
            return Page();
        }

        public IActionResult OnPostAcceptBooking()
        {
            Member = _memberRepository.GetMemberByPhone(SearchMemberPhone);
            if (Member == null)
            {
                // Show some errors ????
                return Page();
            }
            Date = ChosenDate;
/*            if (Date == null) // Tjek om datoen er før dags dato.
            {
                // Show some errors ????
                return Page();
            }*/
            Boat chosenBoat = _boatRepository.GetBoatById(ChosenBoat);
            if (chosenBoat == null)
            {
                // Show some errors ????
                return Page();
            }
            Place = ChosenPlace;
            if (Place == null)
            {
                // Show some errors ????
                return Page();
            }
            if (_bookingRepository.BookingTimes[ChosenTime] == null)
            {
                // Show some errors ????
                return Page();
            }
            _bookingRepository.NewBooking(Date.ToString("d"), _bookingRepository.BookingTimes[ChosenTime].StartTime, _bookingRepository.BookingTimes[ChosenTime].EndTime, Place, chosenBoat, Member);
            Bookings = _bookingRepository.GetAll();
            return Page();
        }
    }
}
