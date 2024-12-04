using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Interfaces
{
    public interface IEvent
    {
        int Id { get; }
        string Name { get; set; }
        string Date { get; set; }
        string Description { get; set; }
        string Location { get; set; }
        string ToString();
    }
}
