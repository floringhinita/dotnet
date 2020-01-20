using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webbeds.Api.Extensions.Map
{
    using Data.Entities;
    using Models.Hotels;

    public static class HotelExtensions
    {
        public static Hotel MapAsNewEntity(this RequestCreateHotel model)
        {
            return new Hotel
            {
                Name = model.Name
            };
        }

        public static HotelModel MapAsModel(this Hotel model)
        {
            return new HotelModel
            {
                Name = model.Name,
                Id = model.Id
            };
        }
    }
}
