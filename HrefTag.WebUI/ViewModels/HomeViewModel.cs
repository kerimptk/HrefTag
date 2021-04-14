using System.Collections.Generic;
using Blog.Domain.DataTransferObjects;

namespace HrefTag.WebUI.ViewModels
{
    public class HomeViewModel
    {
        public List<BlogYaziListDto> blogYaziListDtos { get; set; }
        public List<BlogYaziListDto> populerIcerkler { get; set; }
        public List<BlogYaziListDto> oneCikanlar { get; set; }
        public List<ReklamAlanlariDto> reklamAlanlariDtos { get; set; }
        public SosyalMedyaDto sosyalMedyaDto { get; set; }

    }
}
