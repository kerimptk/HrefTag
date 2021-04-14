using BaseCore.DataAccess.Concrete;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using Blog.Infrastructure.Context;

namespace Blog.Infrastructure.Repository.EntityFrameworkCore
{
    public class EfCoreEtiketYaziRepository : EfCoreGenericRepository<EtiketYazi, BlogContext>, IEtiketYaziRepository
    {
        public EfCoreEtiketYaziRepository(BlogContext context) : base(context)
        {

        }
    }
}
