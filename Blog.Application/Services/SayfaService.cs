using BaseCore.Constants;
using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Application.Services
{
    public class SayfaService : ISayfaService
    {
        readonly ISayfaRepository _sayfaRepository;

        public SayfaService(ISayfaRepository sayfaRepository)
        {
            _sayfaRepository = sayfaRepository;
        }

        public IDataResult<Sayfa> Add(Sayfa entity)
        {
            var result = _sayfaRepository.Add(entity);
            if (!result.Success)
                return new ErrorDataResult<Sayfa>(entity, Messages.Hata);
            return new SuccessDataResult<Sayfa>(entity, Messages.Basarili);
        }

        public IResult Delete(Sayfa entity)
        {
            var result = _sayfaRepository.Delete(entity);
            if (!result.Success)
                return new ErrorResult(Messages.Hata);
            return new SuccessResult(Messages.Basarili);
        }

        public IResult DeleteList(List<Sayfa> entities)
        {
            foreach (var entitiy in entities)
            {
                _sayfaRepository.Delete(entitiy);
            }
            return new SuccessResult(Messages.Basarili);
        }

        public List<Sayfa> GetList()
        {
            return _sayfaRepository.GetList().ToList();
        }

        public Sayfa GetById(int id)
        {
            return _sayfaRepository.Get(x => x.Id == id);
        }

        public IDataResult<Sayfa> Update(Sayfa entity)
        {
            var result = _sayfaRepository.Update(entity);
            if (!result.Success)
                return new ErrorDataResult<Sayfa>(entity, Messages.Hata);
            return new SuccessDataResult<Sayfa>(entity, Messages.Basarili);
        }

        public Sayfa GetByUrlBaslik(string urlBaslik)
        {
            return _sayfaRepository.Get(x => x.UrlBaslik == urlBaslik);
        }

        public List<Sayfa> GetOnayliList()
        {
            return _sayfaRepository.GetList(x => x.OnayDurumuId == 1).ToList();
        }

        public List<Sayfa> GetListSilinmemis()
        {
            return _sayfaRepository.GetList(x => x.SilId == 0).OrderByDescending(i => i.InsertDate).ToList();
        }

        public List<Sayfa> GetListSilinen()
        {
            return _sayfaRepository.GetList(x => x.SilId == 1).ToList();
        }
    }
}
