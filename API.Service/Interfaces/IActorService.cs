using API.Domain.Entity;
using API.Domain.Responce;
using API.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Service.Interfaces
{
    public interface IActorService
    {
        Task<BaseResponce<Actor>> GetActorAsync(int id);
        Task<BaseResponce<IEnumerable<Actor>>> GetActorAsync(string substr, int limit, int page, int[] bannedId);
        Task<BaseResponce<ActorViewModel>> CreateActorAsync(ActorViewModel model);
        Task<BaseResponce<bool>> DeleteActorAsync(int id);
        Task<BaseResponce<int>> GetCountActorsAsync();
        Task<BaseResponce<Actor>> GetLastActorAsync();
        Task<BaseResponce<Actor>> EditActorAsync(int id, ActorViewModel model);
    }
}
