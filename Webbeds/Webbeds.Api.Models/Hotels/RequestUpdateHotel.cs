using System;
using System.Collections.Generic;
using System.Text;

namespace Webbeds.Api.Models.Hotels
{
    using System.ComponentModel.DataAnnotations;

    public class RequestUpdateHotel : RequestCreateHotel
    {
        [Required]
        public int Id { get; set; }
    }
}
