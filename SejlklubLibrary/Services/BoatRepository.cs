using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Services
{
    public class BoatRepository : IBoatRepository
    {
        private List<Boat> _boatList;
        
        public BoatRepository() 
        {
        
        }

        public int Count { get; set; }

        public void AddBoat(Boat boat)
        {
            throw new NotImplementedException();
        }

        public List<Boat> GetAll()
        {
            throw new NotImplementedException();
        }

        public Boat GetBoatById(int id)
        {
            throw new NotImplementedException();
        }

        public void PrintAllBoats()
        {
            throw new NotImplementedException();
        }

        public void RemoveBoat(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateBoat(Boat newBoat, int oldBoatId)
        {
            throw new NotImplementedException();
        }
    }
}
