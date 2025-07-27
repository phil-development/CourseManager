using CourseManager.Domain.Entities;

namespace CourseManager.Domain.Interfaces
{
    public interface IUserDetailRepository : IGenericRepository<UserDetail>
    {
        Task<UserDetail?> GetByCPFAsync(string cpf);
    }
}
