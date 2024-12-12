using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Exceptions.Events
{
    public class InvalidEventName:Exception
    {
        public InvalidEventName():base()
        {
            
        }
        public InvalidEventName(string message):base(message)
        {
            
        }
    }
}
