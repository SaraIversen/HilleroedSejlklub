﻿using SejlklubLibrary.Data;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Services
{
    public class EventRepository : IEventRepository
    {
        private List<Event> _eventList;

        public int Count { get { return _eventList.Count; } }

        public List<Event> GetAll()
        {
            return _eventList;
        }

        public EventRepository() 
        {
            _eventList = new List<Event>();
            _eventList = MockData.EventData;
        }

        public void AddEvent(Event events)
        {
            if (!_eventList.Contains(events))
            {
                _eventList.Add(events);
            }
        }


        public Event GetEventByID(int id)
        {
            foreach (Event events in _eventList) 
            {
                if (events.Id==id) 
                {
                    return events;
                }
            }
            return null;
        }

        public void PrintAllEvents()
        {
            foreach (Event events in _eventList) 
            {
                Console.WriteLine(events.ToString());
            }
        }

        public void RemoveEvent(int id)
        {
            Event foundEvent = GetEventByID(id);
            if (foundEvent!=null) 
            {
                _eventList.Remove(foundEvent);
            }
        }

        public void UpdateEvent(Event newEvent)
        {
            foreach (Event events in _eventList) 
            {
                if (events.Id == newEvent.Id) 
                {
                    events.Name = newEvent.Name;
                    events.Date = newEvent.Date;
                    events.Location = newEvent.Location;
                    events.Description = newEvent.Description;
                }
            }
        }
    }
}
