using BaseCore.DataAccess.Concrete;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using Blog.Infrastructure.Context;

namespace Blog.Infrastructure.Repository.EntityFrameworkCore
{
    public class EfCoreGenelAyarlarRepository : EfCoreGenericRepository<GenelAyarlar, BlogContext>, IGenelAyarlarRepository
    {
        public EfCoreGenelAyarlarRepository(BlogContext context) : base(context)
        {

        }
    }
}
