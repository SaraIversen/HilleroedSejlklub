using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;

namespace Razor.Pages.Boats
{
    public class BoatReparationModel : PageModel
    {
        private IBoatRepository _bRepo;
        private IRepairRepository _repairRepo;
        [BindProperty]
        public BoatReparation BoatReparation { get; set; }
        [BindProperty]
        public Boat Boat { get; set; }

        public BoatReparationModel(IBoatRepository boatRepository, IRepairRepository repairRepository)
        {
            _bRepo = boatRepository;
            _repairRepo = repairRepository;
        }

        public void OnGet(int id)
        {
            Boat = _bRepo.GetBoatById(id);
            BoatReparation = new BoatReparation();
            BoatReparation.Boat = Boat;
        }
        public IActionResult OnPost()
        {
            _repairRepo.AddBoatReparation(BoatReparation);
            return RedirectToPage("MaintenanceLog");
        }
    }
}
