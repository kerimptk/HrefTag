using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using System.Collections.Generic;

namespace Blog.Domain.Interfaces
{
    public interface IReklamAlanlariService
    {
        List<ReklamAlanlari> GetList();
        ReklamAlanlari GetByAd(string Ad);
        IDataResult<ReklamAlanlari> Add(ReklamAlanlari entity);
        IDataResult<ReklamAlanlari> Update(ReklamAlanlari entity);
        IResult Delete(ReklamAlanlari entity);
        IResult DeleteList(List<ReklamAlanlari> entities);
    }
}
