using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Exceptions.Events
{
    public class InvalidEventType:Exception
    {
        public InvalidEventType():base()
        {
            
        }

        public InvalidEventType(string message):base(message)
        {
            
        }
    }
}
