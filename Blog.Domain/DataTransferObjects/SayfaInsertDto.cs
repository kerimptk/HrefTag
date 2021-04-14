using BaseCore.Entities;
using System;
using System.Collections.Generic;

namespace Blog.Domain.DataTransferObjects
{
    public class SayfaInsertDto : Dto<int>
    {
        public string Baslik { get; set; }
        public string UrlBaslik { get; set; }
        public string Icerik { get; set; }
        public string OneCikanGorsel { get; set; }
        public int OnayDurumuId { get; set; }
        public DateTime InsertDate { get; set; }
    }
}
