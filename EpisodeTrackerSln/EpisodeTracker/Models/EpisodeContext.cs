using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EpisodeTracker.Models
{
    public class EpisodeContext : IdentityDbContext<User>
    {
        public EpisodeContext(DbContextOptions<EpisodeContext> options)
            : base(options)
        { }

        public DbSet<Show> Shows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Show>().HasData(
                new Show
                {
                    ShowId = 1,
                    Title = "Lost",
                    LastEpisodeSeen = "Season 2 Ep. 3"
                },
                new Show
                {
                    ShowId = 2,
                    Title = "Saved by the Bell",
                    LastEpisodeSeen = "15"
                }
            ); ;
        }
    }
}
