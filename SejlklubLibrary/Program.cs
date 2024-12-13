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
Console.Write("_____________________________________________________________\n");
//___Opdater et medlem fra repository
Member m2 = new Member("Michael", "michael@mail.dk", "Gade 456", "84239212", MemberType.Senior);
mRepo.UpdateMember(m2);
members = mRepo.GetAll();

foreach (Member m in members)
{
    Console.WriteLine(m);
    Console.WriteLine();
}
Console.Write("_____________________________________________________________\n");


//Test af booking class
//_____Opretelse af repo
BookingRepository bookingRepo = new BookingRepository();

//_____Opretelse af nye booking data
string date = DateTime.Now.ToString("d");
BookingTime bookingTime = bookingRepo.GetAllBookingTimes().First();
string location = "Esrum Sø";
Boat boat = b1;
Member member = m1;

//_____Opretelse af ny booking
if (bookingRepo.NewBooking(date, bookingTime, location, boat, member))
{
    Console.WriteLine("Booking was successfull!");
    Console.WriteLine($"New booking was made with the following data - " +
        $"date: {date}, bookingTime: {bookingTime}, location: {location}, boat: {boat.BoatType}, member: {member.Name}");
}
else
{
    Console.WriteLine("Booking error, some of the booking data were invalid!");
}

//_____Fjernelse af en booking
Booking bookingToRemove = bookingRepo.GetAllBookings().First();
bookingRepo.RemoveBooking(bookingToRemove.Id);
Console.WriteLine("A booking was removed from the bookings list.");

//_____Print alle bookings
bookingRepo.PrintAllBookings();

Console.Write("_____________________________________________________________\n");