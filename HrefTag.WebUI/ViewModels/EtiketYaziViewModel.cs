using System.Collections.Generic;
using Blog.Domain.DataTransferObjects;

namespace HrefTag.WebUI.ViewModels
{
    public class EtiketYaziViewModel
    {
        public List<EtiketYaziListDto> etiketYaziListDtos { get; set; }
        public EtiketDto etiketDto { get; set; }
        public List<ReklamAlanlariDto> reklamAlanlariDtos { get; set; }
    }
}
