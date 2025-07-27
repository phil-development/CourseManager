using CourseManager.Domain.Entities;
using CourseManager.Domain.Interfaces;
using CourseManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CourseManager.Infrastructure.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(CourseManagerContext context) : base(context) { }

        public async Task<Course?> GetByNameAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.CourseName == name);
        }
    }
}
