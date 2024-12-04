using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;

namespace Razor.Pages.Events
{
    public class DeleteEventsModel : PageModel
    {
        public IEventRepository _eventRepository;

        [BindProperty]
        public Event Event { get; set; }

        public DeleteEventsModel(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public void OnGet(int id)
        {
            Event = _eventRepository.GetEventByID(id);
        }

        public IActionResult OnPost() 
        {
            _eventRepository.RemoveEvent(Event.Id);
            return RedirectToPage("ShowEvents");
        }
    }
}
