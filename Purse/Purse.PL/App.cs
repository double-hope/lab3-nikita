using Microsoft.Extensions.Hosting;
using Purse.BLL.DTO.User;
using Purse.BLL.Interfaces;
using Purse.PL.Helpers;

namespace Purse.PL
{
    public class App : BackgroundService
    {
        private readonly IAuthService _authService;
        private CancellationToken token;
        private UserDTO? _user;

        public App(IAuthService authService)
        {
            _authService = authService;
        }

        protected override async Task ExecuteAsync(
            CancellationToken stoppingToken)
        {
            token = stoppingToken;
            Console.WriteLine("Welcome in App!");
            try
            {
                await Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops! Something went wrong. {ex.Message}");
            }
        }

        private async Task Run()
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("Choose from the list:");
            Console.WriteLine("1) Register");
            Console.WriteLine("2) Login");

            Console.Write("Enter here:");
            var command = Console.ReadLine();
            switch (command)
            {
                case "1":
                    {
                        _user = await AuthHelper.Register(_authService);
                        break;
                    }
                case "2":
                    {
                        _user = await AuthHelper.Login(_authService);
                        break;
                    }
                case "exit": 
                    {
                        Console.WriteLine("Exiting...");
                        await base.StopAsync(token);
                        break;
                    }
            }
        }
    }
}
