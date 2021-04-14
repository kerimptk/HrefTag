using BaseCore.DataAccess.Abstract;
using Blog.Domain.Entities;
using System.Collections.Generic;

namespace Blog.Domain.Interfaces
{
    public interface IRoleRepository : IRepository<Role>
    {

        List<Role> GetListByUserId(int userId);

    }
}