using System.Collections.Generic;
using Blog.Domain.DataTransferObjects;

namespace HrefTag.WebUI.ViewModels
{
    public class CekilisAraciViewModel
    {
        public List<CekilisSonuclariDto> cekilisSonuclariDtos { get; set; }
        public CekilisSonuclariDto cekilisSonuclariDto { get; set; }
        public List<ReklamAlanlariDto> reklamAlanlariDtos { get; set; }
    }
}
