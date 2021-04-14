using BaseCore.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Domain.Entities
{
    public class KategoriYazi : Entity<int>
    {
        public int YaziId { get; set; }
        public virtual Yazi Yazi { get; set; }
        
        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
    }
}
