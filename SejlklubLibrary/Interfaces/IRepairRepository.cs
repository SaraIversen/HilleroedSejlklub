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
        List<BoatReparation> GetAll();
        void AddBoatReparation(BoatReparation boatReparation);
        void ValidateComments(string comment);
        int RepairBoatCount();
    }
}
