using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using System.Collections.Generic;

namespace Blog.Domain.Interfaces
{
    public interface IYaziService
    {
        List<Yazi> GetList();
        List<Yazi> GetListSilinmemisWithUser();
        List<Yazi> GetListSilinenWithUser();
        List<Yazi> GetListWithKategoriByOnayli();
        List<Yazi> GetListOnayli();
        List<Yazi> GetListCokOkunanlar();
        List<Yazi> GetAramaSonucList(string keyword);
        List<Yazi> GetListOneCikan(); 
        Yazi GetById(int id);
        Yazi GetWithKategoriYaziById(int id);
        Yazi GetOnayliByUrlBaslik(string urlbaslik);
        Yazi GetByUrlBaslik(string urlbaslik);
        IDataResult<Yazi> Add(Yazi entity);
        IDataResult<Yazi> Update(Yazi entity);
        IResult Delete(Yazi entity);
        IResult DeleteList(List<Yazi> entities);
    }
}
