using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Exceptions.Members
{
	internal class InvalidSalaryException : Exception
	{
        public InvalidSalaryException() : base()
        {
            
        }

        public InvalidSalaryException(string message) : base(message)
        {
            
        }
    }
}
