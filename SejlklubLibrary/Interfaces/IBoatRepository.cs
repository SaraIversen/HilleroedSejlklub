using SejlklubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Interfaces
{
    public interface IBoatRepository
    {
        int Count { get; }
        
        List<Boat> GetAll();
        Boat GetBoatById(int id);
        void AddBoat(Boat boat);
        void RemoveBoat(int id);
        void UpdateBoat(Boat newBoat);
        void FindBoatByName(string name);
        bool ValidateBoat(string measurement, string name, string engine, int buildyear);
        void PrintAllBoats();
        List<Boat> FilterByBoatType(BoatType boatType);

        List<Boat> SearchBoatByName(string name);
        string ToString();
    }
}
