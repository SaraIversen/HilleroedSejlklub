using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Exceptions.Events
{
    public class InvalidEventTypeException:Exception
    {
        public InvalidEventTypeException():base()
        {
            
        }

        public InvalidEventTypeException(string message):base(message)
        {
            
        }
    }
}
