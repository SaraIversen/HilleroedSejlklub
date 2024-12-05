using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;

namespace Razor.Pages.Events
{
    public class AddEventModel : PageModel
    {
        public IEventRepository _eventRepository;

        [BindProperty]
        public Event Event { get; set; }
        [BindProperty]
        public string Name {get;set;}
        [BindProperty]
        public string Date { get; set; }
        [BindProperty]
        public string Location { get; set; }
        [BindProperty]
        public string Description { get; set; }


        public AddEventModel(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost() 
        {
            Event events = new Event(Name, Date, Description, Location);
            _eventRepository.AddEvent(events);
            return RedirectToPage("ShowEvents");
        }
    }
   
}
