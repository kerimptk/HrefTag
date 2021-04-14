using System.Collections.Generic;
using Blog.Domain.DataTransferObjects;

namespace HrefTag.WebUI.ViewModels
{
    public class HeadViewModel
    {
        public List<GenelAyarlarDto> genelAyarlarDtos { get; set; }
        public SeoAyarlariDto seoAyarlariDto { get; set; }
    }
}
