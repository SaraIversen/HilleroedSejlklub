using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Services
{
    public class RepairRepository : IRepairRepository
    {
        private List<BoatReparation> _repairList;

        public RepairRepository() 
        {
            _repairList = new List<BoatReparation>();
        }

        public List<BoatReparation> GetAll()
        {
            return new List<BoatReparation>(_repairList);
        }
        public void AddBoatReparation(BoatReparation boatReparation)
        {
            _repairList.Add(boatReparation);
        }

        public int RepairBoatCount() 
        { 
            return _repairList.Count;
        }
    }
}
