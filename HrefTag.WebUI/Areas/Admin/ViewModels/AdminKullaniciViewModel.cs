using System.Collections.Generic;
using Blog.Domain.DataTransferObjects;

namespace HrefTag.WebUI.ViewModels
{
    public class AdminKullaniciViewModel
    {
        public List<UserListDto> userListDtos { get; set; }
        public RegisterDto registerDto { get; set; }
    }
}
