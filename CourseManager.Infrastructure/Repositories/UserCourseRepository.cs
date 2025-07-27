using CourseManager.Domain.Entities;
using CourseManager.Domain.Interfaces;
using CourseManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CourseManager.Infrastructure.Repositories
{
    public class UserCourseRepository : GenericRepository<UserCourse>, IUserCourseRepository
    {
        public UserCourseRepository(CourseManagerContext context) : base(context) { }

        public async Task<IEnumerable<UserCourse>> GetByUserIdAsync(int userId)
        {
            return await _dbSet.Where(uc => uc.UserId == userId).ToListAsync();
        }
    }
}
