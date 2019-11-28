using System;
using System.Collections.Generic;
using InventoryApp.Struct;
using InventoryApp.Interfaces;
using System.Text;

namespace InventoryApp.Lib
{
    class Hotel : IPrintable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public City City { get; set; }

        List<Room> RoomList = new List<Room>();

        public Hotel(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Hotel AddRoom(Room room)
        {
            this.RoomList.Add(room);

            return this;
        }

        public Room GetCheapestRoom()
        {
            this.RoomList.Sort();

            return this.RoomList[0];
        }

        public void Print()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"Hotel {this.Name} from {this.City}");

            foreach( Room room in this.RoomList)
            {
                builder.AppendLine(room.ToString());
            }

            Console.WriteLine(builder.ToString());
        }
    }
}