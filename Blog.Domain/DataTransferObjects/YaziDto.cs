using System;
using System.Collections.Generic;

namespace Blog.Domain.DataTransferObjects
{
    public class YaziDto
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string UrlBaslik { get; set; }
        public string Icerik { get; set; }
        public string Ozet { get; set; }
        public string OneCikanGorsel { get; set; }
        public int OneCikan { get; set; }
        public int OnayDurumuId { get; set; }
        public int OkunmaSayisi { get; set; }
        public int YorumSayisi { get; set; }
        public DateTime InsertDate { get; set; }
        public string CreateUserFullName { get; set; }
        public string CreateUserAvatar { get; set; }
    }
}
