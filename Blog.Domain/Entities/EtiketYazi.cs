using BaseCore.Entities;

namespace Blog.Domain.Entities
{
    public class EtiketYazi : AuditableEntity<int>
    {
        public virtual Yazi Yazi { get; set; }
        public int? YaziId { get; set; }

        public virtual Etiket Etiket { get; set; }
        public int? EtiketId { get; set; }

    }
}
