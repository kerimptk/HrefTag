using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Domain.Configuration
{
    public class GenelAyarlarConfiguration : IEntityTypeConfiguration<GenelAyarlar>
    {
        public void Configure(EntityTypeBuilder<GenelAyarlar> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Favicon)
                .HasColumnName("favicon")
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.LogoUrl)
                .HasColumnName("logo_url")
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.AraclarAktif)
                .HasColumnName("araclar_aktif");

            builder.Property(e => e.DuyurularAktif)
                .HasColumnName("duyurular_aktif");

            builder.Property(e => e.SoruSorAktif)
                .HasColumnName("soru_sor_aktif");

            builder.Property(e => e.YazarlarAktif)
                .HasColumnName("yazarlar_aktif");

            builder.Property(e => e.EditorunSectikleriAktif)
                .HasColumnName("editorun_sectikleri_aktif");

            builder.Property(e => e.PopulerIceriklerAktif)
                .HasColumnName("populer_icerikler_aktif");

            builder.Property(e => e.VideoIceriklerAktif)
                .HasColumnName("video_icerikler_aktif");

            builder.Property(e => e.UpdateDate)
                .HasColumnName("update_date")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");
        }
    }
}