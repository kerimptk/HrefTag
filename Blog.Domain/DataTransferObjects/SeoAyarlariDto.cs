using System;

namespace Blog.Domain.DataTransferObjects
{
    public class SeoAyarlariDto
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        public string Keywords { get; set; }
        public string Analytics { get; set; }
        public string Adsense { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
