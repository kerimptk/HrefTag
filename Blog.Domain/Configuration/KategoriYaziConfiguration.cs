using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Domain.Configuration
{
    public class KategoriYaziConfiguration : IEntityTypeConfiguration<KategoriYazi>
    {
        public void Configure(EntityTypeBuilder<KategoriYazi> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(e => e.Id).HasColumnName("id");


            //builder.HasOne(i => i.Yazi)
            //    .WithOne()
            //    .HasForeignKey<KategoriYazi>(c => c.YaziId);

            //builder.HasOne(i => i.Kategori)
            //    .WithOne()
            //    .HasForeignKey<KategoriYazi>(c => c.KategoriId);


            builder.Property(e => e.YaziId).HasColumnName("yazi_id");

            builder.Property(e => e.KategoriId).HasColumnName("kategori_id");


        }
    }
}
