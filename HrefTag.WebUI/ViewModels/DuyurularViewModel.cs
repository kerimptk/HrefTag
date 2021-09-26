using System.Collections.Generic;
using Blog.Domain.DataTransferObjects;

namespace HrefTag.WebUI.ViewModels
{
    public class DuyurularViewModel
    {
        public List<DuyurularDto> duyurularDtos { get; set; }
        public List<YaziDto> yaziDtos { get; set; }
        public List<ReklamAlanlariDto> reklamAlanlariDtos { get; set; }

    }
}
