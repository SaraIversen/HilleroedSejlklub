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
        
        }

        //public BoatReparation GetRepairById()
        //{
        //    foreach (BoatReparation boatReparation in _boatList)
        //    {
        //        if (boat.Id == id)
        //        {
        //            return boat;
        //        }
        //    }
        //    return null;
        //}

        public void AddBoatReparation(BoatReparation boatReparation)
        {
            _repairList.Add(boatReparation);
        }
    }
}
