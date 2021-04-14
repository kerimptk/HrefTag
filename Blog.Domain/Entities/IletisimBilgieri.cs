using BaseCore.Entities;

namespace Blog.Domain.Entities
{
    public class IletisimBilgileri : Entity<int>
    {
        public int Id { get; set; }
        public string? Aciklama { get; set; }
        public string? Eposta { get; set; }
        public string? Telefon { get; set; }
        public string? Adres { get; set; }
        public string? Harita { get; set; }
    }
}