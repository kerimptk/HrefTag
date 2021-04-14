using BaseCore.DataAccess.Concrete;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using Blog.Infrastructure.Context;

namespace Blog.Infrastructure.Repository.EntityFrameworkCore
{
    public class EfCoreReklamAlanlariRepository : EfCoreGenericRepository<ReklamAlanlari, BlogContext>, IReklamAlanlariRepository
    {
        public EfCoreReklamAlanlariRepository(BlogContext context) : base(context)
        {

        }
    }
}
