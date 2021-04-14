using BaseCore.DataAccess.Concrete;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using Blog.Infrastructure.Context;

namespace Blog.Infrastructure.Repository.EntityFrameworkCore
{
    public class EfCoreCekilisSonuclariRepository : EfCoreGenericRepository<CekilisSonuclari, BlogContext>, ICekilisSonuclariRepository
    {
        public EfCoreCekilisSonuclariRepository(BlogContext context) : base(context)
        {

        }
    }
}
