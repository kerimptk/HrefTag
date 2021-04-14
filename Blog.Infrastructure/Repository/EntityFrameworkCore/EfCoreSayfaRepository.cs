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
    public class EfCoreSayfaRepository : EfCoreGenericRepository<Sayfa, BlogContext>, ISayfaRepository
    {
        readonly BlogContext _context;
        public EfCoreSayfaRepository(BlogContext context) : base(context)
        {
            _context = context;
        }
    }
}
