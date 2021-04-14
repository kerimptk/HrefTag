using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using System.Collections.Generic;

namespace Blog.Domain.Interfaces
{
    public interface ICekilisSonuclariService
    {
        List<CekilisSonuclari> GetList();
        CekilisSonuclari GetById(int id);
        IDataResult<CekilisSonuclari> Add(CekilisSonuclari entity);
        IDataResult<CekilisSonuclari> Update(CekilisSonuclari entity);
        IResult Delete(CekilisSonuclari entity);
        IResult DeleteList(List<CekilisSonuclari> entities);
    }

}
