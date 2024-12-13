using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;

namespace Razor.Pages.Events
{
    public class ParticipateModel : PageModel
    {
        private IMemberRepository _memberRepository;
        private IEventRegistrationRepository _eventRegistrationRepository;
        private IEventRepository _eventRepository;

        [BindProperty]
        public string FindMemberByPhone { get; set; }
        [BindProperty]
        public Member TheMember { get; set; }
        [BindProperty]
        public Event Event { get; set; }
        [BindProperty]
        public DateTime TimeOfRegistration { get; set; }
        [BindProperty]
        public string Comment { get; set; }
        [BindProperty]
        public int Guests { get; set; }

        public List<Event> Events { get; set; }
        public List<EventRegistration> Participants {get;set;}= new List<EventRegistration>();

        public ParticipateModel(IMemberRepository memberRepository, IEventRegistrationRepository eventRegistrationRepository, IEventRepository eventRepository)
        {
            _memberRepository = memberRepository;
            _eventRegistrationRepository = eventRegistrationRepository;
            _eventRepository = eventRepository;
            //Participants 
        }
        public void OnGet(int eventId)
        {
            Event = _eventRepository.GetEventByID(eventId);
            Participants = _eventRegistrationRepository.GetAllParticipants(Event);
        }

        public void OnPostMember() 
        {
            TheMember = _memberRepository.GetMemberByPhone(FindMemberByPhone);
        }

        public IActionResult OnPostAddToEvent() 
        {
            if (!(TheMember == null||Event==null||Comment==null ))
            {
                _eventRegistrationRepository.AddRegistrationToEvent(Event, Comment, TimeOfRegistration, Guests, TheMember);
            }

            return Page();
        }
    }
}
