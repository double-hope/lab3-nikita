using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Purse.BLL.Interfaces;
using Purse.BLL.Mappers;
using Purse.BLL.Services;
using Purse.DAL;
using Purse.DAL.Interfaces;
using Purse.DAL.Repositories;

namespace Purse.PL
{
    public class Program
    {
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
           return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(builder =>
                {
                    builder.AddJsonFile("appsettings.json");
                })
               .ConfigureServices((context, services) =>
               {
                   services.AddAutoMapper(conf =>
                   {
                       conf.AddProfile(new DataMapperProfile());
                   });
                   services.AddDbContext<DataContext>();
                   services.AddScoped<IDbInitializer, DbInitializer>();
                   services.AddScoped<IUnitOfWork, UnitOfWork>();

                   services.AddScoped<IAuthService, AuthService>();
                   services.BuildServiceProvider();
                   services.AddHostedService<App>();
               });
        }

        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var dbInitializer = services.GetRequiredService<IDbInitializer>();
                dbInitializer.Initialize();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while initializing the database.");
                Console.WriteLine(ex.Message);
            }

            host.Run();
        }
    }
}