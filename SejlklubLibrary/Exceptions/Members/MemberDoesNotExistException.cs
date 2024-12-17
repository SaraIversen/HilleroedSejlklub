using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Exceptions.Members
{
	internal class MemberDoesNotExistException : Exception
	{
        public MemberDoesNotExistException() : base()
        {
            
        }

        public MemberDoesNotExistException(string message) : base(message)
        {
            
        }
    }
}
