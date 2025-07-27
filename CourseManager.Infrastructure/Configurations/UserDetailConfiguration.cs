using CourseManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseManager.Infrastructure.Configurations
{
    public class UserDetailConfiguration : IEntityTypeConfiguration<UserDetail>
    {
        public void Configure(EntityTypeBuilder<UserDetail> builder)
        {
            builder.ToTable("USERDETAILS");

            builder.HasKey(ud => ud.Id);

            builder.Property(ud => ud.CPF)
                   .HasColumnName("CPF")
                   .IsRequired()
                   .HasColumnType("CHAR(11)");

            builder.Property(ud => ud.Address)
                   .HasMaxLength(255);

            builder.Property(ud => ud.Phone)
                   .HasMaxLength(20);

            builder.Property(ud => ud.CreatedAt)
                   .HasColumnName("CREATEDAT")
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(ud => ud.UpdatedAt)
                   .HasColumnName("UPDATEDAT");

            // 🔗 Relacionamento 1:1
            builder.HasOne(ud => ud.User)
                   .WithOne(u => u.UserDetail)
                   .HasForeignKey<UserDetail>(ud => ud.CPF)
                   .HasPrincipalKey<User>(u => u.CPF);
        }
    }
}
