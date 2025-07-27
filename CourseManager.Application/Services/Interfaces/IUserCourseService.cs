using CourseManager.Application.DTOs;

namespace CourseManager.Application.Services.Interfaces
{
    public interface IUserCourseService
    {
        Task<IEnumerable<UserCourseResponseDTO>> GetAllAsync();
        Task<UserCourseResponseDTO?> GetByIdAsync(int id);
        Task<UserCourseResponseDTO> CreateAsync(CreateUserCourseDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
