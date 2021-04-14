using BaseCore.DataAccess.Concrete;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using Blog.Infrastructure.Context;

namespace Blog.Infrastructure.Repository.EntityFrameworkCore
{
    public class EfCoreUserRoleRepository : EfCoreGenericRepository<UserRole, BlogContext>, IUserRoleRepository
    {
        public EfCoreUserRoleRepository(BlogContext context) : base(context)
        {
        }
    }
}
