using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Exceptions.Events
{
    public class InvalidEventNameException:Exception
    {
        public InvalidEventNameException():base()
        {
            
        }
        public InvalidEventNameException(string message):base(message)
        {
            
        }
    }
}
