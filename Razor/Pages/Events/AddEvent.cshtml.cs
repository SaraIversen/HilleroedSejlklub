using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SejlklubLibrary.Exceptions.Events;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;

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
        public string Description { get; set; }
        [BindProperty]
        public EventType EventType { get; set; }
        public AddEventModel(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost() 
        {
            try 
            {
                Event events = new Event(Name, Date, Description, Location, EventType);
                _eventRepository.AddEvent(events);
                return RedirectToPage("ShowEvents");
            }
            catch (InvalidEventName ex)
            {
                ErrorMessage = ex.Message;
                return Page();
            }
            
        }
    }
}
