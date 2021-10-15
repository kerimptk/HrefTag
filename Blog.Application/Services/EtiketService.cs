using BaseCore.Constants;
using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Application.Services
{
    public class EtiketService : IEtiketService
    {
        readonly IEtiketRepository _etiketRepository;

        public EtiketService(IEtiketRepository etiketRepository)
        {
            _etiketRepository = etiketRepository;
        }

        public IDataResult<Etiket> Add(Etiket entity)
        {
            var result = _etiketRepository.Add(entity);
            if (!result.Success)
                return new ErrorDataResult<Etiket>(entity, Messages.Hata);
            return new SuccessDataResult<Etiket>(entity, Messages.Basarili);
        }

        public IResult Delete(Etiket entity)
        {
            var result = _etiketRepository.Delete(entity);
            if (!result.Success)
                return new ErrorResult(Messages.Hata);
            return new SuccessResult(Messages.Basarili);
        }

        public IResult DeleteList(List<Etiket> entities)
        {
            foreach (var entitiy in entities)
            {
                _etiketRepository.Delete(entitiy);
            }
            return new SuccessResult(Messages.Basarili);
        }

        public List<Etiket> GetList()
        {
            return _etiketRepository.GetList().ToList();
        }

        public Etiket GetById(int id)
        {
            return _etiketRepository.Get(x => x.Id == id);
        }

        public IDataResult<Etiket> Update(Etiket entity)
        {
            var result = _etiketRepository.Update(entity);
            if (!result.Success)
                return new ErrorDataResult<Etiket>(entity, Messages.Hata);
            return new SuccessDataResult<Etiket>(entity, Messages.Basarili);
        }

        public Etiket GetByEtiketAdi(string etiketAdi)
        {
            return _etiketRepository.Get(i => i.Ad == etiketAdi);
        }
    }
}
