// See https://aka.ms/new-console-template for more information
using SejlklubLibrary.Exceptions.Events;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;
using SejlklubLibrary.Services;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System.Diagnostics.Tracing;

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

//_____Exeption

try
{
    Event exEv = new Event("Na", new DateTime(2025, 06, 12, 16, 00, 00), "De", "Location", EventType.Sejltur);
    er.AddEvent(exEv);
}
catch (InvalidEventName ex)
{
    throw new InvalidEventName("");
}
catch (InvalidEventDescription) 
{
    throw new InvalidEventDescription("");
}

//Test af member class
//___Oprettelse af member objekt
Member m1 = new Member("Jens", "jens@mail.dk", "Vej 123", "84239212", MemberType.Senior, false, false);
Console.WriteLine(m1);
Console.Write("_____________________________________________________________\n");
//___Oprettelse af member repository
MemberRepository mRepo = new MemberRepository();
//___Tilføjelse af member til repository
mRepo.AddMember(m1);
List<Member> members = mRepo.GetAll();

foreach (Member m in members)
{
    Console.WriteLine(m);
    Console.WriteLine();
}

Console.Write("_____________________________________________________________\n");
//___Fjern et medlem fra repository
mRepo.RemoveMember("12121212");
members = mRepo.GetAll();

foreach (Member m in members)
{
    Console.WriteLine(m);
    Console.WriteLine();
}
Console.Write("_____________________________________________________________\n");
//___Opdater et medlem fra repository
Member m2 = new Member("Michael", "michael@mail.dk", "Gade 456", "84239212", MemberType.Senior, false, false);
mRepo.UpdateMember(m2);
members = mRepo.GetAll();

foreach (Member m in members)
{
    Console.WriteLine(m);
    Console.WriteLine();
}
Console.Write("_____________________________________________________________\n");
//___Tilføj en coach til member repository
Coach c1 = new Coach("Jan", "jan@mail.dk", "Gade 789", "39231293", MemberType.Senior, 3000, true, true, false);
mRepo.AddMember(c1);
members = mRepo.GetAll();

foreach (Member m in members)
{
    Console.WriteLine(m);
    Console.WriteLine();
}
Console.Write("_____________________________________________________________\n");