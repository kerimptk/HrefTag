using BaseCore.Constants;
using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Application.Services
{
    public class ReklamAlanlariService : IReklamAlanlariService
    {
        readonly IReklamAlanlariRepository _reklamAlanlariRepository;

        public ReklamAlanlariService(IReklamAlanlariRepository reklamAlanlariRepository)
        {
            _reklamAlanlariRepository = reklamAlanlariRepository;
        }

        public IDataResult<ReklamAlanlari> Add(ReklamAlanlari entity)
        {
            var result = _reklamAlanlariRepository.Add(entity);
            if (!result.Success)
                return new ErrorDataResult<ReklamAlanlari>(entity, Messages.Hata);
            return new SuccessDataResult<ReklamAlanlari>(entity, Messages.Basarili);
        }

        public IResult Delete(ReklamAlanlari entity)
        {
            var result = _reklamAlanlariRepository.Delete(entity);
            if (!result.Success)
                return new ErrorResult(Messages.Hata);
            return new SuccessResult(Messages.Basarili);
        }

        public IResult DeleteList(List<ReklamAlanlari> entities)
        {
            foreach (var entitiy in entities)
            {
                _reklamAlanlariRepository.Delete(entitiy);
            }
            return new SuccessResult(Messages.Basarili);
        }

        public List<ReklamAlanlari> GetList()
        {
            return _reklamAlanlariRepository.GetList().ToList();
        }

        public IDataResult<ReklamAlanlari> Update(ReklamAlanlari entity)
        {
            var result = _reklamAlanlariRepository.Update(entity);
            if (!result.Success)
                return new ErrorDataResult<ReklamAlanlari>(entity, Messages.Hata);
            return new SuccessDataResult<ReklamAlanlari>(entity, Messages.Basarili);
        }

        public ReklamAlanlari GetByAd(string Ad)
        {
            return _reklamAlanlariRepository.Get(x => x.AlanAdi == Ad);
        }
    }
}
