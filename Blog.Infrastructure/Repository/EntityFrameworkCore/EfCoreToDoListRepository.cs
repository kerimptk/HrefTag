using BaseCore.DataAccess.Concrete;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using Blog.Infrastructure.Context;

namespace Blog.Infrastructure.Repository.EntityFrameworkCore
{
    public class EfCoreToDoListRepository : EfCoreGenericRepository<ToDoList, BlogContext>, IToDoListRepository
    {
        public EfCoreToDoListRepository(BlogContext context) : base(context)
        {

        }
    }
}
