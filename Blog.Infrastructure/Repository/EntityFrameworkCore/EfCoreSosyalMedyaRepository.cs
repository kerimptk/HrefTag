using BaseCore.DataAccess.Concrete;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using Blog.Infrastructure.Context;

namespace Blog.Infrastructure.Repository.EntityFrameworkCore
{
    public class EfCoreSosyalMedyaRepository : EfCoreGenericRepository<SosyalMedya, BlogContext>, ISosyalMedyaRepository
    {
        public EfCoreSosyalMedyaRepository(BlogContext context) : base(context)
        {

        }
    }
}
