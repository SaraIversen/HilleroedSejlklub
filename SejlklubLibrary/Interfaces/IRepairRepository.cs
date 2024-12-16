using SejlklubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Interfaces
{
    public interface IRepairRepository
    {
        void AddBoatReparation(BoatReparation boatReparation);
    }
}
