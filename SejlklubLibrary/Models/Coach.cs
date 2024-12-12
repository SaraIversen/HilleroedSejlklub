using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Models
{
	public class Coach : Member
	{
        private double _salaryPerHour;
        private bool _certificate;
        public Coach(string name, string email, string address, string phone, MemberType memberStatus, double salaryPerhour, bool certificate) : base(name, email, address, phone, memberStatus)
        {
            _salaryPerHour = salaryPerhour;
            _certificate = certificate;
        }
        public double SalaryPerHour 
        { 
            get { return _salaryPerHour; } 
            set { _salaryPerHour = value; } 
        }
        public bool Certificate 
        { 
            get { return _certificate; } 
            set { _certificate = value; } 
        }

		public override string ToString()
		{
			return base.ToString() + $"\nSalary Per Hour: {_salaryPerHour}\nHas Certification: {_certificate}";
		}
	}
}
