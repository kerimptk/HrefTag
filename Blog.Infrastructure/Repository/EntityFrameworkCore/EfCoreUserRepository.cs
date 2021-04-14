using BaseCore.DataAccess.Concrete;
using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using Blog.Infrastructure.Context;

namespace Blog.Infrastructure.Repository.EntityFrameworkCore
{
    public class EfCoreUserRepository : EfCoreGenericRepository<Domain.Entities.User, BlogContext>, IUserRepository
    {
        BlogContext _context;
        
        public EfCoreUserRepository(BlogContext context) : base(context)
        {
            _context = context;
        }

        public IDataResult<User> UpdatePassword(User user)
        {
            _context.Users.Attach(user);
            _context.Entry(user).Property(x => x.PasswordHash).IsModified = true;
            _context.Entry(user).Property(x => x.PasswordSalt).IsModified = true;
            _context.SaveChanges();

            return new SuccessDataResult<User>(user);

        }
    }
}
