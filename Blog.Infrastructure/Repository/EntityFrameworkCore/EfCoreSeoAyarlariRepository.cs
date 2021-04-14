using BaseCore.DataAccess.Concrete;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using Blog.Infrastructure.Context;

namespace Blog.Infrastructure.Repository.EntityFrameworkCore
{
    public class EfCoreSeoAyarlariRepository : EfCoreGenericRepository<SeoAyarlari, BlogContext>, ISeoAyarlariRepository
    {
        public EfCoreSeoAyarlariRepository(BlogContext context) : base(context)
        {

        }
    }
}
