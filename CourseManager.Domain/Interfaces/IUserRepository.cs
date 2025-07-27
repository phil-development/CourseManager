using CourseManager.Domain.Entities;

namespace CourseManager.Domain.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetByCPFAsync(string cpf);
    }
}
