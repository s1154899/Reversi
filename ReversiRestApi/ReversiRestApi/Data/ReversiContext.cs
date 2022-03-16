using Microsoft.EntityFrameworkCore;

namespace ReversiRestApi.Data
{
    public class ReversiContext : DbContext
    {
        public ReversiContext(DbContextOptions<ReversiContext> options) : base(options) { }

        public DbSet<Spel> Spellen { get; set; }

        public DbSet<Speler> Spelers { get; set; }
        
        public DbSet<Bord> Bord { get; set; }
    }
}
