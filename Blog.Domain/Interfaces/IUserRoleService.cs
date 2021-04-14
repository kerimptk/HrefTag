using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Domain.Interfaces
{
    public interface IUserRoleService
    {
        public List<UserRole> GetListByUserId(int userId);
        List<UserRole> GetListUserWithRoles();
        IDataResult<UserRole> Add(UserRole userRole);
        IDataResult<UserRole> Update(UserRole userRole);
        Task<IDataResult<UserRole>> AddAsync(UserRole userRole);
        Task<IDataResult<UserRole>> UpdateAsync(UserRole userRole);
    }
}