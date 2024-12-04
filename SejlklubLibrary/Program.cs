// See https://aka.ms/new-console-template for more information
using SejlklubLibrary.Models;

//Test af boat class
Boat b1 = new Boat("xxx meter", "BBB", "Stor", 2014, BoatType.lynæs);

Console.WriteLine(b1.ToString());
Console.Write("_____________________________________________________________");

//Test af event class
Event e1 = new Event("Sommertur","20/06/2025", "Hygge sejltur","Klubhuset");

Console.WriteLine(e1.ToString());
