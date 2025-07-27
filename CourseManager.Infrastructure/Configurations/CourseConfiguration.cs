using CourseManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseManager.Infrastructure.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("COURSES");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.CourseName)
                   .HasColumnName("COURSENAME")
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(c => c.CourseDescription)
                   .HasColumnName("COURSEDESCRIPTION")
                   .HasMaxLength(255);

            builder.Property(c => c.CreatedAt)
                   .HasColumnName("CREATEDAT")
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(c => c.UpdatedAt)
                   .HasColumnName("UPDATEDAT");
        }
    }
}
