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
            
            if(response.StatusCode == Domain.Enum.StatusCode.OK)
                return this.Ok(response.Data);

            return this.NotFound(response.DescriptionError);
        }

        [HttpGet("last")]
        public async Task<ActionResult<Movie>> GetLastMovie()
        {
            var response = await _movieService.GetLastMovieAsync();

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
                return this.Ok(response.Data);

            return this.NotFound(response.DescriptionError);
        }

        [HttpGet]
        public async Task<ActionResult<Movie>> GetMovies([FromQuery] int[] idActors, [FromQuery] int[] idGenres, 
                                                        string title, int limit = 10, int page = 1)
        {
            if (title == null)
                title = "";

            var response = await _movieService.GetMoviesAsync(idActors, idGenres, title);

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                Response.Headers["x-total-count"] = response.Data.Count().ToString();

                return this.Ok(response.Data.Skip(limit * (page - 1)).Take(limit));
            }

            return this.NotFound(response.DescriptionError);
        }

        [HttpGet("{id}/actors")]
        public async Task<ActionResult<Movie>> GetMovieActors(int id)
        {
            var response = await _movieService.GetMovieActorsAsync(id);

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
                return this.Ok(response.Data);

            return this.NotFound(response.DescriptionError);
        }

        [HttpGet("{id}/genres")]
        public async Task<ActionResult<Movie>> GetMovieGenres(int id)
        {
            var response = await _movieService.GetMovieGenresAsync(id);

            if(response.StatusCode == Domain.Enum.StatusCode.OK)
                return this.Ok(response.Data);

            return this.NotFound(response.DescriptionError);
        }



        [HttpPost]
        public async Task<ActionResult<Movie>> CreateMovie(MovieViewModel model)
        {
            var response = await _movieService.CreateMovieAsync(model);

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
                return this.Ok(response.Data);

            return this.BadRequest(response.DescriptionError);
        }

        [HttpPost("genres")]
        public async Task<ActionResult<MovieGenre>> AddGenre(MovieGenre model)
        {
            var response = await _movieService.AddGenreAsync(model);

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
                return this.Ok(response.Data);

            return this.BadRequest(response.DescriptionError);
        }

        [HttpPost("actors")]
        public async Task<ActionResult<MovieActor>> AddActor(MovieActor model)
        {
            var response = await _movieService.AddActorAsync(model);

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
                return this.Ok(response.Data);

            return this.BadRequest(response.DescriptionError);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> DeleteMovie(int id)
        {
            var response = await _movieService.DeleteMovieAsync(id);

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
                return this.Ok(response.Data);

            return this.BadRequest(response.DescriptionError);
        }
    }
}
