using CourseManager.Application.DTOs;
using CourseManager.Application.Services.Interfaces;
using CourseManager.Domain.Entities;
using CourseManager.Domain.Interfaces;

namespace CourseManager.Application.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<CourseResponseDTO>> GetAllAsync()
        {
            var courses = await _courseRepository.GetAllAsync();
            return courses.Select(c => new CourseResponseDTO
            {
                Id = c.Id,
                CourseName = c.CourseName,
                CourseDescription = c.CourseDescription,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt
            });
        }

        public async Task<CourseResponseDTO?> GetByIdAsync(int id)
        {
            var c = await _courseRepository.GetByIdAsync(id);
            if (c == null) return null;

            return new CourseResponseDTO
            {
                Id = c.Id,
                CourseName = c.CourseName,
                CourseDescription = c.CourseDescription,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt
            };
        }

        public async Task<CourseResponseDTO> CreateAsync(CreateCourseDTO dto)
        {
            var course = new Course
            {
                CourseName = dto.CourseName,
                CourseDescription = dto.CourseDescription,
                CreatedAt = DateTime.Now
            };

            await _courseRepository.AddAsync(course);
            await _courseRepository.SaveChangesAsync();

            return await GetByIdAsync(course.Id);
        }

        public async Task<bool> UpdateAsync(int id, UpdateCourseDTO dto)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null) return false;

            course.CourseName = dto.CourseName;
            course.CourseDescription = dto.CourseDescription;
            course.UpdatedAt = DateTime.Now;

            _courseRepository.Update(course);
            await _courseRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null) return false;

            _courseRepository.Remove(course);
            await _courseRepository.SaveChangesAsync();
            return true;
        }
    }
}
