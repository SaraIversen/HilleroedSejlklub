using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;

namespace Razor.Pages.Members
{
    public class DeleteMembersModel : PageModel
    {
        private IMemberRepository _repo;

        [BindProperty]
        public Member Member { get; set; }

        public DeleteMembersModel(IMemberRepository memberRepoistory)
        {
            _repo = memberRepoistory;
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            _repo.RemoveMember(Member.Phone);
            return RedirectToPage("ShowMembers");
        }
    }
}
