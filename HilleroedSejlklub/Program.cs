// See https://aka.ms/new-console-template for more information
using SejlklubLibrary.Exceptions.Bookings;
using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;
using SejlklubLibrary.Services;

//Test af booking class
//_____Opretelse af repo
BookingRepository bookingRepo = new BookingRepository();

//_____Opretelse af nye booking data
DateTime date1 = DateTime.Today;
BookingTime bookingTime1 = BookingTimesRepository.BookingTimes.First();
string location1 = "Esrum Sø";
Boat boat1 = new Boat("xxx meter", "BBB", "Stor", 2014, BoatType.lynæs);
Member member1 = new Member("Jens", "jens@mail.dk", "Vej 123", "84239212", MemberType.Senior, false, false);

//_____Opretelse af ny booking
try
{
    Console.WriteLine($"Trying to add a new booking...");
    Booking newBooking1 = bookingRepo.NewBooking(date1, bookingTime1, location1, boat1, member1);
    Console.WriteLine("Booking was successfull!");
    Console.WriteLine();
    Console.WriteLine($"New booking was made with the following data - {newBooking1.ToString()}");
}
catch (NullException nullEx)
{
    Console.WriteLine($"EXCEPTION: Please make sure that no fields are null: " + nullEx.Message);
}
catch (InvalidBookingDateException invBookDateEx)
{
    Console.WriteLine($"EXCEPTION: Please input a valid date - it is not possible to book in the present: " + invBookDateEx.Message);
}
catch (InvalidBookingTimeException invBookTimeEx)
{
    Console.WriteLine($"EXCEPTION: Please input a free time period: " + invBookTimeEx.Message);
}

Console.Write("_____________________________________________________________\n");

//_____Print alle bookings
Console.WriteLine($"Printing all bookings: \n");
bookingRepo.PrintAllBookings();

Console.Write("_____________________________________________________________\n");

//_____Fjernelse af en booking
Booking bookingToRemove = bookingRepo.GetAllBookings().First();
Console.WriteLine($"Removing booking with id: {bookingToRemove.Id} from the bookings list.");
bookingRepo.RemoveBooking(bookingToRemove.Id);

Console.Write("_____________________________________________________________\n");

//_____Print alle bookings
Console.WriteLine($"Printing all bookings: \n");
bookingRepo.PrintAllBookings();

Console.Write("_____________________________________________________________\n");

//_____Opretelse af nye booking data
DateTime date2 = DateTime.Today;
BookingTime bookingTime2 = BookingTimesRepository.BookingTimes.First();
string location2 = "Esrum Sø";
Boat boat2 = new Boat("xxx meter", "BBB", "Stor", 2014, BoatType.lynæs);
Member member2 = new Member("Jens", "jens@mail.dk", "Vej 123", "84239212", MemberType.Senior, false, false);

//_____Opretelse af ny booking
try
{
    Console.WriteLine($"Trying to add a new booking...");
    Booking newBooking2 = bookingRepo.NewBooking(date2, bookingTime2, location2, boat2, member2);
    Console.WriteLine("Booking was successfull!");
    Console.WriteLine();
    Console.WriteLine($"New booking was made with the following data - {newBooking2.ToString()}");
}
catch (NullException nullEx)
{
    Console.WriteLine($"EXCEPTION: Please make sure that no fields are null: " + nullEx.Message);
}
catch (InvalidBookingDateException invBookDateEx)
{
    Console.WriteLine($"EXCEPTION: Please input a valid date - it is not possible to book in the present: " + invBookDateEx.Message);
}
catch (InvalidBookingTimeException invBookTimeEx)
{
    Console.WriteLine($"EXCEPTION: Please input a free time period: " + invBookTimeEx.Message);
}
