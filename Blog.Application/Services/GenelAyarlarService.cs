using BaseCore.Constants;
using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Application.Services
{
    public class GenelAyarlarService : IGenelAyarlarService
    {
        readonly IGenelAyarlarRepository _genelAyarlarRepository;

        public GenelAyarlarService(IGenelAyarlarRepository genelAyarlarRepository)
        {
            _genelAyarlarRepository = genelAyarlarRepository;
        }

        public IDataResult<GenelAyarlar> Add(GenelAyarlar entity)
        {
            var result = _genelAyarlarRepository.Add(entity);
            if (!result.Success)
                return new ErrorDataResult<GenelAyarlar>(entity, Messages.Hata);
            return new SuccessDataResult<GenelAyarlar>(entity, Messages.Basarili);
        }

        public IResult Delete(GenelAyarlar entity)
        {
            var result = _genelAyarlarRepository.Delete(entity);
            if (!result.Success)
                return new ErrorResult(Messages.Hata);
            return new SuccessResult(Messages.Basarili);
        }

        public IResult DeleteList(List<GenelAyarlar> entities)
        {
            foreach (var entitiy in entities)
            {
                _genelAyarlarRepository.Delete(entitiy);
            }
            return new SuccessResult(Messages.Basarili);
        }

        public GenelAyarlar GetById(int id)
        {
            return _genelAyarlarRepository.Get(i => i.Id == id);
        }

        public List<GenelAyarlar> GetList()
        {
            return _genelAyarlarRepository.GetList().ToList();
        }

        public IDataResult<GenelAyarlar> Update(GenelAyarlar entity)
        {
            var result = _genelAyarlarRepository.Update(entity);
            if (!result.Success)
                return new ErrorDataResult<GenelAyarlar>(entity, Messages.Hata);
            return new SuccessDataResult<GenelAyarlar>(entity, Messages.Basarili);
        }
    }
}
