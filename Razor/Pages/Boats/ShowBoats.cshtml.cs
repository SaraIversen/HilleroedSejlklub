using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;

namespace Razor.Pages.Boats
{
    public class ShowBoatsModel : PageModel
    {
        public IBoatRepository _boatRepository;

        public List<Boat> Boats { get; set; }

        public ShowBoatsModel(IBoatRepository boatRepository)
        {
            _boatRepository = boatRepository;
        }
        public void OnGet()
        {
            Boats = _boatRepository.GetAll();
        }
    }
}
