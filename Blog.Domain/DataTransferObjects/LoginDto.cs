using BaseCore.Entities;

namespace Blog.Domain.DataTransferObjects
{
    public class LoginDto : Dto<int>
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsRemember { get; set; }
    }
}
