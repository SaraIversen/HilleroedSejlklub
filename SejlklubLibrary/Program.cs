// See https://aka.ms/new-console-template for more information
using SejlklubLibrary.Models;
using SejlklubLibrary.Services;
using System.Diagnostics.CodeAnalysis;

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

//___Test af member class
//___Oprettelse af member objekt
Member m1 = new Member("Jens", "jens@mail.dk", "Vej 123", "84239212", MemberType.Senior);
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