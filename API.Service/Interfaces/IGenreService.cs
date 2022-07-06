using API.Domain.Entity;
using API.Domain.Responce;
using API.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Service.Interfaces
{
    public interface IGenreService
    {
        Task<BaseResponce<IEnumerable<Genre>>> GetGenresAsync();
        Task<BaseResponce<Genre>> GetGenreAsync(int id);
    }
}
