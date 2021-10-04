using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Domain.Configuration
{
    public class SeoAyarlariConfiguration : IEntityTypeConfiguration<SeoAyarlari>
    {
        public void Configure(EntityTypeBuilder<SeoAyarlari> builder)
        {
            builder.ToTable("SeoAyarlari");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Ad)
                .HasColumnName("ad")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Keywords)
                .HasColumnName("keywords")
                .HasMaxLength(1000)
                .IsUnicode(false);

            builder.Property(e => e.Analytics)
                .HasColumnName("analytics")
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Adsense)
                .HasColumnName("adsense")
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Title)
                .HasColumnName("title")
                .HasMaxLength(500);

            builder.Property(e => e.UpdateDate)
                .HasColumnName("update_date")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");
        }
    }

}