namespace Blog.Domain.DataTransferObjects
{
    public class PasswordResetUserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string Password { get; set; }
        public string PasswordTekrar { get; set; }
    }
}