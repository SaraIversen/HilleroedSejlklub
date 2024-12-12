using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Models
{
	public class Administrator : Member
	{
		private double _salaryPerHour;
		private string _title;

        public Administrator(string name, string email, string address, string phone, MemberType memberStatus, double salaryPerHour, string title) : base(name, email, address, phone, memberStatus)
        {
            _salaryPerHour = salaryPerHour;
            _title = title;
        }

        public double SalaryPerHour
        {
            get { return _salaryPerHour; }
            set { _salaryPerHour = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

		public override string ToString()
		{
			return base.ToString() + $"\nSalary Per Hour: {_salaryPerHour}\nTitle: {_title}"; 
		}
	}
}
