namespace Core.Features.Base
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task AddAsync(T entity);
        Task<T?> FindAsync(int id);
        void Update(T entity);
        Task DeleteAsync(int id);
    }
}
