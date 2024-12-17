using SejlklubLibrary.Exceptions.Events;
using SejlklubLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
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

        public int Id { get { return _id; } set { _id = value; } }

        public Member Member { get; }
        //public List<Member> Participants { get; set; } = new List<Member>();
        public List<EventRegistration> EventRegistrations { get; set; } = new List<EventRegistration>();

        public EventType EventType { get; set; }

        public Event()
        {
            _id = _counter;
        }

        public Event(string name, DateTime date, string description,string location,EventType eventType)
        {
            if (name.Length > 35||name==null||name.Length<2)
            {
                throw new InvalidEventNameException("Navnet er over 35 tegn, under 2 tegn eller mangler at blive udfyldt");
            }
            if (!(eventType == EventType.Udflugt || eventType == EventType.Standerhejsning || eventType == EventType.Sejltur || eventType == EventType.Spisning || eventType == EventType.StortForKlubben || eventType == EventType.Kursus) || eventType == null)
            {
                throw new InvalidEventTypeException("Ugyldig event type");
            }
            if (location == null || location.Length < 5)
            {
                throw new InvalidEventLocationException("Loalitet for eventet er under 5 tegn, eller mangler at udfyldes");
            }
            if (description.Length < 3 || description.Length > 250||description==null)
            {
                throw new InvalidEventDescriptionException("Beskrivelsen er enten under 3 tegn, overskrider 250 tegn eller mangler at blive udfyldt");
            }
            _counter++;
            _id = _counter;
             
            Name = name;
            Date = date;
            Description = description;
            Location = location;
            EventType = eventType;
        }
        public override string ToString()
        {
            return $"{Name},{Date}\n" +
                $"Sted: {Location}\n" +
                $"Beskrivelse: {Description}\n";
        }
    }
}
