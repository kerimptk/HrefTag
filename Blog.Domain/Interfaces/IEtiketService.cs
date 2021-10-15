using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using System.Collections.Generic;

namespace Blog.Domain.Interfaces
{
    public interface IEtiketService
    {
        List<Etiket> GetList();
        Etiket GetById(int id);
        Etiket GetByEtiketAdi(string etiketAdi);
        IDataResult<Etiket> Add(Etiket entity);
        IDataResult<Etiket> Update(Etiket entity);
        IResult Delete(Etiket entity);
        IResult DeleteList(List<Etiket> entities);
    }

}
