using BaseCore.Constants;
using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Application.Services
{
    public class CekilisSonuclariService : ICekilisSonuclariService
    {
        readonly ICekilisSonuclariRepository _cekilisSonuclariRepository;

        public CekilisSonuclariService(ICekilisSonuclariRepository cekilisSonuclariRepository)
        {
            _cekilisSonuclariRepository = cekilisSonuclariRepository;
        }

        public IDataResult<CekilisSonuclari> Add(CekilisSonuclari entity)
        {
            var result = _cekilisSonuclariRepository.Add(entity);
            if (!result.Success)
                return new ErrorDataResult<CekilisSonuclari>(entity, Messages.Hata);
            return new SuccessDataResult<CekilisSonuclari>(entity, Messages.Basarili);
        }

        public IResult Delete(CekilisSonuclari entity)
        {
            var result = _cekilisSonuclariRepository.Delete(entity);
            if (!result.Success)
                return new ErrorResult(Messages.Hata);
            return new SuccessResult(Messages.Basarili);
        }

        public IResult DeleteList(List<CekilisSonuclari> entities)
        {
            foreach (var entitiy in entities)
            {
                _cekilisSonuclariRepository.Delete(entitiy);
            }
            return new SuccessResult(Messages.Basarili);
        }

        public CekilisSonuclari GetById(int id)
        {
            return _cekilisSonuclariRepository.Get(i => i.Id == id);
        }

        public List<CekilisSonuclari> GetList()
        {
            return _cekilisSonuclariRepository.GetList().ToList();
        }

        public IDataResult<CekilisSonuclari> Update(CekilisSonuclari entity)
        {
            var result = _cekilisSonuclariRepository.Update(entity);
            if (!result.Success)
                return new ErrorDataResult<CekilisSonuclari>(entity, Messages.Hata);
            return new SuccessDataResult<CekilisSonuclari>(entity, Messages.Basarili);
        }
    }
}
