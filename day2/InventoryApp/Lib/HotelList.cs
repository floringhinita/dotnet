using System;
using System.Collections.Generic;
using System.Text;
using InventoryApp.Interfaces;

namespace InventoryApp.Lib
{
    public class HotelList<Hotel> : List<Hotel>, IPrintable
    {
        public void AddHotel(Hotel h)
        {
            this.Add(h);
        }

        public void RemoveHotel(Hotel h)
        {
            if (this.Contains(h))
            {
                this.Remove(h);
            }
        }

        public Room GetCheapestRoom()
        {
            Room cheapest = new Room();


            return cheapest;
        }

        public void Print()
        {
            foreach (Hotel hotel in this)
            {
                // hotel.Print();
            }
        }
    }

}