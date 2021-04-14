using System.Collections.Generic;
using Blog.Domain.DataTransferObjects;

namespace HrefTag.WebUI.ViewModels
{
    public class AdminSayfaInsertUpdateViewModel
    {
        public List<SayfaInsertDto> sayfaInsertDtos { get; set; }
        public SayfaInsertDto sayfaInsertDto { get; set; }
        public SayfaUpdateDto sayfaUpdateDto { get; set; }
    }
}
