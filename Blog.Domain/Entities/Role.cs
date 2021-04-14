using BaseCore.Entities;

namespace Blog.Domain.Entities
{
    public class Role : Entity<int>
    {
        public string Name { get; set; }
    }
}