using API.Domain.Entity;
using API.Domain.Responce;
using API.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Service.Interfaces
{
    public interface IMovieService
    {
        Task<BaseResponce<IEnumerable<Movie>>> GetMoviesAsync(int[] idActors, int[] idGenres, string title);
        Task<BaseResponce<Movie>> GetMovieAsync(int id);
        Task<BaseResponce<MovieViewModel>> CreateMovieAsync(MovieViewModel model);
        Task<BaseResponce<MovieGenre>> AddGenreAsync(MovieGenre model);
        Task<BaseResponce<MovieActor>> AddActorAsync(MovieActor model);
        Task<BaseResponce<bool>> DeleteMovieAsync(int id);
        Task<BaseResponce<int>> GetCountMoviesAsync();
        Task<BaseResponce<Movie>> GetLastMovieAsync();
        Task<BaseResponce<Movie>> EditMovieAsync(int id, MovieViewModel model);
        Task<BaseResponce<IEnumerable<Actor>>> GetMovieActorsAsync(int id);
        Task<BaseResponce<IEnumerable<Genre>>> GetMovieGenresAsync(int id);
    }
}
