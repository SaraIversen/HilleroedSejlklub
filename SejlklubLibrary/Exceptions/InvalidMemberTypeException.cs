using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Exceptions
{
	public class InvalidMemberTypeException : Exception
	{
        public InvalidMemberTypeException() : base()
        {
            
        }

        public InvalidMemberTypeException(string message) : base(message)
        {
            
        }
    }
}
