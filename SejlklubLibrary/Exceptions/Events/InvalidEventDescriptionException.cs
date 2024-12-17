using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Exceptions.Events
{
    public class InvalidEventDescriptionException:Exception
    {
        public InvalidEventDescriptionException():base()
        {
            
        }
        public InvalidEventDescriptionException(string message):base(message)
        {
            
        }
    }
}
