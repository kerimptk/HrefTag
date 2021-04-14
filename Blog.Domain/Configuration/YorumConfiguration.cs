using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Domain.Configuration
{
    public class YorumConfiguration : IEntityTypeConfiguration<Yorum>
    {
        public void Configure(EntityTypeBuilder<Yorum> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.AdSoyad)
                .HasColumnName("ad_soyad")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.CevaplananYorumId).HasColumnName("cevaplanan_yorum_id");

            builder.Property(e => e.Email)
                .HasColumnName("email")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.IpAdres)
                .HasColumnName("ip_adres")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.OnayDurumuId).HasColumnName("onay_durumu_id");

            builder.Property(e => e.Website)
                .HasColumnName("website")
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(e => e.YaziId).HasColumnName("yazi_id");

            builder.Property(e => e.KullaniciYorumu)
                .HasColumnName("yorum")
                .IsUnicode(false);

            //builder.HasOne(d => d.Yazi)
            //    .WithMany(p => p.Yorumlar)
            //    .HasForeignKey(d => d.YaziId)
            //    .HasConstraintName("FK__tbl_yorum__yazi___5EBF139D");

        }
    }
}
