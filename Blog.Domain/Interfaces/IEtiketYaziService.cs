using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using System.Collections.Generic;

namespace Blog.Domain.Interfaces
{
    public interface IEtiketYaziService
    {
        List<EtiketYazi> GetList();
        List<EtiketYazi> GetListWithEtiket(int id);
        EtiketYazi GetById(int id);
        List<EtiketYazi> GetListByEtiketIdWithYazi(int id);
        IDataResult<EtiketYazi> Add(EtiketYazi entity);
        IDataResult<EtiketYazi> Update(EtiketYazi entity);
        IResult Delete(EtiketYazi entity);
        IResult DeleteList(List<EtiketYazi> entities);
    }
}
