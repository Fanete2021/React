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
            var responce = await _genreService.GetGenresAsync();

            return this.Ok(responce.Data.ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var responce = await _genreService.GetGenreAsync(id);

            return this.Ok(responce.Data);
        }
    }
}
