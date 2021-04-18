using System.Collections.Generic;
using Blog.Domain.DataTransferObjects;

namespace HrefTag.WebUI.ViewModels
{
    public class AdminToDoListVievModel
    {
        public List<ToDoListDto> toDoListDtos { get; set; }
        public ToDoListDto toDoListDto { get; set; }
    }
}
