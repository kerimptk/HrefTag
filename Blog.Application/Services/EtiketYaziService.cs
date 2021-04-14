using BaseCore.Constants;
using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Application.Services
{
    public class EtiketYaziService : IEtiketYaziService
    {
        readonly IEtiketYaziRepository _etiketYaziRepository;

        public EtiketYaziService(IEtiketYaziRepository etiketYaziRepository)
        {
            _etiketYaziRepository = etiketYaziRepository;
        }

        public IDataResult<EtiketYazi> Add(EtiketYazi entity)
        {
            var result = _etiketYaziRepository.Add(entity);
            if (!result.Success)
                return new ErrorDataResult<EtiketYazi>(entity, Messages.Hata);
            return new SuccessDataResult<EtiketYazi>(entity, Messages.Basarili);
        }

        public IResult Delete(EtiketYazi entity)
        {
            var result = _etiketYaziRepository.Delete(entity);
            if (!result.Success)
                return new ErrorResult(Messages.Hata);
            return new SuccessResult(Messages.Basarili);
        }

        public IResult DeleteList(List<EtiketYazi> entities)
        {
            foreach (var entitiy in entities)
            {
                _etiketYaziRepository.Delete(entitiy);
            }
            return new SuccessResult(Messages.Basarili);
        }

        public List<EtiketYazi> GetList()
        {
            return _etiketYaziRepository.GetList().ToList();
        }

        public EtiketYazi GetById(int id)
        {
            return _etiketYaziRepository.Get(x => x.Id == id);
        }

        public IDataResult<EtiketYazi> Update(EtiketYazi entity)
        {
            var result = _etiketYaziRepository.Update(entity);
            if (!result.Success)
                return new ErrorDataResult<EtiketYazi>(entity, Messages.Hata);
            return new SuccessDataResult<EtiketYazi>(entity, Messages.Basarili);
        }
    }
}
