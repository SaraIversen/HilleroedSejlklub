using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;

namespace Razor.Pages.Boats
{
    public class BoatReparationModel : PageModel
    {
        private IBoatRepository _bRepo;

        public Boat Boat { get; set; }
        public string Comment { get; set; }

        public BoatReparationModel(IBoatRepository boatRepository)
        {
            _bRepo = boatRepository;
        }

        public void OnGet(int id)
        {
            Boat = _bRepo.GetBoatById(id);
        }
        public IActionResult OnPost()
        {
            //_bRepo.(Boat);
            return RedirectToPage("ShowBoats");
        }
    }
}
