using System.Collections.Generic;
using Blog.Domain.DataTransferObjects;

namespace HrefTag.WebUI.ViewModels
{
    public class BlogViewModel
    {
        public List<BlogYaziListDto> blogYaziListDtos { get; set; }
        public List<ReklamAlanlariDto> reklamAlanlariDtos { get; set; }

    }
}
