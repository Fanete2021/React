using Microsoft.EntityFrameworkCore;
using API.Domain.Entity;
using API.Domain.Entity.Configuration;

namespace API.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovieActorConfiguration());
            modelBuilder.ApplyConfiguration(new MovieGenreConfiguration());

            //Filling in genres during migration
            modelBuilder.Entity<Genre>()
                .HasData(
                    new Genre { Id = 1, Title = "Drama" },
                    new Genre { Id = 2, Title = "Comedy" },
                    new Genre { Id = 3, Title = "Musical" },
                    new Genre { Id = 4, Title = "Romance" },
                    new Genre { Id = 5, Title = "Adventure" },
                    new Genre { Id = 6, Title = "Crime" },
                    new Genre { Id = 7, Title = "Action" },
                    new Genre { Id = 8, Title = "Thriller" },
                    new Genre { Id = 9, Title = "Horror" }
                );
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenre> MovieGenre { get; set; }
        public DbSet<MovieActor> MovieActor { get; set; }
    }
}
