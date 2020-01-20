using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webbeds.Data;
using Webbeds.Api.Models.Hotels;
using Webbeds.Data.Entities;

namespace Webbeds.Api.Controllers
{
    using Extensions.Map;
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly ApiDbContext context;

        public HotelsController(ApiDbContext context)
        {
            this.context = context;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelModel>>> Get()
        {
             // return await this.context.Hotels.ToListAsync();
            return new List<HotelModel>();
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelModel>> Get(int id)
        {
            var hotel = await this.context.Hotels.FindAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel.MapAsModel();
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, RequestUpdateHotel hotel)
        {
            var entity = hotel.MapAsNewEntity();

            if (id != hotel.Id)
            {
                return this.BadRequest();
            }

            this.context.Entry(hotel).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if ( ! this.HotelExists(id))
                {
                    return this.NotFound();
                }
                else
                {
                    throw;
                }
            }

            return this.NoContent();
        }

        // POST: api/Hotels
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Hotel>> Post(RequestCreateHotel hotel)
        {
            var entity = hotel.MapAsNewEntity();

            this.context.Hotels.Add(entity);

            await this.context.SaveChangesAsync();

            return this.CreatedAtAction("Get", new { id = entity.Id }, entity.MapAsModel());
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hotel>> Delete(int id)
        {
            var hotel = await this.context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            this.context.Hotels.Remove(hotel);
            await this.context.SaveChangesAsync();

            return hotel;
        }

        private bool HotelExists(int id)
        {
            return this.context.Hotels.Any(e => e.Id == id);
        }
    }
}
