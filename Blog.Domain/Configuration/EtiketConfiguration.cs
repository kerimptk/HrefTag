using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Domain.Configuration
{
    public class EtiketConfiguration : IEntityTypeConfiguration<Etiket>
    {
        public void Configure(EntityTypeBuilder<Etiket> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Ad)
                .HasColumnName("ad")
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }

}