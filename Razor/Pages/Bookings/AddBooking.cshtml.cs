using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SejlklubLibrary.Exceptions.Bookings;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;
using SejlklubLibrary.Services;

namespace Razor.Pages.Bookings
{
    public class AddBookingModel : PageModel
    {
        private IBookingRepository _bookingRepository;
        private IMemberRepository _memberRepository;
        private IBoatRepository _boatRepository;

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
            BoatTypeSelectList.Add(new SelectListItem("V�lg b�d", "-1"));
            foreach (Boat boat in _boatRepository.GetAll())
            {
                SelectListItem selectListItem = new SelectListItem($"{boat.Name} ({boat.BoatType})", boat.Id.ToString());
                BoatTypeSelectList.Add(selectListItem);
            }
        }

        private void CreateTimeSelectList()
        {
            TimeSelectList = new List<SelectListItem>();
            TimeSelectList.Add(new SelectListItem("Select a time", "-1"));
            for (int i = 0; i < BookingTimesRepository.BookingTimes.Count; i++)
            {
                bool isDisabled = false;

                Boat = _bookingRepository.CurrentBoat;
                if (Boat != null) // If a bout has been chosen for the booking.
                {
                    Date = _bookingRepository.CurrentDate;
                    // Check if the date and startTime for this boat is already booked.
                    isDisabled = (!_bookingRepository.ValidateBookingTime(Date, BookingTimesRepository.BookingTimes[i], Boat.BoatType));
                }

                SelectListItem selectListItem = new SelectListItem
                {
                    Text = BookingTimesRepository.BookingTimes[i].ToString() + (isDisabled ? " (Booked)" : ""),
                    Value = i.ToString(),
                    Disabled = isDisabled
                };
                TimeSelectList.Add(selectListItem);
            }
        }

        public void OnGet()
        {
            if (_bookingRepository.CurrentMember != null)
                Member = _bookingRepository.CurrentMember;

            if (_bookingRepository.CurrentBoat != null)
                Boat = _bookingRepository.CurrentBoat;
        }

        public IActionResult OnPostMember()
        {
            Member = _memberRepository.GetMemberByPhone(SearchMemberPhone);
            if (Member == null)
                MessageBooking = "Member does not exist - create a new member";
            else
                _bookingRepository.CurrentMember = Member;

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

            Member = _bookingRepository.CurrentMember;
            CreateTimeSelectList();
            return Page();
        }

        public IActionResult OnPostAcceptBooking()
        {
            Member = _bookingRepository.CurrentMember;
            Boat = _bookingRepository.CurrentBoat;
            Date = _bookingRepository.CurrentDate;

            try
            {
                _bookingRepository.NewBooking(Date, BookingTimesRepository.BookingTimes[ChosenTime], ChosenLocation, Boat, Member);
            }
            catch (NullException nullEx)
            {
                MessageBooking = ($"Please make sure all fields are filled out: " + nullEx.Message);
                return Page();
            }
            catch (InvalidBookingDateException invBookDateEx)
            {
                MessageBooking = ($"Please select a valid date - it is not possible to book in the present: " + invBookDateEx.Message);
                return Page();
            }
            catch (InvalidBookingTimeException invBookTimeEx)
            {
                MessageBooking = ($"Please select a free time period: " + invBookTimeEx.Message);
                return Page();
            }

            // Reset member, boat and date when a booking was successfull.
            _bookingRepository.CurrentMember = null;
            _bookingRepository.CurrentBoat = null;
            _bookingRepository.CurrentDate = DateTime.Now;
            return RedirectToPage("ShowBookings");
        }
    }
}
