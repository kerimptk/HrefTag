using BaseCore.DataAccess.Abstract;
using Blog.Domain.Entities;

namespace Blog.Domain.Interfaces
{
    public interface IYorumRepository : IRepository<Yorum>
    {
        //public List<TblYorumlar> GetListYorumlarWithInformation(Expression<Func<TblYorumlar, bool>> filter);

    }
}
