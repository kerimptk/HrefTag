using BaseCore.Entities;
using System;

namespace Blog.Domain.Entities
{
    public class ReklamAlanlari : Entity<int>
    {
        public int Id { get; set; }
        public string AlanAdi { get; set; }
        public string Aciklama { get; set; }
        public string Kodu { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}