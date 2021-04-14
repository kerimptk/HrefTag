using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using System.Collections.Generic;


namespace Blog.Domain.Interfaces
{
    public interface IYorumService
    {
        List<Yorum> GetList();
        Yorum GetById(int id);
        IDataResult<Yorum> Add(Yorum entity);
        IDataResult<Yorum> Update(Yorum entity);
        IResult Delete(Yorum entity);
        IResult DeleteList(List<Yorum> entities);
        List<Yorum> GetOnayBekleyelerList();
        List<Yorum> GetOnaylilarList();
        List<Yorum> GetSilinmisList();
    }
}
