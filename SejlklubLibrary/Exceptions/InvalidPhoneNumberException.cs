﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Exceptions
{
	internal class InvalidPhoneNumberException : Exception
	{
        public InvalidPhoneNumberException() : base()
        {
            
        }

        public InvalidPhoneNumberException(string message) : base(message)
        {
            
        }
    }
}
