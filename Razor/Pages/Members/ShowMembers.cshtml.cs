using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;

namespace Razor.Pages.Members
{
    public class ShowMembersModel : PageModel
    {
        private IMemberRepository _memberRepository;

        [BindProperty(SupportsGet = true)]
        public string FilterCriteriaName { get; set; }
        public List<Member> Members { get; private set; }

        public ShowMembersModel(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }
        public void OnGet()
        {
            if (!string.IsNullOrEmpty(FilterCriteriaName))
            {
                Members = _memberRepository.FilterMembersByName(FilterCriteriaName);
            }
            else
            {
				Members = _memberRepository.GetAll();
			}
        }
    }
}
