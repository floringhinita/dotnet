using System;
using System.Collections.Generic;
using System.Text;

namespace Webbeds.Core.Models
{
    public class Room
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Adults { get; set; }

        public int Children { get; set; }

        public Hotel hotel { get; set; }
    }
}
