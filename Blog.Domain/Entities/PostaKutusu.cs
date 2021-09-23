using BaseCore.Entities;

namespace Blog.Domain.Entities
{
    public class PostaKutusu : AuditableEntity<int>
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string Konu { get; set; }
        public string Mesaj { get; set; }
        public string IpAdresi { get; set; }
        public int? OnayDurumuId { get; set; }
        public int? SilId { get; set; }
    }
}