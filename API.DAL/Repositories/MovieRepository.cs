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

        public async Task<bool> AddGenreAsync(Movie_Genre entity)
        {
            await db.MoviesAndGenres.AddAsync(entity);
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AddActorAsync(Movie_Actor entity)
        {
            await db.MoviesAndActors.AddAsync(entity);
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(Movie entity)
        {
            db.Movies.Remove(entity);
            await db.SaveChangesAsync();

            await DeleteActorsAsync(entity.Id);
            await DeleteGenresAsync(entity.Id);

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

        private List<Movie> SearchByGenreAndActor(List<Movie> movies, int[] idGenres, int[] idActors)
        {
            var sortedMovies = new List<Movie>();
            bool isIncluded;

            foreach(var movie in movies)
            {
                isIncluded = true;

                if (idGenres.Length > 0)
                {
                    var genres = GetGenresAsync(movie.Id).Result.Select(g => g.Id);
                    foreach (var genre in idGenres)
                    {
                        if (!genres.Contains(genre))
                        {
                            isIncluded = false;
                            break;
                        }
                    }
                }

                if (!isIncluded)
                    continue;

                if (idActors.Length > 0)
                {
                    var actors = GetActorsAsync(movie.Id).Result.Select(a => a.Id);
                    foreach (var actor in idActors)
                    {
                        if (!actors.Contains(actor))
                        {
                            isIncluded = false;
                            break;
                        }
                    }
                }

                if (isIncluded)
                    sortedMovies.Add(movie);
            }

            return sortedMovies;
        }

        public async Task<List<Movie>> SelectAsync(int[] idActors, int[] idGenres, string title)
        {
            var movies = await db.Movies.Where(movie => movie.Title.ToLower().Contains(title.ToLower())).ToListAsync();

            return SearchByGenreAndActor(movies, idGenres, idActors);
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
            var movieAndActors = await db.MoviesAndActors.Where(x => x.Movie_id == id).Select(x => x.Actor_id).ToListAsync();
            var actors = await actorRepository.SelectAsync();
            return actors.Where(x => movieAndActors.Contains(x.Id)).ToList();
        }

        public async Task<List<Genre>> GetGenresAsync(int id)
        {
            var movieAndGenres = await db.MoviesAndGenres.Where(x => x.Movie_id == id).Select(x => x.Genre_id).ToListAsync();
            var genres = await genreRepository.SelectAsync();
            return genres.Where(x => movieAndGenres.Contains(x.Id)).ToList();
        }

        public async Task<bool> DeleteActorsAsync(int movieId)
        {
            var movieAndActors = await db.MoviesAndActors.Where(x => x.Movie_id == movieId).ToListAsync();
            db.MoviesAndActors.RemoveRange(movieAndActors);
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteGenresAsync(int movieId)
        {
            var movieAndGenres = await db.MoviesAndGenres.Where(x => x.Movie_id == movieId).ToListAsync();
            db.MoviesAndGenres.RemoveRange(movieAndGenres);
            await db.SaveChangesAsync();

            return true;
        }
    }
}
