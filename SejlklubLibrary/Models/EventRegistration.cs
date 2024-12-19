using SejlklubLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Models
{
    public class EventRegistration : IEventRegistration
    {
        public string Comment { get; set; }
        public int GuestsAmount { get; set; }
        public Member Member { get; set; }

        public EventRegistration(string comment,int guestsAmount, Member member)
        {
            Comment = comment;
            GuestsAmount = guestsAmount;
            Member = member;
        }

        public override string ToString()
        {
            return "";
        }
    }
}
