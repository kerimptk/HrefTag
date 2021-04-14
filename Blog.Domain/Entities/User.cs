using BaseCore.Entities;

namespace Blog.Domain.Entities
{
    public class User : Entity<int>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Job { get; set; }
        public string Education { get; set; }
        public string Adress { get; set; }
        public string Skills { get; set; }
        public string About { get; set; }
        public string ImagePath { get; set; }
    }
}
