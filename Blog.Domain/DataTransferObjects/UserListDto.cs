namespace Blog.Domain.DataTransferObjects
{
    public class UserListDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string PasswordHash { get; set; }
        public string CreateUserFullName { get; set; }
    }
}