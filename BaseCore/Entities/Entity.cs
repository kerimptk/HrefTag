using System.ComponentModel.DataAnnotations;

namespace BaseCore.Entities
{
    public class Entity<T>
    {
        [Key]
        public T Id { get; set; }
    }
}
