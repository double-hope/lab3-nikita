using Purse.BLL.DTO;
using Purse.BLL.DTO.User;
using Purse.BLL.Interfaces;

namespace Purse.PL.Helpers
{
    public static class AuthHelper
    {
        public static async Task<UserDTO> Register(IAuthService service)
        {
            var newUser = new NewUserDTO();

            Console.WriteLine("Hello! I don't know you. Who are you? ");
            Console.Write("Enter name: ");
            newUser.Name = Console.ReadLine() ?? throw new ArgumentNullException(nameof(newUser.Name), "Name cannot be null.");

            Console.Write("Enter email: ");
            newUser.Email = Console.ReadLine() ?? throw new ArgumentNullException(nameof(newUser.Email), "Email cannot be null.");

            Console.Write("Enter password: ");
            newUser.Password = Console.ReadLine() ?? throw new ArgumentNullException(nameof(newUser.Password), "Password cannot be null.");

            var registeredUser = await service.RegisterAsync(newUser);

            Console.WriteLine($"User '{registeredUser.Name}' successfully registered with email '{registeredUser.Email}'.");

            return registeredUser;
        }

        public static async Task<UserDTO> Login(IAuthService service)
        {
            var loginUser = new LoginUserDTO();

            Console.WriteLine("Welcome back! Please log in.");
            Console.Write("Enter email: ");
            loginUser.Email = Console.ReadLine() ?? throw new ArgumentNullException(nameof(loginUser.Email), "Email cannot be null.");

            Console.Write("Enter password: ");
            loginUser.Password = Console.ReadLine() ?? throw new ArgumentNullException(nameof(loginUser.Password), "Password cannot be null.");

            var loggedInUser = await service.LoginAsync(loginUser);

            Console.WriteLine($"User '{loggedInUser.Name}' successfully logged in with email '{loggedInUser.Email}'.");
            return loggedInUser;
        }

    }
}
