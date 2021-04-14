using BaseCore.Constants;
using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Application.Services
{
    public class YorumService : IYorumService
    {
        readonly IYorumRepository _yorumRepository;

        public YorumService(IYorumRepository yorumRepository)
        {
            _yorumRepository = yorumRepository;
        }

        public IDataResult<Yorum> Add(Yorum entity)
        {
            var result = _yorumRepository.Add(entity);
            if (!result.Success)
                return new ErrorDataResult<Yorum>(entity, Messages.Hata);
            return new SuccessDataResult<Yorum>(entity, Messages.Basarili);
        }

        public IResult Delete(Yorum entity)
        {
            var result = _yorumRepository.Delete(entity);
            if (!result.Success)
                return new ErrorResult(Messages.Hata);
            return new SuccessResult(Messages.Basarili);
        }

        public IResult DeleteList(List<Yorum> entities)
        {
            foreach (var entitiy in entities)
            {
                _yorumRepository.Delete(entitiy);
            }
            return new SuccessResult(Messages.Basarili);
        }

        public List<Yorum> GetList()
        {
            return _yorumRepository.GetList().ToList();
        }

        public Yorum GetById(int id)
        {
            return _yorumRepository.Get(x => x.Id == id);
        }

        public IDataResult<Yorum> Update(Yorum entity)
        {
            var result = _yorumRepository.Update(entity);
            if (!result.Success)
                return new ErrorDataResult<Yorum>(entity, Messages.Hata);
            return new SuccessDataResult<Yorum>(entity, Messages.Basarili);
        }

        public List<Yorum> GetOnayBekleyelerList()
        {
            return _yorumRepository.GetList(i => i.OnayDurumuId == 0 && i.SilId == 0).ToList();
        }

        public List<Yorum> GetOnaylilarList()
        {
            return _yorumRepository.GetList(i => i.OnayDurumuId == 1).ToList();
        }

        public List<Yorum> GetSilinmisList()
        {
            return _yorumRepository.GetList(i => i.SilId == 1).ToList();
        }
    }
}
