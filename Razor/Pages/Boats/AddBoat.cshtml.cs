using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SejlklubLibrary.Exceptions.Boats;
using SejlklubLibrary.Exceptions.Events;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;

namespace Razor.Pages.Boats
{
    public class AddBoatModel : PageModel
    {
        private IBoatRepository _boatRepo;
        private BoatType _boatType;
        public List<SelectListItem> BoatTypeSelectList { get; set; }
        public string ErrorMessage { get; set; }
        [BindProperty] //Two way binding
        public Boat Boat { get; set; }

        [BindProperty]
        public BoatType ChosenBoatType { get; set; }
        public AddBoatModel(IBoatRepository boatRepository)
        {
            _boatRepo = boatRepository;
            createBoatTypeSelectList();
        }

        private void createBoatTypeSelectList()
        {
            BoatTypeSelectList = new List<SelectListItem>();
            BoatTypeSelectList.Add(new SelectListItem("Vælg Bådtype", "-1"));
            foreach(BoatType boattype in Enum.GetValues(typeof(BoatType)).Cast<BoatType>())
            {
                SelectListItem sl1 = new SelectListItem(boattype.ToString(), boattype.ToString());
                BoatTypeSelectList.Add(sl1);
            }
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            try
            {
            Boat.BoatType = ChosenBoatType;
            _boatRepo.AddBoat(Boat);
            return RedirectToPage("ShowBoats");
            }
            catch (InvalidBoatNameException ex)
            {
                ErrorMessage = ex.Message;
                return Page();
            }
            catch (InvalidBoatCharacterLengthException exp)
            {
                ErrorMessage = exp.Message;
                return Page();
            }
            catch (NullException nul)
            {
                ErrorMessage = nul.Message;
                return Page();
            }
        }
    }
}
