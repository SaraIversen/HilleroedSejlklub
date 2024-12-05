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

        public AddEventModel(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost() 
        {
            _eventRepository.AddEvent(Event);
            return RedirectToPage("ShowEvents");
        }
    }
   
}
