using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;

namespace Razor.Pages.Boats
{
    public class DeleteBoatModel : PageModel
    {
        private IBoatRepository _repo;

        [BindProperty]
        public Boat Boat { get; set; }
        public DeleteBoatModel(IBoatRepository boatRepository)
        {
            _repo = boatRepository;
        }
        public void OnGet(int deleteId)
        {
            Boat = _repo.GetBoatById(deleteId);
        }

        public IActionResult OnPost()
        {
            _repo.RemoveBoat(Boat.Id);
            return RedirectToPage("ShowBoats");
        }
    }
}
