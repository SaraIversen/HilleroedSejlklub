using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;

namespace Razor.Pages.Boats
{
    public class MaintenanceLogModel : PageModel
    {
        public IBoatRepository _boatRepository;
        public List<BoatReparation> _repairList;
        public MaintenanceLogModel(IBoatRepository boatRepository) 
        { 
            _boatRepository = boatRepository;
        }
        public void OnGet()
        {
        }
        
    }
}
