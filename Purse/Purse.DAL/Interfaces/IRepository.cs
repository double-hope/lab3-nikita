using System.Linq.Expressions;

namespace Purse.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
