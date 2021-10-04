using System.Collections.Generic;
using Blog.Domain.DataTransferObjects;

namespace HrefTag.WebUI.ViewModels
{
    public class IletisimViewModel
    {
        public IletisimBilgileriDto iletisimBilgileriDto { get; set; }
        public List<PopulerIceriklerDto> populerIceriklerDtos { get; set; }
    }
}
