using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Exceptions
{
	public class InvalidNameLengthException : Exception
	{
        public InvalidNameLengthException() : base()
        {
            
        }

        public InvalidNameLengthException(string message) : base(message)
        {
            
        }
    }
}
