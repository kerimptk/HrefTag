using BaseCore.DataAccess.Concrete;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using Blog.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Blog.Infrastructure.Repository.EntityFrameworkCore
{
    public class EfCoreKategoriYaziRepository : EfCoreGenericRepository<KategoriYazi, BlogContext>, IKategoriYaziRepository
    {
        BlogContext _context;
        public EfCoreKategoriYaziRepository(BlogContext context) : base(context)
        {
            _context = context;
        }

        public List<KategoriYazi> GetListWithYazi(Expression<Func<KategoriYazi, bool>> filter = null)
        {
            return filter == null
            ? _context.Set<KategoriYazi>().Include(i => i.Yazi).OrderByDescending(i => i.Yazi.Id).ToList()
            : _context.Set<KategoriYazi>().Where(filter).Include(i => i.Yazi).OrderByDescending(i => i.Yazi.Id).ToList();
        }
    }
}
