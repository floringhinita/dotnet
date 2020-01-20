using System;
using System.Collections.Generic;
using System.Text;

namespace Webbeds.Data.Entities
{
    public class Room
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Adults { get; set; }

        public int Children { get; set; }

        public Hotel Hotel { get; set; }
    }
}
