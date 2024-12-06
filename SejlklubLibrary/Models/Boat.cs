using SejlklubLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Models
{
    public class Boat : IBoat
    {
        private static int _counter = 0;
        private int _id;
        public Boat() 
        { 
        }

        public Boat(string measurement, string name, string engine, int buildyear, BoatType boatType) 
        {
            _counter++;
            _id = _counter;
            Measurement = measurement;
            Name = name;
            Engine = engine;
            BuildYear = buildyear;
            BoatType = boatType;
        }

        public BoatType BoatType { get; set; }
        public string Measurement {  get; }
        public bool IsBooked { get; set; }
        public int Id { get { return _id; } }
        public string Name { get; set; }
        public string Engine { get; set; }
        public int BuildYear { get; }

        public void Counting()
        {
            _counter++;
            _id = _counter;
        }

        public override string ToString()
        {
            return $"Name:{Name}\nEngine:{Engine}\nMeasurement:{Measurement}\nBuildYear: {BuildYear}\nBoatType: {BoatType}";
        }
    }
}
