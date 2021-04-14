namespace Blog.Domain.DataTransferObjects
{
    public class KategoriDto
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string UrlAd { get; set; }
        public int? ParentId { get; set; }
        public string RenkKodu { get; set; }
        public bool Selected { get; set; }
    }
}
