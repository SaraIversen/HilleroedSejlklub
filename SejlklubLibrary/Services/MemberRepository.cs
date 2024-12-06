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
	public class MemberRepository : IMemberRepository
	{
		private Dictionary<string, Member> _members;
		public int Count { get { return _members.Count; } }

        public MemberRepository()
        {
			_members = MockData.MemberData;
        }

        public List<Member> GetAll()
		{
			return _members.Values.ToList();
		}
		public void AddMember(Member member)
		{
			if (!_members.ContainsKey(member.Phone))
			{
				_members.Add(member.Phone, member);
			}
		}

		public Member GetMemberByPhone(string phone)
		{
			if (_members.ContainsKey(phone))
			{
				foreach (Member member in _members.Values)
				{
					if (member.Phone == phone)
					{
						return member;
					}
				}
			}
			return null;
		}

		public void PrintAllMembers()
		{
			foreach (Member member in _members.Values)
			{
                Console.WriteLine(member);
			}
		}

		public void RemoveMember(string phone)
		{
			if (_members.ContainsKey(phone))
			{
				_members.Remove(phone);
			}
		}

		public void UpdateMembers(Member newMember, string oldMemberPhone)
		{
			if (_members.ContainsKey(oldMemberPhone))
			{
				_members.Remove(oldMemberPhone);
				AddMember(newMember);
			}
		}		
	}
}
