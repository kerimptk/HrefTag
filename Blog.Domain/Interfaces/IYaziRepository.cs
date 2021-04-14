using BaseCore.DataAccess.Abstract;
using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Blog.Domain.Interfaces
{
    public interface IYaziRepository : IRepository<Yazi>
    {
        Yazi GetWithKategoriYazi(Expression<Func<Yazi, bool>> filter);
        List<Yazi> GetListWithKategori(Expression<Func<Yazi, bool>> filter);
        List<Yazi> GetListWithUser(Expression<Func<Yazi, bool>> filter);
        //new IDataResult<Yazi> Update(Yazi entity);
    };


}
