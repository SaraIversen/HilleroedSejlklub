using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;

namespace Razor.Pages.Boats
{
    public class ShowBoatsModel : PageModel
    {
        public IBoatRepository _boatRepository;

        public List<SelectListItem> BoatTypeSelectList { get; set; }
        public List<Boat> Boats { get; set; }

        [BindProperty(SupportsGet = true)]
        public BoatType ChosenBoatType { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchCriteriaName { get; set; }

        public ShowBoatsModel(IBoatRepository boatRepository)
        {
            _boatRepository = boatRepository;
            createBoatTypeSelectList();
        }

        private void createBoatTypeSelectList()
        {
            List<BoatType> boatTypes = new List<BoatType>() { BoatType.Optimistjolle, BoatType.TERA, BoatType.FEVA, BoatType.Laserjolle, BoatType.Europajolle, BoatType.Snipejolle, BoatType.Wayfarer, BoatType.Lynæs };
            BoatTypeSelectList = new List<SelectListItem>();
            BoatTypeSelectList.Add(new SelectListItem("Select a boat type", "-1"));
            int i = 0;
            foreach (BoatType boatType in boatTypes)
            {
                SelectListItem sli = new SelectListItem(boatType.ToString(), i.ToString());
                BoatTypeSelectList.Add(sli);
                i++;
            }
        }
        public void OnGet()
        {
            Boats = _boatRepository.GetAll();
        }

        public void OnPostFilterByBoatType()
        {
            Boats = _boatRepository.FilterByBoatType(ChosenBoatType);
        }
        public void OnPostSearchBoatByName()
        {
            Boats = _boatRepository.SearchBoatByName(SearchCriteriaName);
        }
    }
}
