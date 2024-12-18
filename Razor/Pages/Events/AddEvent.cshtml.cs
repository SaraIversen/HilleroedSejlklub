using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SejlklubLibrary.Exceptions.Events;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;
using SejlklubLibrary.Services;

namespace Razor.Pages.Events
{
    public class AddEventModel : PageModel
    {
        public IEventRepository _eventRepository;
        public string ErrorMessage { get; set; }

        [BindProperty]
        public Event Event { get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public DateTime Date { get; set; }
        [BindProperty]
        public string Location { get; set; }
        [BindProperty]
        public EventType ChosenEventType { get; set; }
        [BindProperty]
        public string Description { get; set; }
        
        public EventType EventType { get; set; }

        public List<SelectListItem> SelectListEventTypes { get; set; }

        public AddEventModel(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
            createSelectListEventTypes();
        }
        public void OnGet()
        {

        }
        public void createSelectListEventTypes() 
        {
            SelectListEventTypes = new List<SelectListItem>();
            SelectListEventTypes.Add(new SelectListItem("Vælg en Type", "-1"));
            foreach (Event events in _eventRepository.GetAll()) 
            {
                SelectListItem selectListItem = new SelectListItem(events.EventType.ToString(),events.Id.ToString());
                SelectListEventTypes.Add(selectListItem);
            }
        }
        public IActionResult OnPost() 
        {
            try
            {
                Event events = new Event(Name, Date, Description, Location, EventType);
                _eventRepository.AddEvent(events);
                return RedirectToPage("ShowEvents");
            }
            catch (InvalidEventNameException ex)
            {
                ErrorMessage = ex.Message;
                return Page();
            }
            catch (InvalidEventTypeException ex)
            {
                ErrorMessage = ex.Message;
                return Page();
            }
            catch (InvalidEventLocationException ex)
            {
                ErrorMessage = ex.Message;
                return Page();
            }
            catch (InvalidEventDescriptionException ex)
            {
                ErrorMessage = ex.Message;
                return Page();
            }
            //catch (Exception exp)
            //{
            //    ErrorMessage = "General Exception";
            //    return Page();
            //}

        }
    }
}
