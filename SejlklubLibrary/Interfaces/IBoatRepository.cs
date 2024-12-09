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
        void UpdateBoat(Boat oldBoat);
        void PrintAllBoats();
        string ToString();
    }
}
