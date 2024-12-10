using SejlklubLibrary.Data;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Services
{
    public class ParticipantRepository:IParticipantRepository
    {
        //public List<Member> _participants;

        //public ParticipantRepository()
        //{
        //    _participants = new List<Member>();
        //    _participants = MockData.MemberData.Values.ToList();
        //}

        public List<Member> GetAllParticipants(Event ev)
        {
            return ev.Participants;
        }

        public void AddMemberToEvent(Event ev, Member member)
        {
            if (!ev.Participants.Contains(member))
            {
                ev.Participants.Add(member);
            }

            //Member foundMember = member;
            //if (foundMember != null)
            //{
            //    _participants.Add(foundMember);
            //}
        }

        public void RemoveMemberFromEvent(Event ev, Member member)
        {
            foreach (Member participant in ev.Participants)
            {
                if (participant == member)
                {
                    ev.Participants.Remove(member);
                }
            }
        }
    }
}
