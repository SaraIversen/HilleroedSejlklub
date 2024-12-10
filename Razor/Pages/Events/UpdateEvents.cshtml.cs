using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;

namespace Razor.Pages.Events
{
    public class UpdateEventsModel : PageModel
    {
        public IEventRepository _eventRepository;

        [BindProperty]
        public Event Event { get; set; }

        public UpdateEventsModel(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
            
        }
        public void OnGet(int editId)
        {
            _eventRepository.GetEventByID(editId);
        }

        public IActionResult OnPost() 
        {
            _eventRepository.UpdateEvent(Event);
            return RedirectToPage("ShowEvents");
        }
    }
}
