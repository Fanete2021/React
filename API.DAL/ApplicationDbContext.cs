using Microsoft.EntityFrameworkCore;
using API.Domain.Entity;

namespace API.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie_Actor> MoviesAndActors { get; set; }
        public DbSet<Movie_Genre> MoviesAndGenres { get; set; }
    }
}
