using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;

namespace Razor.Pages.Events
{
    public class ShowEventsModel : PageModel
    {
        private IEventRepository _eventRepository;

        [BindProperty]
        public EventType ChosenEventType { get; set; }
        [BindProperty(SupportsGet =true)]
        public string ChosenName { get; set; }
        public List<Event> Events { get; set; }
        public List<SelectListItem> SelectListEventTypes { get; set; }
        public ShowEventsModel(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
            createSelectListEventTypes();
        }
        
        public void OnGet()
        {
            if (!string.IsNullOrEmpty(ChosenName) )
            {
                Events = _eventRepository.FilterEventByName(ChosenName);
            }
            else 
            { 
                Events = _eventRepository.GetAll();
            }
        }

        public void createSelectListEventTypes()
        {
            List<EventType> eventTypes = new List<EventType>() { EventType.Udflugt, EventType.Standerhejsning, EventType.Sejltur, EventType.Spisning, EventType.StortForKlubben, EventType.Kursus };
            SelectListEventTypes = new List<SelectListItem>();
            SelectListEventTypes.Add(new SelectListItem("Vælg en Type", "-1"));
            int i = 0;
            foreach (EventType eventType in eventTypes)
            {
                SelectListItem selectListItem = new SelectListItem(eventType.ToString(),i.ToString());
                SelectListEventTypes.Add(selectListItem);
                i++;
            }
        }

        public void OnPostFiltherByEventType() 
        {
            Events = _eventRepository.FilterEventByEventType(ChosenEventType);
        }
    }
}
