using Microsoft.EntityFrameworkCore;
using CodeFirstBasic.Models;
namespace CodeFirstBasic.Data
{
    public class PatikaFirstDbContext : DbContext
    {
        public PatikaFirstDbContext(DbContextOptions<PatikaFirstDbContext> options)
           : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}
