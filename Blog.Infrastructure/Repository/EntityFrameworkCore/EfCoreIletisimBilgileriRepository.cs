using BaseCore.DataAccess.Concrete;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using Blog.Infrastructure.Context;

namespace Blog.Infrastructure.Repository.EntityFrameworkCore
{
    public class EfCoreIletisimBilgileriRepository : EfCoreGenericRepository<IletisimBilgileri, BlogContext>, IIletisimBilgileriRepository
    {
        public EfCoreIletisimBilgileriRepository(BlogContext context) : base(context)
        {

        }
    }
}
