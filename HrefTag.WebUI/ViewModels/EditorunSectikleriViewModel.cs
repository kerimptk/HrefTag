using System.Collections.Generic;
using Blog.Domain.DataTransferObjects;

namespace HrefTag.WebUI.ViewModels
{
    public class EditorunSectikleriViewModel
    {
        public List<EditorunSectikleriDto> editorunSectikleriDtos { get; set; }
        public List<YaziDto> yaziDtos { get; set; }
        public List<ReklamAlanlariDto> reklamAlanlariDtos { get; set; }

    }
}
