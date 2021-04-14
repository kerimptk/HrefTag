using System.Collections.Generic;
using Blog.Domain.DataTransferObjects;

namespace HrefTag.WebUI.ViewModels
{
    public class SayfaViewModel
    {
        public SayfaDto SayfaDtos { get; set; }
        public List<PopulerIceriklerDto> populerIceriklerDtos { get; set; }
    }
}
