﻿using SejlklubLibrary.Interfaces;
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
        public List<Event> GetAll()
        {
            return _eventList;
        }

        public EventRepository() 
        {
            _eventList = new List<Event>();
        }

        public void AddEvent(Event events)
        {
            if (!_eventList.Contains(events)) 
            {
                AddEvent(events);
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
            throw new NotImplementedException();
        }

        public void RemoveEvent(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateEvent(Event newEvent, int oldEventId)
        {
            throw new NotImplementedException();
        }
    }
}
