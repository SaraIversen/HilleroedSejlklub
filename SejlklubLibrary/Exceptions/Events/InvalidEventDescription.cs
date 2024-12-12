using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Exceptions.Events
{
    public class InvalidEventDescription:Exception
    {
        public InvalidEventDescription():base()
        {
            
        }
        public InvalidEventDescription(string message):base(message)
        {
            
        }
    }
}
