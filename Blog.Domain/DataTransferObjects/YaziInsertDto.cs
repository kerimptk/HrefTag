using System;
using System.Collections.Generic;

namespace Blog.Domain.DataTransferObjects
{
    public class YaziInsertDto
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string UrlBaslik { get; set; }
        public string Ozet { get; set; }
        public string Icerik { get; set; }
        public string OneCikanGorsel { get; set; }
        public int OneCikan { get; set; }
        public int? DuyuruMu { get; set; }
        public int OnayDurumuId { get; set; }
        public int? OkunmaSayisi { get; set; }
        public int UserId { get; set; }
        public DateTime InsertDate { get; set; }
        public List<KategoriDto> kategoriDtos { get; set; }
        public GenelAyarlarDto GenelAyarlarDto { get; set; }
        public List<int> SelectedCategoryIds { get; set; }

    }
}
