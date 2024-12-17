using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SejlklubLibrary.Models
{
    public class BoatReparation
    {
        private int _id;
        private static int _count = 0;
        public BoatReparation() 
        {
            _id = _count;
        }
        public BoatReparation(Boat boat, string comment) 
        {
            _count++;
            _id = _count;
            Boat = boat;
            Comment = comment;
        }
        public Boat Boat { get; set; }
        public string Comment { get; set; }
        public override string ToString()
        {
            return Boat.ToString() + ", Kommentar: " + Comment;
        }
    }
}
