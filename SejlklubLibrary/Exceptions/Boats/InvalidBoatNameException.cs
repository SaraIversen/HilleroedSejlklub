using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Exceptions.Boats
{
    public class InvalidBoatNameException : Exception
    {
        public InvalidBoatNameException() : base()
        {

        }
        public InvalidBoatNameException(string message) : base(message)
        {

        }
    }
}
