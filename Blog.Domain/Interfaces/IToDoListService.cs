using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using System.Collections.Generic;

namespace Blog.Domain.Interfaces
{
    public interface IToDoListService
    {
        List<ToDoList> GetList();
        ToDoList GetById(int id);
        IDataResult<ToDoList> Add(ToDoList entity);
        IDataResult<ToDoList> Update(ToDoList entity);
        IResult Delete(ToDoList entity);
        IResult DeleteList(List<ToDoList> entities);
    }
}
