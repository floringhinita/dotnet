namespace Webbeds.Api.Models.Hotels
{
    using System.ComponentModel.DataAnnotations;

    public class RequestCreateHotel
    {
        [Required]
        public string Name { get; set; }
    }
}
