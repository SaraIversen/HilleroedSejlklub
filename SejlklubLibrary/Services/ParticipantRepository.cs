﻿using SejlklubLibrary.Data;
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
        public List<Member> _participants;

        public ParticipantRepository()
        {
            _participants = new List<Member>();
            _participants = MockData.MemberData.Values.ToList();
        }

        public List<Member> GetAllParticipants()
        {
            return _participants;
        }

        public void AddMemberToEvent(Member member)
        {
            Member foundMember = member;
            if (foundMember != null)
            {
                _participants.Add(foundMember);
            }
        }

        public void RemoveMemberFromEvent(Member member)
        {
            foreach (Member participant in _participants)
            {
                if (participant == member)
                {
                    _participants.Remove(member);
                }
            }
        }
    }
}