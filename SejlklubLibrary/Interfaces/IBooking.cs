using SejlklubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Interfaces
{
    public interface IBooking
    {
        int Id { get; }
        DateTime Date { get; }
        DateTime StartTime { get; }
        DateTime EndTime { get; }
        string Place { get; }
        Boat Boat { get; }
        bool IsAvailable { get; } // SKAL MULIGVIS FJERNES ???
        Member Member { get; }

        string ToString();
    }
}
