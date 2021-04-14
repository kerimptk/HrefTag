using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using System.Collections.Generic;

namespace Blog.Domain.Interfaces
{
    public interface IIletisimBilgileriService
    {
        List<IletisimBilgileri> GetList();
        IDataResult<IletisimBilgileri> Add(IletisimBilgileri entity);
        IDataResult<IletisimBilgileri> Update(IletisimBilgileri entity);
        IResult Delete(IletisimBilgileri entity);
        IResult DeleteList(List<IletisimBilgileri> entities);
    }
}
