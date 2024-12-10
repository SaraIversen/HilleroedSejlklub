using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SejlklubLibrary.Interfaces;

namespace Razor.Pages.Boats
{
    public class RepairBoatModel : PageModel
    {
        private IBoatRepository _bRepo;


        public void OnGet()
        {
        }
    }
}
