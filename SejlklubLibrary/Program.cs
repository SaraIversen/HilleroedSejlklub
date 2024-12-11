// See https://aka.ms/new-console-template for more information
using SejlklubLibrary.Models;
using SejlklubLibrary.Services;

//Test af boat class
//_____Opretelse af objekt
Boat b1 = new Boat("xxx meter", "BBB", "Stor", 2014, BoatType.lynæs);

//_____Udskrift af objekt
Console.WriteLine(b1.ToString());
Console.Write("_____________________________________________________________\n");




//Test af event class
//_____Opretelse af objekt
Event e1 = new Event("Sommertur", new DateTime(2025/20/06), "Hygge sejltur","Klubhuset",EventType.Udflugt);

Console.WriteLine(e1.ToString());

Console.Write("_____________________________________________________________\n");
//_____Opretelse af repo og Repo
EventRepository er = new EventRepository();
List<Event> test = er.GetAll();
er.AddEvent(e1);
Console.WriteLine(test[1].Id);


Event ev1 = er.GetEventByID(2);
Console.WriteLine(ev1.ToString());
Console.Write("_____________________________________________________________\n");
//_____Remove  objekt
er.RemoveEvent(ev1.Id);
foreach (Event item in test) 
{ Console.WriteLine(item.ToString()); }

Console.Write("_____________________________________________________________\n");
//_____Opdater objekt
Event existerendeEvent = er.GetEventByID(4);
Console.WriteLine("Inden opdateringe\n" +existerendeEvent.Id + ": " + existerendeEvent.ToString() + "\n______________");

Event updateretEvent = new Event("Sommer spisning", new DateTime(2025,06,23, 11, 30, 00), "Fælles fokost spisning og sankhans bål", "Klubhuset",EventType.Spisning);
er.UpdateEvent(updateretEvent);

Console.WriteLine("Efter opdatering:\n" +updateretEvent.Id+": "+ updateretEvent.ToString());

foreach (Event item in test)
{ Console.WriteLine(item.ToString()); }

