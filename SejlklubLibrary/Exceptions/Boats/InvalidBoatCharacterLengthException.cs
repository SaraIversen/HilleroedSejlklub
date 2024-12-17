using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Exceptions.Boats
{
    public class InvalidBoatCharacterLengthException : Exception
    {
        public InvalidBoatCharacterLengthException() : base()
        {

        }
        public InvalidBoatCharacterLengthException(string message) : base(message)
        {

        }
    }
}
