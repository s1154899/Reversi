using Microsoft.EntityFrameworkCore;
using ReversiMvcApp.Models;

namespace ReversiMvcApp.Data
{
    public class reversiDbContext : DbContext
    {
        public reversiDbContext(DbContextOptions<reversiDbContext> options) : base(options) { }


       
        public DbSet<Spelers> Spelers { get; set; }

    }
}
