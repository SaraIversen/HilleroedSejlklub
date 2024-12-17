using SejlklubLibrary.Data;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;
using SejlklubLibrary.Exceptions.Members;
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
			else
			{
				throw new MemberExistsException("The member already exists in the repository");
			}
		}

		public Member GetMemberByPhone(string phone)
		{
			if (_members.ContainsKey(phone))
			{
				return _members[phone];
			}
			return null;
		}

		public Member GetMemberById(int id)
		{
			foreach (Member member in _members.Values)
			{
				if (member.Id == id)
				{
					return member;
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
			else
			{
				throw new MemberDoesNotExistException("The member does not exist in the repository");
			}
		}

		public void UpdateMember(Member member)
		{
			if (_members.ContainsKey(member.Phone))
			{
				_members[member.Phone] = member;
			}
			else
			{
				throw new MemberDoesNotExistException("The member does not exist in the repository");
			}
		}
		
		public List<Member> FilterMembersByName(string name)
		{
			List<Member> filterList = new List<Member>();
			foreach (Member member in _members.Values)
			{
				if (member.Name.Contains(name))
				{
					filterList.Add(member);
				}
			}
			return filterList;
		}

		public List<Member> FilterMembersByMemberType(MemberType memberType)
		{
			List<Member> filterList = new List<Member>();
			foreach (Member member in _members.Values)
			{
				if (member.MemberStatus == memberType)
				{
					filterList.Add(member);
				}
			}
			return filterList;
		}

		public List<Member> SearchMemberByPhone(string phone)
		{
			List<Member> members = new List<Member>();
			foreach (Member member in _members.Values)
			{
				if (member.Phone == phone)
				{
					members.Add(member);
				}
			}
			return members;
		}
	}
}
