using BaseCore.Entities;

namespace Blog.Domain.Entities
{
    public class Kategori : AuditableEntity<int>
    {
        public string Ad { get; set; }
        public string UrlAd { get; set; }

        public int? ParentId { get; set; }
        public virtual Kategori Parent { get; set; }

        public string RenkKodu { get; set; }
        public int? YaziSayisi { get; set; }

    }
}
