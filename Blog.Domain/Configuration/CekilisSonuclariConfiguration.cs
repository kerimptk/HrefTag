using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Domain.Configuration
{
    public class CekilisSonuclariConfiguration : IEntityTypeConfiguration<CekilisSonuclari>
    {
        public void Configure(EntityTypeBuilder<CekilisSonuclari> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CekilisiYapan)
                .HasColumnName("cekilisi_yapan")
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(e => e.CekilisAdi)
               .HasColumnName("cekilis_adi")
               .HasMaxLength(500)
               .IsUnicode(false);

            builder.Property(e => e.CekilisTarihi)
                .HasColumnName("cekilis_tarihi")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.AsilSayisi).HasColumnName("asil_sayisi");

            builder.Property(e => e.YedekSayisi).HasColumnName("yedek_sayisi");

            builder.Property(e => e.CekilisListesi)
               .HasColumnName("cekilis_listesi")
               .HasMaxLength(5000)
               .IsUnicode(false);

            builder.Property(e => e.AsilKazananlar)
                .HasColumnName("asil_kazananlar")
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.YedekKazananlar)
                .HasColumnName("yedek_kazananlar")
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.YayinlansinMi).HasColumnName("yayinlansin_mi");
        }
    }
}