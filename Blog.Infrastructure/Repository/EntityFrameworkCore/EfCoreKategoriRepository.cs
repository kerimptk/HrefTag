using BaseCore.DataAccess.Concrete;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using Blog.Infrastructure.Context;

namespace Blog.Infrastructure.Repository.EntityFrameworkCore
{
    public class EfCoreKategoriRepository : EfCoreGenericRepository<Kategori, BlogContext>, IKategoriRepository
    {
        public EfCoreKategoriRepository(BlogContext context) : base(context)
        {

        }
    }
}
