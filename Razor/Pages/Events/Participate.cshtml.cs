using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;

namespace Razor.Pages.Events
{
    public class ParticipateModel : PageModel
    {
        private IMemberRepository _memberRepository;
        private IParticipantRepository _participantRepository;
        private IEventRepository _eventRepository;

        [BindProperty]
        public string FindMemberByPhone { get; set; }
        [BindProperty]
        public Member TheMember { get; set; }
        [BindProperty]
        public Event Event { get; set; }
        [BindProperty]
        public int Guests { get; set; }

        public List<Event> Events { get; set; }
        public List<Member> Participants {get;set;}

        public ParticipateModel(IMemberRepository memberRepository, IParticipantRepository participantRepository,IEventRepository eventRepository)
        {
            _memberRepository = memberRepository;
            _participantRepository = participantRepository;
            _eventRepository = eventRepository;
            Participants = new List<Member>();
        }
        public void OnGet(int eventId)
        {
            Event = _eventRepository.GetEventByID(eventId);
        }

        public void OnPostMember() 
        {
            TheMember = _memberRepository.GetMemberByPhone(FindMemberByPhone);
        }

        public IActionResult OnPostAddTOEvent() 
        {
            if (TheMember != null)
            {
                _participantRepository.AddMemberToEvent(Event, TheMember);
            }

            return Page();
        }
    }
}
