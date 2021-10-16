using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using System.Collections.Generic;

namespace Blog.Domain.Interfaces
{
    public interface IKategoriService
    {
        List<Kategori> GetList();
        List<Kategori> GetParentKategoriList();
        Kategori GetById(int id);
        Kategori GetByAd(string ad);
        IDataResult<Kategori> Add(Kategori entity);
        IDataResult<Kategori> Update(Kategori entity);
        IResult Delete(Kategori entity);
        IResult DeleteList(List<Kategori> entities);
    }
}
