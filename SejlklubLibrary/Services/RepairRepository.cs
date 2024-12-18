using SejlklubLibrary.Exceptions.Boats;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
            this.ValidateComments(boatReparation.Comment);
            _repairList.Add(boatReparation);
        }

        public void ValidateComments(string comment)
        {
            if (comment == null)
            {
                throw new NullException($"Kommentaren skal være udfyldt.");
            }
        }

        public int RepairBoatCount() 
        { 
            return _repairList.Count;
        }
    }
}
