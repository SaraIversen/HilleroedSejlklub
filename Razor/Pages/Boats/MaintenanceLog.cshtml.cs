using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;

namespace Razor.Pages.Boats
{
    public class MaintenanceLogModel : PageModel
    {
        public IBoatRepository _boatRepository;
        public IRepairRepository _repairRepository;
        public MaintenanceLogModel(IBoatRepository boatRepository, IRepairRepository repairRepository) 
        { 
            _boatRepository = boatRepository;
            _repairRepository = repairRepository;
        }
        public List<BoatReparation> boatReparations { get; set; }
        public void OnGet()
        {
            boatReparations = _repairRepository.GetAll();
        }
        
    }
}
