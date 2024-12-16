using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Exceptions.Members;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SejlklubLibrary.Exceptions.Members;

namespace SejlklubLibrary.Models
{
    public class Member : IMember
    {
        private static int _counter = 0;
        private int _id;

        public Member()
        {
            MemberImage = "default.jpeg";
		}

        public Member(string name, string email, string address, string phone, MemberType memberStatus, bool isCoach, bool isAdmin) 
        {
            if (phone.Length != 8)
            {
                throw new InvalidPhoneNumberException("The phone number is not the legal length of 8");
            }
            if (name.Length < 2)
            {
                throw new InvalidNameLengthException("The name has an invalid length");
            }
            if (!(memberStatus == MemberType.Junior || memberStatus == MemberType.Senior || memberStatus == MemberType.Passiv))
            {
                throw new InvalidMemberTypeException("The member status is not a valid member type");
            }
			MemberImage = "default.jpeg";
			_counter++;
            _id = _counter;
            Name = name;
            Email = email;
            Address = address;
            Phone = phone;
            MemberStatus = memberStatus;
            IsCoach = isCoach;
            IsAdmin = isAdmin;
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
        public bool IsCoach { get; set; }
        public bool IsAdmin { get; set; }

		public override string ToString()
		{
			return $"ID: {_id}\nName: {Name}\nPhone: {Phone}\nEmail: {Email}\nAddress: {Address}\nMember Status: {MemberStatus}";
		}
	}
}
