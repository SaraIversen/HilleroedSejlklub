using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;

namespace Razor.Pages.Members
{
    public class ShowAdministratorsModel : PageModel
    {
        private IMemberRepository _memberRepository;

        public List<Member> Administrators { get; private set; }

        public ShowAdministratorsModel(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }
        public void OnGet()
        {
            List<Member> administrators = new List<Member>();
            foreach (Member member in _memberRepository.GetAll())
            {
                if (member.IsAdmin)
                {
                    administrators.Add(member);
                }
            }
            Administrators = administrators;
        }
    }
}
