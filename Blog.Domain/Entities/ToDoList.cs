using BaseCore.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Domain.Entities
{
    public class ToDoList : AuditableEntity<int>
    {
        public string IsinAdi { get; set; }
        public string Icerik { get; set; }

        [ForeignKey("User")]
        public int Olusturan { get; set; }
        public int Durum { get; set; }
        public DateTime SonTarih { get; set; }
        public virtual User User { get; set; }
    }
}