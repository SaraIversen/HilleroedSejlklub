using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;

namespace Razor.Pages.Bookings
{
    public class AddBookingModel : PageModel
    {
        public IBookingRepository _bookingRepository;
        public IMemberRepository _memberRepository;
        public IBoatRepository _boatRepository;

        public List<BookingTime> BookingTimes { get; set; }


        [BindProperty] public string SearchMemberPhone { get; set; }
        public Member Member { get; set; }

        [BindProperty] public DateTime ChosenDate { get; set; } = DateTime.Now;

        [BindProperty] public int ChosenBoatType { get; set; }
        public List<SelectListItem> BoatTypeSelectList { get; set; }
        //[BindProperty] public Boat Boat { get; set;  }

        [BindProperty] public string ChosenLocation { get; set; }

        [BindProperty] public int ChosenTime { get; set; }
        public List<SelectListItem> TimeSelectList { get; set; }


        public AddBookingModel(IBookingRepository bookingRepository, IMemberRepository memberRepository, IBoatRepository boatRepository)
        {
            _bookingRepository = bookingRepository;
            _memberRepository = memberRepository;
            _boatRepository = boatRepository;

            CreateBoatSelectList();
            CreateTimeSelectList();
        }

        private void CreateBoatSelectList()
        {
            BoatTypeSelectList = new List<SelectListItem>();
            BoatTypeSelectList.Add(new SelectListItem("Vælg bådtype", "-1"));
            foreach (Boat boat in _boatRepository.GetAll())
            {
                SelectListItem selectListItem = new SelectListItem(boat.BoatType.ToString(), boat.Id.ToString());
                BoatTypeSelectList.Add(selectListItem);
            }
        }

        private void CreateTimeSelectList()
        {
            TimeSelectList = new List<SelectListItem>();
            TimeSelectList.Add(new SelectListItem("Select a time", "-1"));
            BookingTimes = _bookingRepository.GetAllBookingTimes();
            for (int i = 0; i < BookingTimes.Count; i++)
            {
                bool isDisabled = false;

                Boat chosenBoat = _boatRepository.GetBoatById(ChosenBoatType);
                if (chosenBoat != null)
                {
                    // Check if the StartTime of this BookingTime is already booked
                    isDisabled = (!_bookingRepository.ValidateBooking(ChosenDate.ToString("d"), BookingTimes[i], chosenBoat.BoatType)); //GetAllBookings().Any(b => b.StartTime == BookingTimes[i].StartTime);
                }

                SelectListItem selectListItem = new SelectListItem
                {
                    Text = $"{BookingTimes[i].StartTime}-{BookingTimes[i].EndTime}" + (isDisabled ? " (Booked)" : ""),
                    Value = i.ToString(),
                    Disabled = isDisabled
                };
                TimeSelectList.Add(selectListItem);
            }
        }

        public void OnGet()
        {
            //ChosenDate = DateTime.Now;
            BookingTimes = _bookingRepository.GetAllBookingTimes();

            if (_bookingRepository.CurrentMember != null)
            {
                Member = _bookingRepository.CurrentMember;
            }
        }

/*        public IActionResult OnPostNewBoatChosen()
        {
            Member = _bookingRepository.CurrentMember;
            if (Member == null)
            {
                // Show some errors ????
                return Page();
            }
            //ChosenDate = DateTime.Now;
            if (ChosenBoatType == -1)
            {
                // Show some errors ????
                return Page();
            }
            Boat = _boatRepository.GetBoatById(ChosenBoatType);
            if (Boat == null)
            {
                // Show some errors ????
                return Page();
            }
            BookingTimes = _bookingRepository.GetAllBookingTimes();
            CreateTimeSelectList();
            return Page();
        }*/

        public IActionResult OnPostMember()
        {
            if (SearchMemberPhone == null)
            {
                return Page();
            }
            Member = _memberRepository.GetMemberByPhone(SearchMemberPhone);
            _bookingRepository.CurrentMember = Member;
            if (Member == null)
            {
                // Error message ?????
            }
            //ChosenDate = DateTime.Now;
            BookingTimes = _bookingRepository.GetAllBookingTimes();
            return Page();
        }

        public IActionResult OnPostAcceptBooking()
        {
            Member = _bookingRepository.CurrentMember;
            if (Member == null)
            {
                // Show some errors ????
                return Page();
            }
            /*            if (Date == null) // Tjek om datoen er før dags dato.
                        {
                            // Show some errors ????
                            return Page();
                        }*/
            Boat chosenBoat = _boatRepository.GetBoatById(ChosenBoatType);
            if (chosenBoat == null)
            {
                // Show some errors ????
                return Page();
            }
            if (ChosenLocation == null)
            {
                // Show some errors ????
                return Page();
            }
            if (BookingTimes[ChosenTime] == null)
            {
                // Show some errors ????
                return Page();
            }
            if (!_bookingRepository.NewBooking(ChosenDate.ToString("d"), BookingTimes[ChosenTime], ChosenLocation, chosenBoat, Member))
            {
                // The date and time for the boat was probably already booked.
                // Show some errors ????
                return Page();
            }
            return RedirectToPage("ShowBookings");
        }
    }
}
