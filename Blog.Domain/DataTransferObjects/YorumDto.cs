using System;

namespace Blog.Domain.DataTransferObjects
{
    public class YorumDto
    {
        public int Id { get; set; }
        public int YaziId { get; set; }
        public string AdSoyad { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string KullaniciYorumu { get; set; }
        public int? CevaplananYorumId { get; set; }
        public string IpAdres { get; set; }
        public int OnayDurumuId { get; set; }
        public int SilId { get; set; }
        public DateTime InsertDate { get; set; }
        public string YaziUrlBaslik { get; set; }
        public string YaziBaslik { get; set; }
    }
}
