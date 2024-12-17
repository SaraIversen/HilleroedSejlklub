using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Exceptions.Events
{
    public class InvalidEventLocationException:Exception
    {
        public InvalidEventLocationException():base()
        {
            
        }

        public InvalidEventLocationException(string message):base(message)
        {
        }
    }
}
