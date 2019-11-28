using System;
using InventoryApp.Lib;

namespace InventoryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            HotelList<Hotel> hotels = new HotelList<Hotel>();

            Hotel h = new Hotel(1, "first hotel") { 
                City = new Struct.City(1, "Iasi")
            };
            h.AddRoom(new Room(1, "room 1", 2, 0, new Rate(new Money(200, Enums.Currencies.EUR))));
            h.AddRoom(new Room(2, "room 2", 2, 0, new Rate(new Money(220, Enums.Currencies.EUR))));

            h.Print();
            hotels.AddHotel(h);

        }
    }
}
