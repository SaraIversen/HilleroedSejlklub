using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;

namespace Razor.Pages.Events
{
    public class ShowEventsModel : PageModel
    {
        public IEventRepository _eventRepository;

        public List<Event> Events { get; set; }

        public ShowEventsModel(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public void OnGet()
        {
            Events = _eventRepository.GetAll();
        }
    }
}
