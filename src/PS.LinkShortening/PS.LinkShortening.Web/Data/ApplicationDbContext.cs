using Microsoft.EntityFrameworkCore;
using PS.LinkShortening.Web.Models;

namespace PS.LinkShortening.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Link> Links { get; set; } = null!;

    }
}
