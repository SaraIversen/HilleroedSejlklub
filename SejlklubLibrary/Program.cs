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
Event e1 = new Event("Sommertur", new DateTime(2025/20/06), "Hygge sejltur","Klubhuset");

Console.WriteLine(e1.ToString());

Console.Write("_____________________________________________________________\n");
//_____Opretelse af repo og Repo
EventRepository er = new EventRepository();
List<Event> test = er.GetAll();

Console.WriteLine(test[1].Id);


Event ev1 = er.GetEventByID(2);
Console.WriteLine(ev1.ToString());
Console.Write("_____________________________________________________________\n");
//_____Remove  objekt
er.RemoveEvent(ev1.Id);
foreach (Event item in test) 
{ Console.WriteLine(item.ToString()); }

Console.Write("_____________________________________________________________\n");


ParticipantRepository pr = new ParticipantRepository();

List<Member> _participants = pr.GetAllParticipants();
Member m1 = new Member("xxxx", "xxxx", "xxxx", "xxxx", MemberType.Senior);

_participants.Add(m1);

foreach (Member member in _participants)
{
    Console.WriteLine(member.Name);
}