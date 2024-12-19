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
        private IBookingRepository _bookingRepository;
        private IMemberRepository _memberRepository;
        private IBoatRepository _boatRepository;

        public List<Booking> Bookings { get; set; }

        [BindProperty] public BoatType ChosenBoatType { get; set; }
        public List<SelectListItem> BoatTypeSelectList { get; set; }

        [BindProperty] public int ChosenMember { get; set; }
        public List<SelectListItem> MemberSelectList { get; set; }


        public ShowBookingsModel(IBookingRepository bookingRepository, IMemberRepository memberRepository, IBoatRepository boatRepository)
        {
            _bookingRepository = bookingRepository;
            _memberRepository = memberRepository;
            _boatRepository = boatRepository;

            CreateBoatSelectList();
            CreateMemberSelectList();
        }

        private void CreateBoatSelectList()
        {
            BoatTypeSelectList = new List<SelectListItem>();
            int i = 0;
            foreach (BoatType boatType in Enum.GetValues(typeof(BoatType)))
            {
                SelectListItem selectListItem = new SelectListItem($"{boatType}", i.ToString());
                BoatTypeSelectList.Add(selectListItem);
                i += 1;
            }
        }

        private void CreateMemberSelectList()
        {
            MemberSelectList = new List<SelectListItem>();
            MemberSelectList.Add(new SelectListItem("Vælg medlem", "-1"));
            int i = 0;
            foreach (Member member in _memberRepository.GetAll())
            {
                SelectListItem selectListItem = new SelectListItem($"{member.Name}", member.Id.ToString());
                MemberSelectList.Add(selectListItem);
                i += 1;
            }
        }

        public void OnGet()
        {
            Bookings = _bookingRepository.GetAllBookings();
        }

        public IActionResult OnPostSortBookingsDate()
        {
            Bookings = _bookingRepository.SortBookingsByDate();
            return Page();
        }
        public IActionResult OnPostSortBookingsBoat()
        {
            Bookings = _bookingRepository.SortBookingsByBoatName();
            return Page();
        }
        public IActionResult OnPostSortBookingsTime()
        {
            Bookings = _bookingRepository.SortBookingsByTime();
            return Page();
        }
        public IActionResult OnPostSortBookingsDateAndTime()
        {
            Bookings = _bookingRepository.SortBookingsByDateAndTime();
            return Page();
        }
        public IActionResult OnPostSortBookingsMemberName()
        {
            Bookings = _bookingRepository.SortBookingsByName();
            return Page();
        }

        public IActionResult OnPostGetAllBookings()
        {
            Bookings = _bookingRepository.GetAllBookings();
            return Page();
        }

        public IActionResult OnPostFilterByBoatType()
        {
            Bookings = _bookingRepository.FilterByBoatType(ChosenBoatType);
            return Page();
        }

        public IActionResult OnPostFilterByMember()
        {
            Member member = _memberRepository.GetMemberById(ChosenMember);
            if (member != null)
                Bookings = _bookingRepository.FilterByMember(member);
            else
                Bookings = _bookingRepository.GetAllBookings();
            return Page();
        }
    }
}
