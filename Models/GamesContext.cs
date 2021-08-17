using Microsoft.EntityFrameworkCore;

namespace BoardGames.Models
{
    public class GamesContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public GamesContext(DbContextOptions<GamesContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
