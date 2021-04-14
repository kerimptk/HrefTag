using BaseCore.Entities;

namespace Blog.Domain.Entities
{
    public class Etiket : AuditableEntity<int>
    {
        public string Ad { get; set; }
    }
}
