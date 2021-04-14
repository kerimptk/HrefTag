using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Domain.Interfaces
{
    public interface IUserService
    {
        User FindByEmailAsyncUser(string email);
        User GetById(int id);
        List<User> GetList();
        User GetByUsername(string username);
        bool IsUserExistByUsername(string username, string currentUsername = null);
        IResult IsUserExistByEmail(string email, string currentEmail = null);
        IDataResult<User> Add(User user);
        IDataResult<User> Update(User user);
        Task<IDataResult<User>> AddAsync(User user);
        Task<IDataResult<User>> UpdateAsync(User user);
        User GetByEmail(string email);

    }
}
