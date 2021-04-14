using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using System.Collections.Generic;

namespace Blog.Domain.Interfaces
{
    public interface IKategoriYaziService
    {
        List<KategoriYazi> GetList();
        List<KategoriYazi> GetListKategoriByYaziId(int id);
        List<KategoriYazi> GetListSilinecekKategoriler(int id);
        IDataResult<KategoriYazi> Add(KategoriYazi entity);
        //IDataResult<KategoriYazi> AddList(List<Kategori> entities, int yaziId);
        List<KategoriYazi> GetListByKategori(int id);
        List<KategoriYazi> GetListByKategoriIdWithYazi(int id);
        IDataResult<KategoriYazi> Update(KategoriYazi entity);
        IResult Delete(KategoriYazi entity);
        IResult DeleteList(List<KategoriYazi> entities);
    }
}
