using CourseManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseManager.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("USERS");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.UserLogin)
                   .HasColumnName("USERLOGIN")
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.UserPassword)
                   .HasColumnName("USERPASSWORD")
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(u => u.CPF)
                   .HasColumnName("CPF")
                   .IsRequired()
                   .HasColumnType("CHAR(11)");

            builder.HasIndex(u => u.CPF).IsUnique();
            builder.HasIndex(u => u.UserLogin).IsUnique();

            builder.Property(u => u.FullName)
                   .HasColumnName("FULLNAME")
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(u => u.BirthDate)
                   .HasColumnName("BIRTHDATE")
                   .IsRequired();

            builder.Property(u => u.CreatedAt)
                   .HasColumnName("CREATEDAT")
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(u => u.UpdatedAt)
                   .HasColumnName("UPDATEDAT");
        }
    }
}
