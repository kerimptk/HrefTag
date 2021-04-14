using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using System.Collections.Generic;

namespace Blog.Domain.Interfaces
{
    public interface ISayfaService
    {
        List<Sayfa> GetList();
        Sayfa GetById(int id);
        Sayfa GetByUrlBaslik(string urlBaslik);
        List<Sayfa> GetOnayliList();
        List<Sayfa> GetListSilinmemis();
        List<Sayfa> GetListSilinen();
        IDataResult<Sayfa> Add(Sayfa entity);
        IDataResult<Sayfa> Update(Sayfa entity);
        IResult Delete(Sayfa entity);
        IResult DeleteList(List<Sayfa> entities);
    }
}
