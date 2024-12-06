using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;

namespace Razor.Pages.Members
{
    public class EditMembersModel : PageModel
    {
        private IMemberRepository _repo;

        [BindProperty]
        public Member Member { get; set; }

        public EditMembersModel(IMemberRepository memberRepository)
        {
            _repo = memberRepository;
        }
        public void OnGet(int id)
        {
            Member = _repo.GetMemberById(id);
        }

        public IActionResult OnPost()
        {
            _repo.UpdateMember(Member);
            return RedirectToPage("ShowMembers");
        }
    }
}
