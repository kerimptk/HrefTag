using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Domain.Configuration
{
    public class SayfaConfiguration : IEntityTypeConfiguration<Sayfa>
    {
        public void Configure(EntityTypeBuilder<Sayfa> builder)
        {
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

            builder.Property(e => e.OnayDurumuId).HasColumnName("onay_durumu_id");

            builder.Property(e => e.OneCikanGorsel)
                .HasColumnName("one_cikan_gorsel")
                .HasMaxLength(500)
                .IsUnicode(false);
        }
    }
}