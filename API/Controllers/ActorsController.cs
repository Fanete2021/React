using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Domain.Entity;
using API.Service.Interfaces;
using API.Domain.ViewModels;

namespace API.Controllers
{
    [Route("actors")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService _actorsService;
        private int count = 0;

        public ActorsController(IActorService actorsService)
        {
            _actorsService = actorsService;
        }

        [HttpGet]
        public async Task<ActionResult<Actor>> GetActors(string substr, [FromQuery] int[] bannedId, int limit = 5, int page = 1)
        {
            if (substr == null)
                substr = "";

            if (count == 0)
                count = _actorsService.GetCountActorsAsync().Result.Data;

            Response.Headers["x-total-count"] = count.ToString();

            var responce = await _actorsService.GetActorAsync(substr, limit, page, bannedId);

            return this.Ok(responce.Data);
        }

        [HttpGet("last")]
        public async Task<ActionResult<Actor>> GetLastActor()
        {
            var responce = await _actorsService.GetLastActorAsync();

            return this.Ok(responce.Data);
        }

        [HttpPost]
        public async Task<ActionResult<Actor>> CreateActor(ActorViewModel model)
        {
            await _actorsService.CreateActorAsync(model);

            return this.Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Actor>> DeleteActor(int id)
        {
            await _actorsService.DeleteActorAsync(id);

            return this.Ok();
        }
    }
}
