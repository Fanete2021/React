using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Domain.Entity;
using API.Service.Interfaces;
using API.Domain.ViewModels;

namespace API.Controllers
{
    [Route("genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }


        // GET: Genres
        [HttpGet]
        public async Task<ActionResult<Movie>> GetGenres()
        {
            var response = await _genreService.GetGenresAsync();

            if(response.StatusCode == Domain.Enum.StatusCode.OK)
                return this.Ok(response.Data);

            return this.NotFound(response.DescriptionError);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var response = await _genreService.GetGenreAsync(id);

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
                return this.Ok(response.Data);

            return this.NotFound(response.DescriptionError);
        }
    }
}
