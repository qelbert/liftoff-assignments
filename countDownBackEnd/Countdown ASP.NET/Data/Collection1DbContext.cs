using Countdown_ASP.NET.Models;
using Microsoft.EntityFrameworkCore;

namespace Countdown_ASP.NET.Data
{
    public class Collection1DbContext : DbContext
    {
        public DbSet<Collection1Entity> Collection1 { get; set; }

        public Collection1DbContext(DbContextOptions options)
            : base(options) { }
    }
}
