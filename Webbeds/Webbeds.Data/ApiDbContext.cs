namespace Webbeds.Data
{
    using Microsoft.EntityFrameworkCore;
    using Webbeds.Data.Entities;

    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public void OnConfiguring()
        { }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Room> Rooms { get; set; }

    }
}
