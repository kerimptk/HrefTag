using System.Collections.Generic;
using Blog.Domain.DataTransferObjects;

namespace HrefTag.WebUI.ViewModels
{
    public class AdminYaziUpdateViewModel
    {
        public YaziUpdateDto yaziUpdateDto { get; set; }
        public List<KategoriDto> kategoriDtos { get; set; }
        public GenelAyarlarDto genelAyarlarDto { get; set; }
    }
}
