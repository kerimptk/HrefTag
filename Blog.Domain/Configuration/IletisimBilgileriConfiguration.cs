using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Domain.Configuration
{
    public class IletisimBilgileriConfiguration : IEntityTypeConfiguration<IletisimBilgileri>
    {
        public void Configure(EntityTypeBuilder<IletisimBilgileri> builder)
        {
            builder.HasKey(i => i.Id);

            builder.ToTable("IletisimBilgileri");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.SayfaBasligi)
                .HasColumnName("sayfa_basligi")
                .HasMaxLength(2500)
                .IsUnicode(false);

           builder.Property(e => e.OneCikanGorsel)
                .HasColumnName("one_cikan_gorsel")
                .HasMaxLength(2500)
                .IsUnicode(false);

            builder.Property(e => e.Aciklama)
                .HasColumnName("aciklama")
                .HasMaxLength(2500)
                .IsUnicode(false);

            builder.Property(e => e.Telefon)
                .HasColumnName("telefon")
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.Adres)
                .HasColumnName("adres")
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Harita)
                .HasColumnName("harita")
                .HasMaxLength(2500)
                .IsUnicode(false);

            builder.Property(e => e.Eposta)
                .HasColumnName("eposta")
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }

}