using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Domain.Configuration
{
    public class ReklamAlanlariConfiguration : IEntityTypeConfiguration<ReklamAlanlari>
    {
        public void Configure(EntityTypeBuilder<ReklamAlanlari> builder)
        {
            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Aciklama)
                .HasColumnName("aciklama")
                .HasMaxLength(1000)
                .IsUnicode(false);

            builder.Property(e => e.AlanAdi)
                .HasColumnName("alan_adi")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Kodu)
                .HasColumnName("kodu")
                .HasMaxLength(2500)
                .IsUnicode(false);

            builder.Property(e => e.UpdateDate)
                .HasColumnName("update_date")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");
        }
    }

}