namespace Blog.Domain.DataTransferObjects
{
    public class KategoriYaziListDto
    {
        public string Baslik { get; set; }
        public string UrlBaslik { get; set; }
        public string Icerik { get; set; }
        public string OneCikanGorsel { get; set; }
        public int OkunmaSayisi { get; set; }
        public int OneCikan { get; set; }

        public string KategoriRenkKodu { get; set; }
        public string KategoriUrlAd { get; set; }
        public string KategoriAd { get; set; }

    }
}
