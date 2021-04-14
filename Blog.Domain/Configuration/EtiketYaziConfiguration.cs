using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Domain.Configuration
{
    public class EtiketYaziConfiguration : IEntityTypeConfiguration<EtiketYazi>
    {
        public void Configure(EntityTypeBuilder<EtiketYazi> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.EtiketId).HasColumnName("etiket_id");

            builder.Property(e => e.YaziId).HasColumnName("yazi_id");


        }
    }
}
