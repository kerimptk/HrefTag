using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Domain.Configuration
{
    public class ToDoListConfiguration : IEntityTypeConfiguration<ToDoList>
    {
        public void Configure(EntityTypeBuilder<ToDoList> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.IsinAdi)
                .HasColumnName("isin_adi")
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Icerik)
               .HasColumnName("icerik")
               .HasMaxLength(2500)
               .IsUnicode(false);

            builder.Property(e => e.Olusturan).HasColumnName("olusturan");

            builder.Property(e => e.SonTarih)
                .HasColumnName("son_tarih")
                .HasColumnType("datetime");

            builder.Property(e => e.SilId).HasColumnName("sil_id");

            builder.Property(e => e.InsertDate)
                .HasColumnName("insert_date")
                .HasColumnType("datetime");

            builder.Property(e => e.UpdateDate)
                .HasColumnName("update_date")
                .HasColumnType("datetime");
        }
    }
}