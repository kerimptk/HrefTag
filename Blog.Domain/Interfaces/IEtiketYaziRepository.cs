using BaseCore.DataAccess.Abstract;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Blog.Domain.Interfaces
{
    public interface IEtiketYaziRepository : IRepository<EtiketYazi>
    {

        List<EtiketYazi> GetListWithEtiket(Expression<Func<EtiketYazi, bool>> filter = null);
    }
}
