using CourseManager.Domain.Entities;
using CourseManager.Domain.Interfaces;
using CourseManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CourseManager.Infrastructure.Repositories
{
    public class UserDetailRepository : GenericRepository<UserDetail>, IUserDetailRepository
    {
        public UserDetailRepository(CourseManagerContext context) : base(context) { }

        public async Task<UserDetail?> GetByCPFAsync(string cpf)
        {
            return await _dbSet.FirstOrDefaultAsync(ud => ud.CPF == cpf);
        }
    }
}
