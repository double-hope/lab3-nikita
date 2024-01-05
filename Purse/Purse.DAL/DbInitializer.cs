using Microsoft.EntityFrameworkCore;

namespace Purse.DAL
{
    public class DbInitializer : IDbInitializer
    {
        private readonly DataContext _context;
        public DbInitializer(DataContext context)
        {
            _context = context;
        }
        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrationsAsync().GetAwaiter().GetResult().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
