using BaseCore.DataAccess.Abstract;
using BaseCore.Utilities.Results;
using Blog.Domain.Entities;

namespace Blog.Domain.Interfaces
{
    // ReSharper disable once InconsistentNaming
    public interface IUserRepository : IRepository<Entities.User>
    {
        IDataResult<User> UpdatePassword(User user);
    }
}