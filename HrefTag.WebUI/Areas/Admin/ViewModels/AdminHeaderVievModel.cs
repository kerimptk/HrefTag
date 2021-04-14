using System.Collections.Generic;
using Blog.Domain.DataTransferObjects;

namespace HrefTag.WebUI.ViewModels
{
    public class AdminHeaderVievModel
    {
        public List<GenelAyarlarDto> genelAyarlarDtos { get; set; }
        public List<SeoAyarlariDto> seoAyarlariDtos { get; set; }
    }
}
