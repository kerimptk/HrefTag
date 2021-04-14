using BaseCore.Entities;

namespace Blog.Domain.Entities
{
    public class Yorum : AuditableEntity<int>
    {
        public string AdSoyad { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string KullaniciYorumu { get; set; }

        public int? CevaplananYorumId { get; set; }
        public virtual Yorum CevaplananYorum { get; set; }

        public string IpAdres { get; set; }

        public int OnayDurumuId { get; set; }

        public int? YaziId { get; set; }
        public virtual Yazi Yazi { get; set; }
    }
}
