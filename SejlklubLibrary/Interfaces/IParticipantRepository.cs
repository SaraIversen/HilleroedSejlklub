using SejlklubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Interfaces
{
    public interface IParticipantRepository
    {
        List<Member> GetAllParticipants(Event ev);
        void AddMemberToEvent(Event ev,Member member);
        void RemoveMemberFromEvent(Event ev, Member member);
    }
}
