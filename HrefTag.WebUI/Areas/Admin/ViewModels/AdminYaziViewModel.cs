using System.Collections.Generic;
using Blog.Domain.DataTransferObjects;

namespace HrefTag.WebUI.ViewModels
{
    public class AdminYaziViewModel
    {
        public List<YaziDto> yaziDtos { get; set; }
        public YaziInsertDto yaziInsertDto { get; set; }
        public YaziDto yaziDto { get; set; }
        public List<KategoriDto> kategoriDtos { get; set; }
        public List<KategoriYaziDto> kategoriYaziDtos { get; set; }
    }
}
