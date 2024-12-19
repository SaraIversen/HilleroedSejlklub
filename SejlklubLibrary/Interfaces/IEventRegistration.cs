using SejlklubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Interfaces
{
    public interface IEventRegistration
    {
        string Comment { get; set; }
        int GuestsAmount { get; set; }
        Member Member { get; set; }

        string ToString();
    }
}
