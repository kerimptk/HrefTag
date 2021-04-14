using Blog.Domain.DataTransferObjects;
using System.Collections.Generic;

namespace HrefTag.WebUI.ViewModels
{
    public class SearchViewModel
    {
        public List<SearchResponseDto> searchResponseDtos { get; set; }
        public List<ReklamAlanlariDto> reklamAlanlariDtos { get; set; }
        public string keyword { get; set; }
    }
}
