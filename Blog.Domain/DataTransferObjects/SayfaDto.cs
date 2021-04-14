using System;

namespace Blog.Domain.DataTransferObjects
{
    public class SayfaDto
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string UrlBaslik { get; set; }
        public string OneCikanGorsel { get; set; }
        public string Icerik { get; set; }
        public int OnayDurumuId { get; set; }
        public DateTime InsertDate { get; set; }
    }
}
