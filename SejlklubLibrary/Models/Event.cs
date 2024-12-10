using SejlklubLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        public int Id { get { return _id; } }

        public Member Member { get; }
        public List<Member> Participants { get; set; }

        public Event()
        {
            _id = _counter;
        }

        public Event(string name, DateTime date, string description,string location)
        {
            _counter++;
            _id = _counter;

            Name = name;
            Date = date;
            Description = description;
            Location = location;

            Participants = new List<Member>();
        }
        public override string ToString()
        {
            return $"{Name},{Date}\n" +
                $"Sted: {Location}\n" +
                $"Beskrivelse: {Description}\n";
        }
    }
}
