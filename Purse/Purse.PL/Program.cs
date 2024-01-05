using Microsoft.Extensions.DependencyInjection;
using Purse.DAL;
using Purse.DAL.Interfaces;
using Purse.DAL.Repositories;

namespace Purse.PL
{
    public class Program
    {
        public IServiceProvider ConfigureServices()
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<DataContext>()
                .AddScoped<IDbInitializer, DbInitializer>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var initializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
                initializer.Initialize();
            }

            return serviceProvider;
        }

        public static void Main(string[] args)
        {
            var program = new Program();
            var serviceProvider = program.ConfigureServices();
        }
    }
}