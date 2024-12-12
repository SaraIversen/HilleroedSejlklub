﻿using SejlklubLibrary.Exceptions.Events;
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
            //if (name.Length>35) 
            //{
            //    throw new InvalidEventName("Navnet overskrider 35 tegn");
            //}
            //if (description.Length < 3 || description.Length > 250) 
            //{
            //    throw new InvalidEventDescription("Beskrivelsen er enten under 3 tegn, eller overskrider 250 tegn");
            //} 
            //if (!(eventType== EventType.Udflugt || eventType== EventType.Standerhejsning || eventType== EventType.Sejltur ||eventType== EventType.Spisning ||eventType== EventType.StortForKlubben ||eventType== EventType.Kursus)) 
            //{
            //    throw new InvalidEventType("Ugyldig event type");
            //}
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
