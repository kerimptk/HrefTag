using System.Collections.Generic;
using Blog.Domain.DataTransferObjects;

namespace HrefTag.WebUI.ViewModels
{
    public class AdminHomeViewModel
    {
        public List<YaziDto> yaziDtos { get; set; }
        public List<KategoriDto> kategoriDtos { get; set; }
        public List<YorumDto> yorumDtos { get; set; }
        public List<PostaKutusuDto> postaKutusuDtos { get; set; }
        public List<ProfilDto> accountDtos { get; set; }

    }
}
