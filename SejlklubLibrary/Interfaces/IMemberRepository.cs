﻿using SejlklubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Interfaces
{
	public interface IMemberRepository
	{
		int Count { get; }
		List<Member> GetAll();
		Member GetMemberByPhone(string phone);
		void AddMember(Member member);
		void RemoveMember(string phone);
		void PrintAllMembers();
		void UpdateMembers(Member newMember, string oldMemberPhone);
		string ToString();

	}
}
