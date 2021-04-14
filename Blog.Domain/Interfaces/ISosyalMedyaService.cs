using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using System.Collections.Generic;

namespace Blog.Domain.Interfaces
{
    public interface ISosyalMedyaService
    {
        List<SosyalMedya> GetList();
        SosyalMedya GetById(int id);
        IDataResult<SosyalMedya> Add(SosyalMedya entity);
        IDataResult<SosyalMedya> Update(SosyalMedya entity);
        IResult Delete(SosyalMedya entity);
        IResult DeleteList(List<SosyalMedya> entities);
    }
}
