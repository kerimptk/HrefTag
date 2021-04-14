using BaseCore.DataAccess.Concrete;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using Blog.Infrastructure.Context;

namespace Blog.Infrastructure.Repository.EntityFrameworkCore
{
    public class EfCorePostaKutusuRepository : EfCoreGenericRepository<PostaKutusu, BlogContext>, IPostaKutusuRepository
    {
        public EfCorePostaKutusuRepository(BlogContext context) : base(context)
        {

        }
    }
}
