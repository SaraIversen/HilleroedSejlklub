using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;

namespace Razor.Pages.Events
{
    public class UpdateEventsModel : PageModel
    {
        public IEventRepository _eventRepository;

        [BindProperty]
        public Event Event { get; set; }

        [BindProperty]
        public EventType ChosenEventType { get; set; }

        public List<SelectListItem> SelectListEventTypes { get; set; }

        public UpdateEventsModel(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
            createSelectListEventTypes();
        }
        public void OnGet(int editId)
        {
            Event=_eventRepository.GetEventByID(editId);
        }
        public void createSelectListEventTypes()
        {
            SelectListEventTypes = new List<SelectListItem>();
            SelectListEventTypes.Add(new SelectListItem("Vælg en Type", "-1"));
            foreach (Event events in _eventRepository.GetAll())
            {
                SelectListItem selectListItem = new SelectListItem(events.EventType.ToString(), events.Id.ToString());
                SelectListEventTypes.Add(selectListItem);
            }
        }
        public IActionResult OnPost() 
        {
            _eventRepository.UpdateEvent(Event);
            return RedirectToPage("ShowEvents");
        }
    }
}
