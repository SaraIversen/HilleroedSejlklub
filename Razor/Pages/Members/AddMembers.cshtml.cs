using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;

namespace Razor.Pages.Members
{
    public class AddMembersModel : PageModel
    {
        private IMemberRepository _repo;
        private IWebHostEnvironment webHostEnvironment;

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

        [BindProperty]
        public IFormFile Photo { get; set; }

        public AddMembersModel(IMemberRepository memberRepository, IWebHostEnvironment webHost)
        {
            _repo = memberRepository;
            webHostEnvironment = webHost;
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            Member member = new Member(Name, Email, Address, Phone, MemberStatus);
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Photo != null)
            {
                if (member.MemberImage != null && member.MemberImage != "default.jpeg")
                {
                    string filepath = Path.Combine(webHostEnvironment.WebRootPath, "/images/memberImages", member.MemberImage);
                    System.IO.File.Delete(filepath);
                }
                member.MemberImage = processUploadedFile();
            }
            _repo.AddMember(member);
            return RedirectToPage("ShowMembers");
        }

        private string processUploadedFile()
        {
            string uniqueFileName = null;
            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images/memberImages");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var filestream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(filestream);
                }
            }
            return uniqueFileName;
        }
    }
}
