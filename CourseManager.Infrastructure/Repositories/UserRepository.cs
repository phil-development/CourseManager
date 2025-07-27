using CourseManager.Domain.Entities;
using CourseManager.Domain.Interfaces;
using CourseManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CourseManager.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(CourseManagerContext context) : base(context) { }

        public async Task<User?> GetByCPFAsync(string cpf)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.CPF == cpf);
        }
    }
}
