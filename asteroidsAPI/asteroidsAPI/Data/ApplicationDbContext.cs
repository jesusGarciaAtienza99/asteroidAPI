using asteroidsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace asteroidsAPI.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }

        public DbSet<TopAsteroid> TopAsteroids { get; set; }
        public DbSet<Asteroid> Asteroids { get; set; }

       
        



    }

}
