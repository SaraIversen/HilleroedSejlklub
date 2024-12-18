using SejlklubLibrary.Interfaces;
using SejlklubLibrary.Models;
using SejlklubLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SejlklubLibrary.Data
{
    public class MockData
    {
        #region Instance fields
        private static Dictionary<string, Member> _memberData =
            new Dictionary<string, Member>()
            {
            { "12121212", new Member("Mikkel", "mikkel@mail.dk", "Street 123", "12121212", MemberType.Senior, false, false) },
            { "13131313", new Member("Charlotte", "charlotte@mail.dk", "Avenue 321", "13131313", MemberType.Junior, false, false) },
            { "14141414", new Member("Carina", "carina@mail.dk", "High Street 234", "14141414", MemberType.Junior, false, false) },
            { "15151515", new Member("Muhammed", "muhammed@mail.dk", "North Street 345", "15151515", MemberType.Passiv, false, false) },
            { "16161616", new Coach("Jan", "jan@mail.dk", "Street 456", "16161616", MemberType.Senior, 250, true, true, false) },
            { "17171717", new Coach("Jens", "jens@mail.dk", "Avenue 354", "17171717", MemberType.Senior, 225, false, true, false) },
            { "18181818", new Administrator("Ole", "ole@mail.dk", "Lake Street 432", "18181818", MemberType.Senior, 300, "Hjemmeside Administrator", false, true) },
            { "19191919", new Administrator("Mads", "mads@mail.dk", "Wood Street 789", "19191919", MemberType.Senior, 300, "Database Administrator", false, true) }
            };

        private static List<Boat> _boatData =
            new List<Boat>()
            {
            new Boat("1 meter", "Tøftøf", "v2", 1999, BoatType.Laserjolle),
            new Boat("2 meter", "Båd", "v3", 2003, BoatType.Lynæs),
            new Boat("3 meter", "Skiw", "v4", 1999, BoatType.Optimistjolle),
            new Boat("4 meter", "Mary", "v5", 1996, BoatType.Europajolle),
            new Boat("5 meter", "Pineapple", "v6", 2007, BoatType.TERA),
            new Boat("6 meter", "Synke", "v7", 1991, BoatType.FEVA),
            new Boat("7 meter", "Koreander", "v8", 2014, BoatType.Wayfarer),
            new Boat("20 centimeter", "Avisbåd", "Vind", 2024, BoatType.Snipejolle)

            };

        private static List<Event> _eventData =
            new List<Event>()
            {
                new Event("Klatreklub", new DateTime(2024, 12, 5, 12, 00, 0), "Klattre her i klubben.","Mødes ved Klubuset",EventType.Udflugt),
                new Event("Ny båd", new DateTime(2025, 11, 25, 15 ,00, 0), "Ny båd klar til booking.","Klubhuset",EventType.StortForKlubben),
                new Event("Pizza Aften", new DateTime(2025,4,19,18,30,00), "Kom til pizza aften med fælleskabet.","Klubhuset",EventType.Spisning),
                new Event("Stuntbane installeret", new DateTime(2025,1,4,13,00,0), "Ny stuntrampe installeret til speedbåde.","Klubhuset",EventType.StortForKlubben),
                new Event("Trænerkursus", new DateTime(2025,9,14,10,45,0), "Kursus til at blive træner.","Klubhuset",EventType.Kursus),
                new Event("Knoglestrækning", new DateTime(2025,2,17,9,00,0), "Kiropraktor hyret til klubben.","Klubhuset",EventType.StortForKlubben),
                new Event("Ny hjemmeside", new DateTime(2025,1,5), "Ny hjemmeside er snart oppe.","På nettet",EventType.StortForKlubben),
            };

        public static void InitializeBookingMockData(IBookingRepository bookingRepository)
        {
            bookingRepository.NewBooking(DateTime.Today, BookingTimesRepository.BookingTimes[0], "Den gode sø", GetRandomBoat(), GetRandomMember());
            bookingRepository.NewBooking(DateTime.Today.AddDays(1), BookingTimesRepository.BookingTimes[1], "Esrum Sø", GetRandomBoat(), GetRandomMember());
            bookingRepository.NewBooking(DateTime.Today, BookingTimesRepository.BookingTimes[4], "En anden sø", GetRandomBoat(), GetRandomMember());
            bookingRepository.NewBooking(DateTime.Today.AddDays(2), BookingTimesRepository.BookingTimes[3], "Esrum Sø", GetRandomBoat(), GetRandomMember());
        }

        private static List<EventRegistration> _eventRegistrationData =
            new List<EventRegistration>()
            {
                new EventRegistration("", new DateTime (),0,new Member("Mikkel", "mikkel@mail.dk", "Street 123", "12121212", MemberType.Senior, false, false)),
                new EventRegistration("Test om get random member virker", new DateTime (), 0, GetRandomMember()),
                new EventRegistration("Jeg tager den elskede sommer-salat med", new DateTime(),1,new Member("Muhammed", "muhammed@mail.dk", "North Street 345", "15151515", MemberType.Passiv, false, false)),
                new EventRegistration("Tager min kærste og mor med",new DateTime(),2,new Member("Carina", "carina@mail.dk", "High Street 234", "14141414", MemberType.Junior, false, false))
            };
        #endregion

        #region Properties
        public static Dictionary<string, Member> MemberData
        {
            get { return _memberData; }
        }

        public static List<Boat> BoatData
        {
            get { return _boatData; }
        }

        public static List<Event> EventData
        {
            get { return _eventData; }
        }

        public static List<EventRegistration> EventRegistrationData
        {
            get { return _eventRegistrationData; }
        }

        private static Member GetRandomMember()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, _memberData.Count);

            int i = 0;
            foreach (Member member in _memberData.Values)
            {
                if (randomIndex == i)
                {
                    return member;
                }
                i += 1;
            }
            return null;
        }
        private static Boat GetRandomBoat()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, _boatData.Count);
            return _boatData[randomIndex];
        }
        #endregion
    }
}
