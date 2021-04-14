using BaseCore.DataAccess.Concrete;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using Blog.Infrastructure.Context;

namespace Blog.Infrastructure.Repository.EntityFrameworkCore
{
    public class EfCoreEtiketRepository : EfCoreGenericRepository<Etiket, BlogContext>, IEtiketRepository
    {
        public EfCoreEtiketRepository(BlogContext context) : base(context)
        {

        }
    }
}
