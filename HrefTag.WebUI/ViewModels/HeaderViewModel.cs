using System.Collections.Generic;
using Blog.Domain.DataTransferObjects;

namespace HrefTag.WebUI.ViewModels
{
    public class HeaderViewModel
    {
        public GenelAyarlarDto genelAyarlarDto { get; set; }
        public SeoAyarlariDto seoAyarlariDto { get; set; }
        public string keyword { get; set; }
    }
}
