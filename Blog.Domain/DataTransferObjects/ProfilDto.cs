using BaseCore.Entities;
using Microsoft.AspNetCore.Http;

namespace Blog.Domain.DataTransferObjects
{
    public class ProfilDto : Dto<int>
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public IFormFile Avatar { get; set; }
        public string Job { get; set; }
        public string Education { get; set; }
        public string Adress { get; set; }
        public string Skills { get; set; }
        public string About { get; set; }

    }
}
