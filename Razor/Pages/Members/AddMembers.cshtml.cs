using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;

namespace Razor.Pages.Members
{
    public class AddMembersModel : PageModel
    {
        private IMemberRepository _repo;

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Address { get; set; }

        [BindProperty]
        public string Phone { get; set; }

        [BindProperty]
        public MemberType MemberStatus { get; set; }

        public AddMembersModel(IMemberRepository memberRepository)
        {
            _repo = memberRepository;
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            Member member = new Member(Name, Email, Address, Phone, MemberStatus);
            _repo.AddMember(member);
            return RedirectToPage("ShowMembers");
        }
    }
}
