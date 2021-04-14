using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Domain.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasOne(i => i.User)
                .WithOne()
                .HasForeignKey<UserRole>(i => i.UserId);

            builder.HasOne(i => i.Role)
                .WithOne()
                .HasForeignKey<UserRole>(i => i.RoleId);

            builder.Property(i => i.UserId)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(i => i.RoleId)
                .IsRequired()
                .HasColumnType("int");

        }
    }
}