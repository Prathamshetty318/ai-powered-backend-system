using UserApi.Models;
using UserApi.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UserApi.Services;
using UserApi.Interfaces;
using UserApi.DTOs;

namespace UserApi.Repositories
{
	public class GenericRepository<T> :  IGenericRepository<T>
		where T : class
	{

		private readonly AppDbContext _context;
		private readonly DbSet<T> _dbset;

		public GenericRepository(AppDbContext context)
		{
			_context = context;
			_dbset = _context.Set<T>();
		}


		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _dbset.ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _dbset.FindAsync(id);
		}

		public async Task AddAsync(T entity)
		{
			await _dbset.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(T entity)
		{
			_dbset.Update(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var entity = await _dbset.FindAsync(id);

			if (entity != null)
			{
				_dbset.Remove(entity);
				await _context.SaveChangesAsync();
			}

		}
	}
}