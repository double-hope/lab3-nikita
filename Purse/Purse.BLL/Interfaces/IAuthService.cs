using Purse.BLL.DTO;
using Purse.BLL.DTO.User;
using Purse.DAL.Models;

namespace Purse.BLL.Interfaces
{
    public interface IAuthService
    {
        public Task<UserDTO> RegisterAsync(NewUserDTO newUserDto);
        public Task<UserDTO> LoginAsync(LoginUserDTO loginUserDto);
    }
}
