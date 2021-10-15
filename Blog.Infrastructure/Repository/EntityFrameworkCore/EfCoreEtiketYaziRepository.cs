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
    public class EfCoreEtiketYaziRepository : EfCoreGenericRepository<EtiketYazi, BlogContext>, IEtiketYaziRepository
    {
        BlogContext _context;
        public EfCoreEtiketYaziRepository(BlogContext context) : base(context)
        {
            _context = context;
        }
        public List<EtiketYazi> GetListWithEtiket(Expression<Func<EtiketYazi, bool>> filter = null)
        {
            return filter == null
            ? _context.Set<EtiketYazi>().Include(i => i.Yazi).Include(x => x.Etiket).OrderByDescending(i => i.Etiket.Id).ToList()
            : _context.Set<EtiketYazi>().Where(filter).Include(i => i.Yazi).Include(x=> x.Etiket).OrderByDescending(i => i.Yazi.Id).ToList();
        }
    }
}
