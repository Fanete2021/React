using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Domain.Entity;
using API.Service.Interfaces;
using API.Domain.ViewModels;
using System.Net.Http;
using System.Net;

namespace API.Controllers
{
    [Route("movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var response = await _movieService.GetMovieAsync(id);

            return this.Ok(response.Data);
        }

        [HttpGet("last")]
        public async Task<ActionResult<Movie>> GetLastMovie()
        {
            var response = await _movieService.GetLastMovieAsync();

            return this.Ok(response.Data);
        }

        [HttpGet]
        public async Task<ActionResult<Movie>> GetMovies([FromQuery] int[] idActors, [FromQuery] int[] idGenres, 
                                                        string title, int limit = 10, int page = 1)
        {
            if (title == null)
                title = "";

            var response = await _movieService.GetMoviesAsync(idActors, idGenres, title);

            Response.Headers["x-total-count"] = response.Data.Count().ToString();

            return this.Ok(response.Data.Skip(limit * (page - 1)).Take(limit));
        }

        [HttpGet("{id}/actors")]
        public async Task<ActionResult<Movie>> GetMovieActors(int id)
        {
            var response = await _movieService.GetMovieActorsAsync(id);

            return this.Ok(response.Data);
        }

        [HttpGet("{id}/genres")]
        public async Task<ActionResult<Movie>> GetMovieGenres(int id)
        {
            var response = await _movieService.GetMovieGenresAsync(id);

            return this.Ok(response.Data);
        }



        [HttpPost]
        public async Task<ActionResult<Movie>> CreateMovie(MovieViewModel model)
        {
            await _movieService.CreateMovieAsync(model);

            return this.Ok(model);
        }

        [HttpPost("genres")]
        public async Task<ActionResult<Movie>> AddGenre(Movie_GenreViewModel model)
        {
            await _movieService.AddGenreAsync(model);

            return this.Ok(model);
        }

        [HttpPost("actors")]
        public async Task<ActionResult<Movie>> AddActor(Movie_ActorViewModel model)
        {
            await _movieService.AddActorAsync(model);

            return this.Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> DeleteMovie(int id)
        {
            await _movieService.DeleteMovieAsync(id);

            return this.Ok();
        }
    }
}
