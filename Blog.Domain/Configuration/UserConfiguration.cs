using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Domain.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.UserName)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("nvarchar(150)");

            builder.Property(i => i.Email)
                .HasMaxLength(150)
                .HasColumnType("nvarchar(150)");

            builder.Property(i => i.Name)
                .HasMaxLength(150)
                .HasColumnType("nvarchar(150)");

            builder.Property(i => i.Surname)
                .HasMaxLength(150)
                .HasColumnType("nvarchar(150)");

            builder.Property(i => i.Job)
                .HasMaxLength(150)
                .HasColumnType("nvarchar(150)");

            builder.Property(i => i.Education)
                .HasMaxLength(150)
                .HasColumnType("nvarchar(150)");

            builder.Property(i => i.Adress)
                .HasMaxLength(500)
                .HasColumnType("nvarchar(500)");

            builder.Property(i => i.Skills)
                .HasMaxLength(500)
                .HasColumnType("nvarchar(500)");

            builder.Property(i => i.About)
                .HasMaxLength(1500)
                .HasColumnType("nvarchar(5000)");

            builder.Property(i => i.ImagePath)
                .HasMaxLength(500)
                .HasColumnType("nvarchar(500)");
        }
    }
}
