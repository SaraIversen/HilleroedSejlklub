using SejlklubLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.SejlklubLibrary.Interfaces;

namespace SejlklubLibrary.Models
{
    public class Member : IMember
    {
        private static int _counter = 0;
        private int _id;

        public Member() 
        {
            _counter++;
            _id = _counter;
        }
        public string MemberStatus { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Id { get { return _id; } }
        public string Address { get; set; }
    }
}
