using AutoMapper;
using Purse.BLL.DTO.User;
using Purse.BLL.DTO;
using Purse.BLL.Interfaces;
using Purse.DAL.Interfaces;
using Purse.DAL.Models;

namespace Purse.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AuthService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDTO> RegisterAsync(NewUserDTO newUserDto)
        {
            if (newUserDto.Email == null)
            {
                throw new ArgumentNullException("Email cannot be null.");
            }
            if (await _unitOfWork.UserRepository.FirstOrDefaultAsync(user => user.Email == newUserDto.Email) != null)
            {
                throw new Exception("User with this email already exists.");
            }

            var user = _mapper.Map<User>(newUserDto);
            user.EmailConfirmed = user.Email;

            user.Password = BCrypt.Net.BCrypt.HashPassword(newUserDto.Password);

            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> LoginAsync(LoginUserDTO loginUserDto)
        {
            var user = await _unitOfWork.UserRepository.FirstOrDefaultAsync(user => user.Email == loginUserDto.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginUserDto.Password, user.Password))
            {
                throw new Exception("Wrong email or password.");
            }

            return _mapper.Map<UserDTO>(user);
        }
    }
}
