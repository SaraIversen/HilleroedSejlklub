using SejlklubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Services
{
    public class RepairRepository
    {
        private List<Boat> _repairList;

        public RepairRepository() 
        { 
        
        }

        public void AddRepair(Boat boat)
        {
            _repairList.Add(boat);
        }
    }
}
