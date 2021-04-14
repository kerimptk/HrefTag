using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Domain.Configuration
{
    public class YaziConfiguration : IEntityTypeConfiguration<Yazi>
    {
        public void Configure(EntityTypeBuilder<Yazi> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Baslik)
                .HasColumnName("baslik")
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.UrlBaslik)
               .HasColumnName("url_baslik")
               .HasMaxLength(500)
               .IsUnicode(false);

            builder.Property(e => e.Icerik)
                .HasColumnName("icerik")
                .IsUnicode(false);

            builder.Property(e => e.OkunmaSayisi)
                .HasColumnName("okunma_sayisi")
                .HasDefaultValueSql("((0))");

            builder.Property(e => e.OnayDurumuId).HasColumnName("onay_durumu_id");

            builder.Property(e => e.OneCikan).HasColumnName("one_cikan");

            builder.Property(e => e.OneCikanGorsel)
                .HasColumnName("one_cikan_gorsel")
                .HasMaxLength(500)
                .IsUnicode(false);
        }
    }
}