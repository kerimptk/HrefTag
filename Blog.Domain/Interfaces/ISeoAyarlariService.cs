using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using System.Collections.Generic;

namespace Blog.Domain.Interfaces
{
    public interface ISeoAyarlariService
    {
        List<SeoAyarlari> GetList();
        SeoAyarlari GetById(int id);
        IDataResult<SeoAyarlari> Add(SeoAyarlari entity);
        IDataResult<SeoAyarlari> Update(SeoAyarlari entity);
        IResult Delete(SeoAyarlari entity);
        IResult DeleteList(List<SeoAyarlari> entities);
    }
}
