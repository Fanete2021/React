using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> CreateAsync(T entity);

        Task<T> GetAsync(int id);
        Task<T> GetLastAsync();

        Task<int> GetCountAsync();

        Task<List<T>> SelectAsync();

        Task<bool> DeleteAsync(T entity);

        Task<T> UpdateAsync(T entity);

    }
}
