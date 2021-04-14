using BaseCore.DataAccess.Concrete;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using Blog.Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Infrastructure.Repository.EntityFrameworkCore
{
    public class EfCoreRoleRepository : EfCoreGenericRepository<Role, BlogContext>, IRoleRepository
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public EfCoreRoleRepository(BlogContext context, IUserRoleRepository userRoleRepository) : base(context)
        {
            _userRoleRepository = userRoleRepository;
        }


        public List<Role> GetListByUserId(int userId)
        {
            var userRolesList = _userRoleRepository.GetList().Where(i => i.UserId == userId).ToList();
            var rolesList = GetList().ToList();
            var query = (from userRoles in userRolesList
                         join roles in rolesList on userRoles.RoleId equals roles.Id
                         select new Role
                         {
                             Id = roles.Id,
                             Name = roles.Name
                         }).ToList();

            return query;
        }
    }
}