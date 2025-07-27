using CourseManager.Application.DTOs;

namespace CourseManager.Application.Services.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseResponseDTO>> GetAllAsync();
        Task<CourseResponseDTO?> GetByIdAsync(int id);
        Task<CourseResponseDTO> CreateAsync(CreateCourseDTO dto);
        Task<bool> UpdateAsync(int id, UpdateCourseDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
