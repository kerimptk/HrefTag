using BaseCore.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Domain.Entities
{
    public class Yazi : AuditableEntity<int>
    {
        public string Baslik { get; set; }
        public string UrlBaslik { get; set; }
        public string Icerik { get; set; }
        public string OneCikanGorsel { get; set; }
        public int OneCikan { get; set; }
        public int OnayDurumuId { get; set; }
        public int? OkunmaSayisi { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        //public virtual ICollection<EtiketYazi> EtiketYazilar { get; set; }
        public virtual ICollection<KategoriYazi> KategoriYazilar { get; set; }
        //public virtual ICollection<Yorum> Yorumlar { get; set; }

    }
}
