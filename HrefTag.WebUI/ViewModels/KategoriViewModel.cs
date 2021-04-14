using System.Collections.Generic;
using Blog.Domain.DataTransferObjects;

namespace HrefTag.WebUI.ViewModels
{
    public class KategoriYaziViewModel
    {
        public List<KategoriYaziListDto> kategoriYaziListDtos { get; set; }
        public List<ReklamAlanlariDto> reklamAlanlariDtos { get; set; }
    }
}
