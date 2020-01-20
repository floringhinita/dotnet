using System;
using System.Collections.Generic;
using System.Text;

namespace Webbeds.Data.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Room> Rooms { get; set; }
    }
}
