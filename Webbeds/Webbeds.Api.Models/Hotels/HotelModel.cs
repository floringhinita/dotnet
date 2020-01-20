using System;
using System.Collections.Generic;
using System.Text;

namespace Webbeds.Api.Models.Hotels
{
    using System.ComponentModel.DataAnnotations;

    public class HotelModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
