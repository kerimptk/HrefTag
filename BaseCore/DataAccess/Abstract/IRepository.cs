using BaseCore.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BaseCore.DataAccess.Abstract
{
    public interface IRepository<T>
    {
        IResult Add(T entity);
        IResult Update(T entity);
        IResult Delete(T entity);
        Task<IResult> AddAsync(T entity);
        Task<IResult> UpdateAsync(T entity);
        Task<IResult> DeleteAsync(T entity);
        IEnumerable<T> GetList(Expression<Func<T, bool>> expression = null);
        T Get(Expression<Func<T, bool>> expression = null);
        T GetWithIncludes(Expression<Func<T, bool>> filter, List<Expression<Func<T, object>>> includes);
        IEnumerable<T> GetListWithIncludes(List<Expression<Func<T, object>>> includes, Expression<Func<T, bool>> filter = null);

    }
}
