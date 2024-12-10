using SejlklubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Interfaces
{
    public  interface IEventRepository
    {
        int Count { get; }
        List<Event> GetAll();
        void AddEvent(Event events);
        void PrintAllEvents();
        Event GetEventByID( int id);
        void RemoveEvent(int id);
        void UpdateEvent(Event newevent);
    }
}
