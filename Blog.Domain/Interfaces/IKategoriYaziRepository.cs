using BaseCore.DataAccess.Abstract;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Blog.Domain.Interfaces
{
    public interface IKategoriYaziRepository : IRepository<KategoriYazi>
    {

        List<KategoriYazi> GetListWithYazi(Expression<Func<KategoriYazi, bool>> filter = null);
    }
}
