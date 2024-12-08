﻿using SejlklubLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Models
{
    public class Member : IMember
    {
        private static int _counter = 0;
        private int _id;

        public Member()
        {
            MemberImage = "default.jpeg";
			_counter++;
			_id = _counter;
		}

        public Member(string name, string email,string address, string phone, MemberType memberStatus) 
        {
			MemberImage = "default.jpeg";
			_counter++;
            _id = _counter;
            Name = name;
            Email = email;
            Address = address;
            Phone = phone;
            MemberStatus = memberStatus;
        }
        public string MemberImage { get; set; }
        public MemberType MemberStatus { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Id 
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Address { get; set; }
        public string Name { get; set; }

		public override string ToString()
		{
			return $"ID: {_id}\nName: {Name}\nPhone: {Phone}\nEmail: {Email}\nAddress: {Address}\nMember Status: {MemberStatus}";
		}
	}
}
