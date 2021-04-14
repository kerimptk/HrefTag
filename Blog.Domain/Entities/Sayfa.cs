using BaseCore.Entities;

namespace Blog.Domain.Entities
{
    public class Sayfa : AuditableEntity<int>
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string UrlBaslik { get; set; }
        public string? Icerik { get; set; }
        public string? OneCikanGorsel { get; set; }
        public int OnayDurumuId { get; set; }
    }
}