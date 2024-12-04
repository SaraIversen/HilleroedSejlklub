using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Interfaces
{
    public interface IMember
    {
        string MemberStatus { get; set; }
        string Phone { get; set;}
        string Email { get; set; }
        int Id {  get; }
        string Address { get; set; }

        string ToString();
    }
}
