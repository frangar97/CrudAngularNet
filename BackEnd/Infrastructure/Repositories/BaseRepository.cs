using Core.Features.Base;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly BackEndContext _context;
        protected readonly DbSet<T> _entities;

        public BaseRepository(BackEndContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            T? entity = await FindAsync(id);

            if (entity != null)
            {
                _entities.Remove(entity);
            }
        }

        public async Task<T?> FindAsync(int id)
        {
           return await _entities.FindAsync(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }
    }
}
