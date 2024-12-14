using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;

namespace Razor.Pages.Members
{
    public class ShowCoachesModel : PageModel
    {
		private IMemberRepository _memberRepository;

        public List<Member> Coaches { get; private set; }

        public ShowCoachesModel(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }
        public void OnGet()
        {
            List<Member> coaches = new List<Member>();
            foreach (Member member in _memberRepository.GetAll())
            {
                if (member.IsCoach)
                {
                    coaches.Add(member);
                }
            }
            Coaches = coaches;
        }
    }
}
