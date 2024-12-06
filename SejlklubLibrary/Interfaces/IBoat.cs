using SejlklubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Interfaces
{
    public interface IBoat
    {
        BoatType BoatType { get; }
        string Measurement { get; }
        bool IsBooked { get; set; }
        int Id { get; }
        string Name { get; set; }
        string Engine { get; set; }
        int BuildYear { get; }

        string ToString();
    }
}
