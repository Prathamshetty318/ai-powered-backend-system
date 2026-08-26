using IdentityHub.Domain.Entities;
using System.Collections.Generic;

namespace IdentityHub.Domain.Interfaces
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
