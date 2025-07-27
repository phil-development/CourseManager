using CourseManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseManager.Infrastructure.Configurations
{
    public class UserCourseConfiguration : IEntityTypeConfiguration<UserCourse>
    {
        public void Configure(EntityTypeBuilder<UserCourse> builder)
        {
            builder.ToTable("USERCOURSES");

            builder.HasKey(uc => uc.Id);

            builder.Property(uc => uc.CreatedAt)
                   .HasColumnName("CREATEDAT")
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(uc => uc.UpdatedAt)
                   .HasColumnName("UPDATEDAT");

            // 🔗 Relacionamentos
            builder.HasOne(uc => uc.User)
                   .WithMany(u => u.UserCourses)
                   .HasForeignKey(uc => uc.UserId);

            builder.HasOne(uc => uc.Course)
                   .WithMany(c => c.UserCourses)
                   .HasForeignKey(uc => uc.CourseId);
        }
    }
}
