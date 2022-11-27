using Microsoft.EntityFrameworkCore;

namespace MoviesApi.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
        {

        }

        public DbSet<Content> Contents => Set<Content>();
        public DbSet<Profile> Profiles => Set<Profile>();
    }
}
