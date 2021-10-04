using BaseCore.Entities;
using System;

namespace Blog.Domain.Entities
{
    public class SeoAyarlari : Entity<int>
    {
        public string Ad { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string Analytics { get; set; }
        public string Adsense { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}