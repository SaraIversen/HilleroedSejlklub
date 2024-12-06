using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SejlklubLibrary.Models;

namespace SejlklubLibrary.Interfaces
{
    public interface IEvent
    {
        int Id { get; }
        string Name { get; set; }
        DateTime Date { get; set; }
        string Description { get; set; }
        string Location { get; set; }
        string ToString();
    }
}
