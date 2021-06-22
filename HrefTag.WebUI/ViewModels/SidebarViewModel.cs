using System.Collections.Generic;
using Blog.Domain.DataTransferObjects;

namespace HrefTag.WebUI.ViewModels
{
    public class SidebarViewModel
    {
        public List<KategoriDto> KategoriDtos { get; set; }
        public List<YaziDto> yaziDtos { get; set; }
        public List<SayfaDto> sayfaDtos { get; set; }
        public SosyalMedyaDto sosyalMedyaDto { get; set; }
        public GenelAyarlarDto genelAyarlarDto { get; set; }
        public SeoAyarlariDto seoAyarlariDto { get; set; }
    }
}
