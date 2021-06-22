using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Domain.Configuration
{
    public class SosyalMedyaConfiguration : IEntityTypeConfiguration<SosyalMedya>
    {
        public void Configure(EntityTypeBuilder<SosyalMedya> builder)
        {
            builder.ToTable("SosyalMedya");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Twitter)
                .HasColumnName("Twitter")
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Instagram)
                .HasColumnName("Instagram")
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Youtube)
                .HasColumnName("Youtube")
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Linkedin)
                .HasColumnName("Linkedin")
                .HasMaxLength(500)
                .IsUnicode(false);
        }
    }

}