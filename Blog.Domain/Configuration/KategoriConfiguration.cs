using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Domain.Configuration
{
    public class KategoriConfiguration : IEntityTypeConfiguration<Kategori>
    {
        public void Configure(EntityTypeBuilder<Kategori> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Ad)
                .HasColumnName("ad")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.ParentId).HasColumnName("parent_id");

            builder.Property(e => e.RenkKodu)
                .HasColumnName("renk_kodu")
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.UrlAd)
                .HasColumnName("url_ad")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.YaziSayisi)
                .HasColumnName("yazi_sayisi")
                .HasDefaultValueSql("((0))");
        }
    }
}
