using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;
using SejlklubLibrary.Services;
using System.Xml.Linq;

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

        [BindProperty] public int ChosenBoat { get; set; }
        public List<SelectListItem> BoatSelectList { get; set; }

        [BindProperty] public string ChosenPlace { get; set; }
        public string Place { get; set; }

        [BindProperty] public DateTime ChosenTime { get; set; }
        public List<SelectListItem> TimeSelectList { get; set; }
        public List<string> BookingTimes { get; set; } // SKAL NOK VÆRE ET ANDET STED?


        public ShowBookingsModel(IBookingRepository bookingRepository, IMemberRepository memberRepository, IBoatRepository boatRepository)
        {
            _bookingRepository = bookingRepository;
            _memberRepository = memberRepository;
            _boatRepository = boatRepository;

            BookingTimes = new List<string>(); // SKAL NOK VÆRE ET ANDET STED?
            BookingTimes.Add("11-11:55");
            BookingTimes.Add("12-12:55");
            BookingTimes.Add("13-13:55");
            BookingTimes.Add("14-14:55");
            BookingTimes.Add("15-15:55");
            BookingTimes.Add("16-16:55");
            BookingTimes.Add("17-17:55");

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
            for (int i = 0; i < BookingTimes.Count; i++)
            {
                SelectListItem selectListItem = new SelectListItem(BookingTimes[i], i.ToString());
                TimeSelectList.Add(selectListItem);
            }
        }

        public void OnGet()
        {
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
            //Member = _memberRepository.GetMemberByPhone(SearchMemberPhone);
            Boat chosenBoat = _boatRepository.GetBoatById(ChosenBoat);
            Place = ChosenPlace;
            if (chosenBoat == null)
            {
                // Show some errors ????
                return Page();
            }
            if (Place == null)
            {
                // Show some errors ????
                return Page();
            }
            _bookingRepository.NewBooking("06/06/2025", "11:00", "12:00", Place, chosenBoat);
            Bookings = _bookingRepository.GetAll();
            return Page();
        }
    }
}
