using BaseCore.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Domain.Entities
{
    public class EtiketYazi
    {
        public int Id { get; set; }
        public virtual Yazi Yazi { get; set; }
        public int? YaziId { get; set; }

        public virtual Etiket Etiket { get; set; }
        public int? EtiketId { get; set; }

    }
}
