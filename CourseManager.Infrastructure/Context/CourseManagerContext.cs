using CourseManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseManager.Infrastructure.Context
{
    public class CourseManagerContext : DbContext
    {
        public CourseManagerContext(DbContextOptions<CourseManagerContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aplica Fluent API
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CourseManagerContext).Assembly);
        }
    }
}
