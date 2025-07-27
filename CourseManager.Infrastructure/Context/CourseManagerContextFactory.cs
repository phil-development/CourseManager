using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CourseManager.Infrastructure.Context
{
    public class CourseManagerContextFactory : IDesignTimeDbContextFactory<CourseManagerContext>
    {
        public CourseManagerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CourseManagerContext>();

            // 🔗 String de conexão usada apenas em design-time (migrations)
            optionsBuilder.UseSqlServer("Server=phil-notebook;Database=CourseManagerDB;User Id=sa;Password=Admin2113;TrustServerCertificate=True;");

            return new CourseManagerContext(optionsBuilder.Options);
        }
    }
}
