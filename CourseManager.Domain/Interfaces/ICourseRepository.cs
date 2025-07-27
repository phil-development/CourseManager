using CourseManager.Domain.Entities;

namespace CourseManager.Domain.Interfaces
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<Course?> GetByNameAsync(string name);
    }
}
