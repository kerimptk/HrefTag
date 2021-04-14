using BaseCore.DataAccess.Concrete;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using Blog.Infrastructure.Context;

namespace Blog.Infrastructure.Repository.EntityFrameworkCore
{
    public class EfCoreYorumRepository : EfCoreGenericRepository<Yorum, BlogContext>, IYorumRepository
    {
        public EfCoreYorumRepository(BlogContext context) : base(context)
        {

        }
    }
}
