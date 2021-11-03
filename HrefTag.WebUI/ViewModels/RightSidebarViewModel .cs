using System.Collections.Generic;
using Blog.Domain.DataTransferObjects;

namespace HrefTag.WebUI.ViewModels
{
    public class RightSidebarViewModel
    {
        public List<KategoriDto> KategoriDtos { get; set; }
        public List<YaziDto> yaziDtos { get; set; }
    }
}
