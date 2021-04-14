using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using System.Collections.Generic;

namespace Blog.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }


        public List<Role> GetListByUserId(int userId)
        {
            return _roleRepository.GetListByUserId(userId);
        }
    }
}
