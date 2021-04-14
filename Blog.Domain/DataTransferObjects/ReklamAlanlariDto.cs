using System;

namespace Blog.Domain.DataTransferObjects
{
    public class ReklamAlanlariDto
    {
        public int Id { get; set; }
        public string AlanAdi { get; set; }
        public string Aciklama { get; set; }
        public string Kodu { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
