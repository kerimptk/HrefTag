using Blog.Domain.Entities;
using System.Collections.Generic;

namespace Blog.Domain.Interfaces
{
    public interface IRoleService
    {
        List<Role> GetListByUserId(int userId);
    }
}
