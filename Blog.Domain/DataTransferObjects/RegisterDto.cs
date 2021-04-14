using BaseCore.Entities;

namespace Blog.Domain.DataTransferObjects
{
    public class RegisterDto : Dto<int>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string Password { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Job { get; set; }
        public string? Education { get; set; }
        public string? Adress { get; set; }
        public string? Skills { get; set; }
        public string? About { get; set; }
        public string? ImagePath { get; set; }
    }
}
