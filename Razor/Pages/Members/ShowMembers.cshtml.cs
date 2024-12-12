using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;

namespace Razor.Pages.Members
{
    public class ShowMembersModel : PageModel
    {
        private IMemberRepository _memberRepository;

        [BindProperty(SupportsGet = true)]
        public string FilterCriteriaName { get; set; }

        public List<SelectListItem> MemberTypeSelectList { get; set; }

        [BindProperty(SupportsGet = true)]
        public MemberType ChosenMemberType { get; set; }
        public List<Member> Members { get; private set; }

        public ShowMembersModel(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
            createMemberTypeSelectList();
        }

        private void createMemberTypeSelectList()
        {
            List<MemberType> memberTypes = new List<MemberType>() { MemberType.Senior, MemberType.Junior, MemberType.Passiv };
            MemberTypeSelectList = new List<SelectListItem>();
            MemberTypeSelectList.Add(new SelectListItem("Select a member type", "-1"));
            int i = 0;
            foreach (MemberType memberType in memberTypes)
            {
                SelectListItem sli = new SelectListItem(memberType.ToString(), i.ToString());
                MemberTypeSelectList.Add(sli);
                i++;
            }
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

        public void OnPostFilterByMemberType()
        {
            Members = _memberRepository.FilterMembersByMemberType(ChosenMemberType);
        }
    }
}
