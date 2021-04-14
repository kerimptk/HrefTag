using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Blog.Application.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleService(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public List<UserRole> GetListByUserId(int userId)
        {
            return _userRoleRepository.GetList(i => i.UserId == userId).ToList();
        }

        public List<UserRole> GetListUserWithRoles()
        {
            var includes = new List<Expression<Func<UserRole, object>>> { x => x.Role, x => x.User };
            return _userRoleRepository.GetListWithIncludes(includes, null).ToList();
        }

        public IDataResult<UserRole> Add(UserRole userRole)
        {
            var result = _userRoleRepository.Add(userRole);
            return new SuccessDataResult<UserRole>(result.Message);
        }

        public IDataResult<UserRole> Update(UserRole userRole)
        {
            var result = _userRoleRepository.Update(userRole);
            return new SuccessDataResult<UserRole>(result.Message);
        }

        public async Task<IDataResult<UserRole>> AddAsync(UserRole userRole)
        {
            var result = await _userRoleRepository.AddAsync(userRole);
            return new SuccessDataResult<UserRole>(result.Message);
        }

        public async Task<IDataResult<UserRole>> UpdateAsync(UserRole userRole)
        {
            var result = await _userRoleRepository.UpdateAsync(userRole);
            return new SuccessDataResult<UserRole>(result.Message);
        }
    }
}
