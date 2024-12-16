using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;
using SejlklubLibrary.Services;

namespace Razor.Pages.Bookings
{
    public class AddBookingModel : PageModel
    {
        public IBookingRepository _bookingRepository;
        public IMemberRepository _memberRepository;
        public IBoatRepository _boatRepository;

        public List<BookingTime> BookingTimes { get; set; }

        public string MessageMember { get; set; }
        public string MessageBooking { get; set; }


        [BindProperty] public string SearchMemberPhone { get; set; }
        public Member Member { get; set; }

        [BindProperty] public DateTime ChosenDate { get; set; } = DateTime.Now;
        public DateTime Date { get; set; }

        [BindProperty] public int ChosenBoatType { get; set; }
        public List<SelectListItem> BoatTypeSelectList { get; set; }
        [BindProperty] public Boat Boat { get; private set;  }

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

                Boat = _bookingRepository.CurrentBoat;
                if (Boat != null)
                {
                    Date = _bookingRepository.CurrentDate;
                    // Check if the StartTime of this BookingTime is already booked
                    isDisabled = (!_bookingRepository.ValidateBooking(Date.ToString("d"), BookingTimes[i], Boat.BoatType)); //GetAllBookings().Any(b => b.StartTime == BookingTimes[i].StartTime);
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
            BookingTimes = _bookingRepository.GetAllBookingTimes();

            if (_bookingRepository.CurrentMember != null)
            {
                Member = _bookingRepository.CurrentMember;
            }
            if (_bookingRepository.CurrentBoat != null)
            {
                Boat = _bookingRepository.CurrentBoat;
            }
        }

        public IActionResult OnPostMember()
        {
            Member = _memberRepository.GetMemberByPhone(SearchMemberPhone);
            if (Member == null)
                MessageMember = "Member does not exist - create a new member";
            else
                _bookingRepository.CurrentMember = Member;

            BookingTimes = _bookingRepository.GetAllBookingTimes();
            Date = _bookingRepository.CurrentDate;
            return Page();
        }

        public IActionResult OnPostNewBoatChosen()
        {
            Boat = _boatRepository.GetBoatById(ChosenBoatType);
            if (Boat == null)
                MessageBooking = "Boat does not exist - choose another boat type";
            else
                _bookingRepository.CurrentBoat = Boat;

            BookingTimes = _bookingRepository.GetAllBookingTimes();
            Member = _bookingRepository.CurrentMember;
            Date = _bookingRepository.CurrentDate;
            CreateTimeSelectList();
            return Page();
        }

        public IActionResult OnPostNewDateChosen()
        {
            Date = ChosenDate;
            if (Date < DateTime.Today)
                MessageBooking = "Please select a valid date - it is not possible to book in the present";
            else
                _bookingRepository.CurrentDate = Date;

            BookingTimes = _bookingRepository.GetAllBookingTimes();
            Member = _bookingRepository.CurrentMember;
            CreateTimeSelectList();
            return Page();
        }

        public IActionResult OnPostAcceptBooking()
        {
            Member = _bookingRepository.CurrentMember;
            if (Member == null)
            {
                MessageMember = Member == null ? "Please select a member" : "";
                return Page();
            }
            Date = _bookingRepository.CurrentDate;
            if (Date < DateTime.Today) // Tjek om datoen er før dags dato.
            {
                MessageMember = Date < DateTime.Today ? "Please select a valid date - it is not possible to book in the present" : "";
                return Page();
            }
            Boat = _bookingRepository.CurrentBoat;
            if (Boat == null)
            {
                MessageBooking = Boat == null ? "Please select a boat type" : "";
                return Page();
            }
            if (ChosenLocation == null)
            {
                MessageBooking = ChosenLocation == null ? "Please select a location" : "";
                return Page();
            }
            if (BookingTimes[ChosenTime] == null)
            {
                MessageBooking = BookingTimes[ChosenTime] == null ? "Please select a time period" : "";
                return Page();
            }
            if (!_bookingRepository.NewBooking(Date.ToString("d"), BookingTimes[ChosenTime], ChosenLocation, Boat, Member))
            {
                // The date and time for the boat was probably already booked.
                MessageBooking = "Please select a valid date and time period for your booking";
                return Page();
            }
            // Reset the chosen boat and date when a booking was successfull. (member will still be there)
            _bookingRepository.CurrentBoat = null;
            _bookingRepository.CurrentDate = DateTime.Now;
            return RedirectToPage("ShowBookings");
        }
    }
}
