using Microsoft.EntityFrameworkCore;
using API.DAL.Interfaces;
using API.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace API.DAL.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext db;
        private readonly ActorRepository actorRepository;
        private readonly GenreRepository genreRepository;

        public MovieRepository(ApplicationDbContext db)
        {
            this.db = db;
            actorRepository = new ActorRepository(db);
            genreRepository = new GenreRepository(db);
        }

        public async Task<bool> CreateAsync(Movie entity)
        {
            await db.Movies.AddAsync(entity);
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AddGenreAsync(MovieGenre entity)
        {
            await db.MovieGenre.AddAsync(entity);
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AddActorAsync(MovieActor entity)
        {
            await db.MovieActor.AddAsync(entity);
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(Movie entity)
        {
            db.Movies.Remove(entity);
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<Movie> GetAsync(int id)
        {
            return await db.Movies.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Movie> GetLastAsync()
        {
            var count = await GetCountAsync();
            return db.Movies.Skip(count - 1).First();
        }

        public async Task<List<Movie>> SelectAsync()
        {
            return await db.Movies.ToListAsync();
        }

        public async Task<List<Movie>> SelectAsync(int[] idActors, int[] idGenres, string title, int limit, int page)
        {
            var isActorsEmpty = idActors.Length == 0;
            var isGenresEmpty = idGenres.Length == 0;
            var movieActors = new List<int>();
            var movieGenres = new List<int>();

            if (!isActorsEmpty)
            {
                movieActors = await db.MovieActor
                   .Where(ma => idActors.Contains(ma.ActorId))
                   .Select(ma => ma.MovieId)
                   .ToListAsync();
            }

            if (!isGenresEmpty)
            {
                movieGenres = await db.MovieGenre
                    .Where(mg => idGenres.Contains(mg.GenreId))
                    .Select(ma => ma.MovieId)
                    .ToListAsync();
            }

            var movies = await db.Movies
                .Where(movie => movie.Title.ToLower().Contains(title.ToLower()))
                .ToListAsync();

            return movies.Where(m => (isActorsEmpty || movieActors.Contains(m.Id)) &&
                                     (isGenresEmpty || movieGenres.Contains(m.Id)))
                         .Skip(limit * (page - 1))
                         .Take(limit)
                         .ToList();
        }

        public async Task<int> GetCountAsync()
        {
            return await db.Movies.CountAsync();
        }

        public async Task<Movie> UpdateAsync(Movie entity)
        {
            db.Movies.Update(entity);
            await db.SaveChangesAsync();

            return entity;
        }

        public async Task<List<Actor>> GetActorsAsync(int id)
        {
            var movieAndActors = await db.MovieActor.Where(x => x.MovieId == id).Select(x => x.ActorId).ToListAsync();
            var actors = await actorRepository.SelectAsync();
            return actors.Where(x => movieAndActors.Contains(x.Id)).ToList();
        }

        public async Task<List<Genre>> GetGenresAsync(int id)
        {
            var movieAndGenres = await db.MovieGenre.Where(x => x.MovieId == id).Select(x => x.GenreId).ToListAsync();
            var genres = await genreRepository.SelectAsync();
            return genres.Where(x => movieAndGenres.Contains(x.Id)).ToList();
        }
    }
}
