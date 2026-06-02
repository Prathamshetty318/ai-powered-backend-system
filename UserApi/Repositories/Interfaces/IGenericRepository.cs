using UserApi.Models;
using UserApi.Services;
using UserApi.Repositories;
using System.Collections.Generic

namespace UserApi.Repositories
{
    public interface IGenericRepository<T>
        where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);
    }
    
}