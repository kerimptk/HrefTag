using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Domain.Configuration
{
    public class PostaKutusuConfiguration : IEntityTypeConfiguration<PostaKutusu>
    {
        public void Configure(EntityTypeBuilder<PostaKutusu> builder)
        {
            builder.ToTable("PostaKutusu");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Ad)
                .HasColumnName("ad")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Soyad)
                .HasColumnName("soyad")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Email)
                .HasColumnName("email")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.WebSite)
                .HasColumnName("website")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Konu)
                .HasColumnName("konu")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Mesaj)
                .HasColumnName("mesaj")
                .HasMaxLength(2500)
                .IsUnicode(false);

            builder.Property(e => e.IpAdresi)
                .HasColumnName("ip_adresi")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.OnayDurumuId)
                .HasColumnName("onay_durumu_id")
                .HasDefaultValueSql("((0))");

            builder.Property(e => e.SilId)
                .HasColumnName("SilId")
                .HasDefaultValueSql("((0))");
        }
    }

}