using BaseCore.Constants;
using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Application.Services
{
    public class SeoAyarlariService : ISeoAyarlariService
    {
        readonly ISeoAyarlariRepository _seoAyarlariRepository;

        public SeoAyarlariService(ISeoAyarlariRepository seoAyarlariRepository)
        {
            _seoAyarlariRepository = seoAyarlariRepository;
        }

        public IDataResult<SeoAyarlari> Add(SeoAyarlari entity)
        {
            var result = _seoAyarlariRepository.Add(entity);
            if (!result.Success)
                return new ErrorDataResult<SeoAyarlari>(entity, Messages.Hata);
            return new SuccessDataResult<SeoAyarlari>(entity, Messages.Basarili);
        }

        public IResult Delete(SeoAyarlari entity)
        {
            var result = _seoAyarlariRepository.Delete(entity);
            if (!result.Success)
                return new ErrorResult(Messages.Hata);
            return new SuccessResult(Messages.Basarili);
        }

        public IResult DeleteList(List<SeoAyarlari> entities)
        {
            foreach (var entitiy in entities)
            {
                _seoAyarlariRepository.Delete(entitiy);
            }
            return new SuccessResult(Messages.Basarili);
        }

        public SeoAyarlari GetById(int id)
        {
            return _seoAyarlariRepository.Get(x => x.Id == id);
        }

        public List<SeoAyarlari> GetList()
        {
            return _seoAyarlariRepository.GetList().ToList();
        }

        public IDataResult<SeoAyarlari> Update(SeoAyarlari entity)
        {
            var result = _seoAyarlariRepository.Update(entity);
            if (!result.Success)
                return new ErrorDataResult<SeoAyarlari>(entity, Messages.Hata);
            return new SuccessDataResult<SeoAyarlari>(entity, Messages.Basarili);
        }
    }
}
