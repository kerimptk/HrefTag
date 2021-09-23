using System;

namespace Blog.Domain.DataTransferObjects
{
    public class PostaKutusuDto
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
        public DateTime InsertDate { get; set; }
    }
}
