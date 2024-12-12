using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;

namespace Razor.Pages.Boats
{
    public class MaintenanceLogModel : PageModel
    {
        public IBoatRepository _boatRepository;

        public List<BoatReparationModel> boatReparations { get; set; } = new List<BoatReparationModel>();
        public void OnGet()
        {
        }
    }
}
