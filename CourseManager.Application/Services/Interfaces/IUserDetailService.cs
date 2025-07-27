using CourseManager.Application.DTOs;

namespace CourseManager.Application.Services.Interfaces
{
    public interface IUserDetailService
    {
        Task<IEnumerable<UserDetailResponseDTO>> GetAllAsync();
        Task<UserDetailResponseDTO?> GetByIdAsync(int id);
        Task<UserDetailResponseDTO> CreateAsync(CreateUserDetailDTO dto);
        Task<bool> UpdateAsync(int id, UpdateUserDetailDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
