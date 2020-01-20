using System;
using System.Collections.Generic;
using System.Text;

namespace Webbeds.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    public class ApiDbContextFactory : IDesignTimeDbContextFactory<ApiDbContext>
    {
        public ApiDbContext CreateDbContext(string[] args)
        {
            var connString = "Server=.;Initial Catalog=WebbedsApp;Trusted_Connection=True;MultipleActiveResultSets=true";

            var builder = new DbContextOptionsBuilder<ApiDbContext>();

            builder.UseSqlServer(connString);

            return new ApiDbContext(builder.Options);
        }
    }
}
