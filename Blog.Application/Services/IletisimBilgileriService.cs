using BaseCore.Constants;
using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Application.Services
{
    public class IletisimBilgileriService : IIletisimBilgileriService
    {
        readonly IIletisimBilgileriRepository _iletisimBilgileriRepository;

        public IletisimBilgileriService(IIletisimBilgileriRepository iletisimBilgileriRepository)
        {
            _iletisimBilgileriRepository = iletisimBilgileriRepository;
        }

        public IDataResult<IletisimBilgileri> Add(IletisimBilgileri entity)
        {
            var result = _iletisimBilgileriRepository.Add(entity);
            if (!result.Success)
                return new ErrorDataResult<IletisimBilgileri>(entity, Messages.Hata);
            return new SuccessDataResult<IletisimBilgileri>(entity, Messages.Basarili);
        }

        public IResult Delete(IletisimBilgileri entity)
        {
            var result = _iletisimBilgileriRepository.Delete(entity);
            if (!result.Success)
                return new ErrorResult(Messages.Hata);
            return new SuccessResult(Messages.Basarili);
        }

        public IResult DeleteList(List<IletisimBilgileri> entities)
        {
            foreach (var entitiy in entities)
            {
                _iletisimBilgileriRepository.Delete(entitiy);
            }
            return new SuccessResult(Messages.Basarili);
        }

        public List<IletisimBilgileri> GetList()
        {
            return _iletisimBilgileriRepository.GetList().ToList();
        }

        public IDataResult<IletisimBilgileri> Update(IletisimBilgileri entity)
        {
            var result = _iletisimBilgileriRepository.Update(entity);
            if (!result.Success)
                return new ErrorDataResult<IletisimBilgileri>(entity, Messages.Hata);
            return new SuccessDataResult<IletisimBilgileri>(entity, Messages.Basarili);
        }
    }
}
