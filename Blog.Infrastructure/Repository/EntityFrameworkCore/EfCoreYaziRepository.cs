using BaseCore.DataAccess.Concrete;
using BaseCore.Utilities.Results;
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
    public class EfCoreYaziRepository : EfCoreGenericRepository<Yazi, BlogContext>, IYaziRepository
    {
        readonly BlogContext _context;

        public EfCoreYaziRepository(BlogContext context) : base(context)
        {
            _context = context;
        }

        public List<Yazi> GetListWithKategori(Expression<Func<Yazi, bool>> filter)
        {
            return filter == null
                ? _context.Yazilar.Include(i => i.KategoriYazilar)
                .ThenInclude(c => c.Kategori).Include(x => x.User).ToList()
                : _context.Yazilar.Include(i => i.KategoriYazilar)
                .ThenInclude(c => c.Kategori).Include(x => x.User).Where(filter).ToList();
        }

        public List<Yazi> GetListWithUser(Expression<Func<Yazi, bool>> filter)
        {
            return filter == null
                ? _context.Set<Yazi>().Include(i => i.User).Where(filter).ToList()
                : _context.Set<Yazi>().Include(i => i.User).Where(filter).ToList();
        }

        public Yazi GetWithKategoriYazi(Expression<Func<Yazi, bool>> filter)
        {
            return filter == null
                ? _context.Yazilar.Include(i => i.KategoriYazilar).FirstOrDefault(filter)
                : _context.Yazilar.Include(i => i.KategoriYazilar).FirstOrDefault(filter);
        }
    }
}
