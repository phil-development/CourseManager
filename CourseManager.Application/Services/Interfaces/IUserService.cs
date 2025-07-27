using CourseManager.Application.DTOs;

namespace CourseManager.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseDTO>> GetAllAsync();
        Task<UserResponseDTO?> GetByIdAsync(int id);
        Task<UserResponseDTO> CreateAsync(CreateUserDTO dto);
        Task<bool> UpdateAsync(int id, UpdateUserDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
