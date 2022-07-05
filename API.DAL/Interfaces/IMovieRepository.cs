using API.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.DAL.Interfaces
{
    public interface IMovieRepository: IBaseRepository<Movie>
    {
        public Task<List<Actor>> GetActorsAsync(int movieId);
        public Task<List<Genre>> GetGenresAsync(int movieId);
        public Task<bool> AddGenreAsync(Movie_Genre entity);
        public Task<bool> AddActorAsync(Movie_Actor entity);
        public Task<bool> DeleteGenresAsync(int movieId);
        public Task<bool> DeleteActorsAsync(int movieId);
        public Task<List<Movie>> SelectAsync(int[] idActors, int[] idGenres, string title);
    }
}
