using BaseCore.Constants;
using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Application.Services
{
    class KategoriYaziService : IKategoriYaziService
    {
        readonly IKategoriYaziRepository _kategoriYaziRepository;

        public KategoriYaziService(IKategoriYaziRepository kategoriYaziRepository)
        {
            _kategoriYaziRepository = kategoriYaziRepository;
        }

        public IDataResult<KategoriYazi> Add(KategoriYazi entity)
        {
            var result = _kategoriYaziRepository.Add(entity);
            if (!result.Success)
                return new ErrorDataResult<KategoriYazi>(entity, Messages.Hata);
            return new SuccessDataResult<KategoriYazi>(entity, Messages.Basarili);
        }

        public IResult Delete(KategoriYazi entity)
        {
            var result = _kategoriYaziRepository.Delete(entity);
            if (!result.Success)
                return new ErrorResult(Messages.Hata);
            return new SuccessResult(Messages.Basarili);
        }

        public IResult DeleteList(List<KategoriYazi> entities)
        {
            foreach (var entitiy in entities)
            {
                _kategoriYaziRepository.Delete(entitiy);
            }
            return new SuccessResult(Messages.Basarili);
        }

        public List<KategoriYazi> GetList()
        {
            return _kategoriYaziRepository.GetList().ToList();
        }

        public List<KategoriYazi> GetListKategoriByYaziId(int id)
        {
            return _kategoriYaziRepository.GetList(x => x.YaziId == id).ToList();
        }

        public IDataResult<KategoriYazi> Update(KategoriYazi entity)
        {
            var result = _kategoriYaziRepository.Update(entity);
            if (!result.Success)
                return new ErrorDataResult<KategoriYazi>(entity, Messages.Hata);
            return new SuccessDataResult<KategoriYazi>(entity, Messages.Basarili);
        }

        public List<KategoriYazi> GetListByKategori(int id)
        {
            return _kategoriYaziRepository.GetList(x => x.KategoriId == id).ToList();
        }

        public List<KategoriYazi> GetListByKategoriIdWithYazi(int id)
        {
            return _kategoriYaziRepository.GetListWithYazi(i => i.KategoriId == id && i.Yazi.OnayDurumuId == 1).ToList();
        }

        public List<KategoriYazi> GetListSilinecekKategoriler(int id)
        {
            return _kategoriYaziRepository.GetList(i => i.YaziId == id).ToList();
        }
    }
}
