using CourseManager.Domain.Entities;

namespace CourseManager.Domain.Interfaces
{
    public interface IUserCourseRepository : IGenericRepository<UserCourse>
    {
        Task<IEnumerable<UserCourse>> GetByUserIdAsync(int userId);
    }
}
