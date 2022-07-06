using API.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.DAL.Interfaces
{
    public interface IMovieRepository: IBaseRepository<Movie>
    {
        public Task<List<Actor>> GetActorsAsync(int id);
        public Task<List<Genre>> GetGenresAsync(int id);
        public Task<bool> AddGenreAsync(MovieGenre entity);
        public Task<bool> AddActorAsync(MovieActor entity);
        public Task<List<Movie>> SelectAsync(int[] idActors, int[] idGenres, string title);
    }
}
