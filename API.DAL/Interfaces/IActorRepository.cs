using API.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.DAL.Interfaces
{
    public interface IActorRepository: IBaseRepository<Actor>
    {
        Task<List<Actor>> GetAsync(string substr, int limit, int page, int[] bannedId);
    }
}
