using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Exceptions.Boats
{
    public class NullException : Exception
    {
        public NullException() : base()
        {

        }
        public NullException(string message) : base(message)
        {

        }
    }
}
