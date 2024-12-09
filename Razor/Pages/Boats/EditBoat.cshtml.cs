using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;

namespace Razor.Pages.Boats
{
    public class EditBoatModel : PageModel
    {
        private IBoatRepository _boatRepo;

        [BindProperty]
        public Boat Boat { get; set; }


        public EditBoatModel(IBoatRepository boatRepository)
        {
            _boatRepo = boatRepository;
        }

        public void OnGet(int id)
        {
            Boat = _boatRepo.GetBoatById(id);
        }

        public IActionResult OnPost()
        {
            _boatRepo.UpdateBoat(Boat);
            return RedirectToPage("ShowBoats");
        }
    }
}
