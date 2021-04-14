using BaseCore.Constants;
using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Application.Services
{
    public class ToDoListService : IToDoListService
    {
        readonly IToDoListRepository _toDoListRepository;
        public ToDoListService(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }

        public IDataResult<ToDoList> Add(ToDoList entity)
        {
            var result = _toDoListRepository.Add(entity);
            if (!result.Success)
                return new ErrorDataResult<ToDoList>(entity, Messages.Hata);
            return new SuccessDataResult<ToDoList>(entity, Messages.Basarili);
        }

        public IResult Delete(ToDoList entity)
        {
            var result = _toDoListRepository.Delete(entity);
            if (!result.Success)
                return new ErrorResult(Messages.Hata);
            return new SuccessResult(Messages.Basarili);
        }

        public IResult DeleteList(List<ToDoList> entities)
        {
            foreach (var entitiy in entities)
            {
                _toDoListRepository.Delete(entitiy);
            }
            return new SuccessResult(Messages.Basarili);
        }

        public ToDoList GetById(int id)
        {
            return _toDoListRepository.Get(x => x.Id == id);
        }

        public List<ToDoList> GetList()
        {
            return _toDoListRepository.GetList().ToList();
        }

        public IDataResult<ToDoList> Update(ToDoList entity)
        {
            var result = _toDoListRepository.Update(entity);
            if (!result.Success)
                return new ErrorDataResult<ToDoList>(entity, Messages.Hata);
            return new SuccessDataResult<ToDoList>(entity, Messages.Basarili);
        }
    }
}
