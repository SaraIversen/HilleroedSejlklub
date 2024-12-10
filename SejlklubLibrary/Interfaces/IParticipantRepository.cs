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
        List<Member> GetAllParticipants();
        void AddMemberToEvent(Member member);
        void RemoveMemberFromEvent(Member member);
    }
}
