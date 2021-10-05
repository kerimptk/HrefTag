using Blog.Domain.DataTransferObjects;
using System.Collections.Generic;

namespace HrefTag.WebUI.ViewModels
{
    public class YaziViewModel
    {
        public YaziDto Yazi { get; set; }
        public List<ReklamAlanlariDto> Reklamlar { get; set; }
        public YorumDto Yorum { get; set; }
        public List<YorumDto> Yorumlar { get; set; }
        public List<PopulerIceriklerDto> populerIceriklerDtos { get; set; }
        public List<KategoriYaziListDto> kategoriYaziListDtos { get; set; }
    }
}
