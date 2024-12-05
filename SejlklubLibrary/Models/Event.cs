using SejlklubLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Models
{
    public class Event : IEvent
    {
        private int _id;
        private static int _counter = 0;


        public string Name { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        public int Id { get { return _id; } }
        public Event()
        {
            
        }

        public Event(string name, string date, string description,string location)
        {
            _id = _counter;
            _counter++;

            Name = name;
            Date = date;
            Description = description;
            Location = location;

        }
        public override string ToString()
        {
            return $"{Name},{Date}\n" +
                $"Sted: {Location}\n" +
                $"Beskrivelse: {Description}\n";
        }
    }
}
