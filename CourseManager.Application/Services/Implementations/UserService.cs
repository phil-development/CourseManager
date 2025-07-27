using CourseManager.Application.DTOs;
using CourseManager.Application.Services.Interfaces;
using CourseManager.Domain.Entities;
using CourseManager.Domain.Interfaces;

namespace CourseManager.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserResponseDTO>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(u => new UserResponseDTO
            {
                Id = u.Id,
                UserLogin = u.UserLogin,
                CPF = u.CPF,
                FullName = u.FullName,
                BirthDate = u.BirthDate,
                CreatedAt = u.CreatedAt,
                UpdatedAt = u.UpdatedAt
            });
        }

        public async Task<UserResponseDTO?> GetByIdAsync(int id)
        {
            var u = await _userRepository.GetByIdAsync(id);
            if (u == null) return null;

            return new UserResponseDTO
            {
                Id = u.Id,
                UserLogin = u.UserLogin,
                CPF = u.CPF,
                FullName = u.FullName,
                BirthDate = u.BirthDate,
                CreatedAt = u.CreatedAt,
                UpdatedAt = u.UpdatedAt
            };
        }

        public async Task<UserResponseDTO> CreateAsync(CreateUserDTO dto)
        {
            var user = new User
            {
                UserLogin = dto.UserLogin,
                UserPassword = dto.UserPassword,
                CPF = dto.CPF,
                FullName = dto.FullName,
                BirthDate = dto.BirthDate,
                CreatedAt = DateTime.Now
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return await GetByIdAsync(user.Id);
        }

        public async Task<bool> UpdateAsync(int id, UpdateUserDTO dto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return false;

            user.FullName = dto.FullName;
            user.BirthDate = dto.BirthDate;
            user.UpdatedAt = DateTime.Now;

            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return false;

            _userRepository.Remove(user);
            await _userRepository.SaveChangesAsync();
            return true;
        }
    }
}
