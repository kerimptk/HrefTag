using BaseCore.Entities;
using System;

namespace Blog.Domain.Entities
{
    public class ToDoList : AuditableEntity<int>
    {
        public string IsinAdi { get; set; }
        public string Icerik { get; set; }
        public int Olusturan { get; set; }
        public int Durum { get; set; }
        public DateTime SonTarih { get; set; }
    }
}