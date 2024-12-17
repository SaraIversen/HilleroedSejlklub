using SejlklubLibrary.Data;
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
            _boatList = MockData.BoatData;
        }

        public int Count { get { return _boatList.Count; } }

        public void AddBoat(Boat boat)
        {
            foreach (Boat b in _boatList)
            {
                if (b == boat)
                {
                    return;
                }
            }
            boat.Counting();
            _boatList.Add(boat);
        }

        public List<Boat> GetAll()
        {
            return _boatList;
        }

        public Boat GetBoatById(int id)
        {
            foreach (Boat boat in _boatList)
            {
                if (boat.Id == id)
                {
                    return boat;
                }
            }
            return null;
        }

        public void PrintAllBoats()
        {
            foreach (Boat boat in _boatList)
            {
                Console.WriteLine(boat);
            }
        }

        public void RemoveBoat(int id)
        {
            Boat foundBoat = GetBoatById(id);
            if (foundBoat != null)
            {
                _boatList.Remove(foundBoat);
            }
        }

        public void UpdateBoat(Boat newBoat)
        {
            foreach (Boat boats in _boatList)
            {
                if (boats.Id == newBoat.Id)
                {
                    boats.Name = newBoat.Name;
                    boats.Measurement = newBoat.Measurement;
                    boats.Engine = newBoat.Engine;
                }
            }
        }
    }
}
