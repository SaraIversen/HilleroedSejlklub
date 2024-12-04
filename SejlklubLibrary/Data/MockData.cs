using SejlklubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            { "12121212", new Member("Mikkel", "12121212", "Street 123") },
            { "13131313", new Member("Charlotte", "13131313", "Avenue 321") },
            { "14141414", new Member("Carina", "14141414", "High Street 234") },
            { "15151515", new Member("Muhammed", "15151515", "North Street 345") }
            };

        private static List<Boat> _boatData =
            new List<Boat>()
            {
            new Boat("Margherita", 85, "Tomat, ost", BoatType.PIZZECLASSSICHE),
            new Boat("Vesuvio", 95, "Tomat, ost & skinke", BoatType.PIZZECLASSSICHE),
            new Boat("Capricciosa", 98, "Tomat, ost, skinke & champignon", BoatType.PIZZECLASSSICHE),
            new Boat("Calzone", 98, "Indbagt pizza med tomat, ost, skinke & champignon", BoatType.PIZZECLASSSICHE),
            new Boat("Quattro Stagioni", 98, "Tomat, ost, skinke, champignon, rejer & paprika", BoatType.PIZZECLASSSICHE),
            new Boat("Marinara", 97, "Tomat, ost, rejer, muslinger & hvidløg", BoatType.PIZZECLASSSICHE),
            new Boat("Vegetariana", 98, "Tomat, ost & grønsager", BoatType.PIZZECLASSSICHE),
            new Boat("Italiana", 97, "Tomat, ost, løg & kødsauce", BoatType.PIZZECLASSSICHE)

            };

        private static List<Event> _eventData =
            new List<Event>()
            {
                new Event("Pepperoni", 10),
                new Event("Ananas", 10),
                new Event("Løg", 5),
                new Event("Jalapenos", 10),
                new Event("Gorgonzola", 15),
                new Event("Skinke", 10),
                new Event("Hvidløg", 10),
                new Event("Champignon", 15),
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
        #endregion
    }
}
