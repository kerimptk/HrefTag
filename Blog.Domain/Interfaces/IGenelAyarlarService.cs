using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using System.Collections.Generic;

namespace Blog.Domain.Interfaces
{
    public interface IGenelAyarlarService
    {
        List<GenelAyarlar> GetList();
        GenelAyarlar GetById(int id);
        IDataResult<GenelAyarlar> Add(GenelAyarlar entity);
        IDataResult<GenelAyarlar> Update(GenelAyarlar entity);
        IResult Delete(GenelAyarlar entity);
        IResult DeleteList(List<GenelAyarlar> entities);
    }
}
