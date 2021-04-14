using System;

namespace BaseCore.Entities
{
    public class AuditableEntity<T> : Entity<T>
    {
        public T SilId { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
