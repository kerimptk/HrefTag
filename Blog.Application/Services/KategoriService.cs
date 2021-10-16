using BaseCore.Constants;
using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Application.Services
{
    public class KategoriService : IKategoriService
    {
        readonly IKategoriRepository _kategoriRepository;

        public KategoriService(IKategoriRepository kategoriRepository)
        {
            _kategoriRepository = kategoriRepository;
        }

        public IDataResult<Kategori> Add(Kategori entity)
        {
            var result = _kategoriRepository.Add(entity);
            if (!result.Success)
                return new ErrorDataResult<Kategori>(entity, Messages.Hata);
            return new SuccessDataResult<Kategori>(entity, Messages.Basarili);
        }

        public IResult Delete(Kategori entity)
        {
            var result = _kategoriRepository.Delete(entity);
            if (!result.Success)
                return new ErrorResult(Messages.Hata);
            return new SuccessResult(Messages.Basarili);
        }

        public IResult DeleteList(List<Kategori> entities)
        {
            foreach (var entitiy in entities)
            {
                _kategoriRepository.Delete(entitiy);
            }
            return new SuccessResult(Messages.Basarili);
        }

        public List<Kategori> GetList()
        {
            return _kategoriRepository.GetList().ToList();
        }

        public Kategori GetById(int id)
        {
            return _kategoriRepository.Get(x => x.Id == id);
        }

        public IDataResult<Kategori> Update(Kategori entity)
        {
            var result = _kategoriRepository.Update(entity);
            if (!result.Success)
                return new ErrorDataResult<Kategori>(entity, Messages.Hata);
            return new SuccessDataResult<Kategori>(entity, Messages.Basarili);
        }

        public Kategori GetByAd(string kat)
        {
            return _kategoriRepository.Get(i => i.UrlAd == kat);
        }

        public List<Kategori> GetParentKategoriList()
        {
            return _kategoriRepository.GetList().Where(i => i.ParentMi == true).ToList();
        }
    }
}
