using System.Collections.Generic;
using Blog.Domain.DataTransferObjects;

namespace HrefTag.WebUI.ViewModels
{
    public class AraclarViewModel
    {
        public List<ReklamAlanlariDto> reklamAlanlariDtos { get; set; }
        public HarfKelimeSayaciDto harfKelimeSayaciDto { get; set; }
    }
}
