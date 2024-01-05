using Microsoft.EntityFrameworkCore;
using Purse.DAL.Interfaces;
using System.Linq.Expressions;

namespace Purse.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _context;
        internal DbSet<T> dbSet;
        public Repository(DataContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;

            query = query.Where(filter);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null) query = query.Where(filter);
            
            return await query.ToListAsync();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}
