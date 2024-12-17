using SejlklubLibrary.Data;
using SejlklubLibrary.Exceptions.Boats;
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
            this.FindBoatByName(boat.Name);
            this.ValidateBoat(boat.Measurement, boat.Name, boat.Engine, boat.BuildYear);
            this.ValidateBoatName(boat.Name);
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
        public void FindBoatByName(string name)
        {
            foreach (Boat b in _boatList)
            {
                if (b.Name == name)
                {
                    throw new InvalidBoatNameException("Navnet er allerede taget af en anden båd.");
                }
            }
        }
        public bool ValidateBoat(string measurement, string name, string engine, int buildyear)
        {
            if (measurement == null)
            {
                throw new NullException($"Mål kunne ikke findes.");
            }
            if (name == null)
            {
                throw new NullException($"Navn kunne ikke findes.");
            }
            if (engine == null)
            {
                throw new NullException($"Motor kunne ikke findes.");
            }
            if (buildyear == null || buildyear == 0)
            {
                throw new NullException($"Bygningsår kunne ikke findes.");
            }
            return true;
        }
        public void ValidateBoatName(string name)
        {
            if (name.Length > 35)
            {
                throw new InvalidBoatCharacterLengthException("Navnet skal være under 35 karakterer.");
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
            this.ValidateBoat(newBoat.Measurement, newBoat.Name, newBoat.Engine, newBoat.BuildYear);
            this.ValidateBoatName(newBoat.Name);
        }
    }
}
