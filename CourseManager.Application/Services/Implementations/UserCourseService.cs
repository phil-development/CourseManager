using CourseManager.Application.DTOs;
using CourseManager.Application.Services.Interfaces;
using CourseManager.Domain.Entities;
using CourseManager.Domain.Interfaces;

namespace CourseManager.Application.Services.Implementations
{
    public class UserCourseService : IUserCourseService
    {
        private readonly IUserCourseRepository _userCourseRepository;

        public UserCourseService(IUserCourseRepository userCourseRepository)
        {
            _userCourseRepository = userCourseRepository;
        }

        public async Task<IEnumerable<UserCourseResponseDTO>> GetAllAsync()
        {
            var userCourses = await _userCourseRepository.GetAllAsync();
            return userCourses.Select(uc => new UserCourseResponseDTO
            {
                Id = uc.Id,
                UserId = uc.UserId,
                CourseId = uc.CourseId,
                CreatedAt = uc.CreatedAt,
                UpdatedAt = uc.UpdatedAt
            });
        }

        public async Task<UserCourseResponseDTO?> GetByIdAsync(int id)
        {
            var uc = await _userCourseRepository.GetByIdAsync(id);
            if (uc == null) return null;

            return new UserCourseResponseDTO
            {
                Id = uc.Id,
                UserId = uc.UserId,
                CourseId = uc.CourseId,
                CreatedAt = uc.CreatedAt,
                UpdatedAt = uc.UpdatedAt
            };
        }

        public async Task<UserCourseResponseDTO> CreateAsync(CreateUserCourseDTO dto)
        {
            var userCourse = new UserCourse
            {
                UserId = dto.UserId,
                CourseId = dto.CourseId,
                CreatedAt = DateTime.Now
            };

            await _userCourseRepository.AddAsync(userCourse);
            await _userCourseRepository.SaveChangesAsync();

            return await GetByIdAsync(userCourse.Id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var uc = await _userCourseRepository.GetByIdAsync(id);
            if (uc == null) return false;

            _userCourseRepository.Remove(uc);
            await _userCourseRepository.SaveChangesAsync();
            return true;
        }
    }
}
