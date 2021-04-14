using BaseCore.Constants;
using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Application.Services
{
    public class SosyalMedyaService : ISosyalMedyaService
    {
        readonly ISosyalMedyaRepository _SosyalMedyaRepository;

        public SosyalMedyaService(ISosyalMedyaRepository SosyalMedyaRepository)
        {
            _SosyalMedyaRepository = SosyalMedyaRepository;
        }

        public IDataResult<SosyalMedya> Add(SosyalMedya entity)
        {
            var result = _SosyalMedyaRepository.Add(entity);
            if (!result.Success)
                return new ErrorDataResult<SosyalMedya>(entity, Messages.Hata);
            return new SuccessDataResult<SosyalMedya>(entity, Messages.Basarili);
        }

        public IResult Delete(SosyalMedya entity)
        {
            var result = _SosyalMedyaRepository.Delete(entity);
            if (!result.Success)
                return new ErrorResult(Messages.Hata);
            return new SuccessResult(Messages.Basarili);
        }

        public IResult DeleteList(List<SosyalMedya> entities)
        {
            foreach (var entitiy in entities)
            {
                _SosyalMedyaRepository.Delete(entitiy);
            }
            return new SuccessResult(Messages.Basarili);
        }

        public SosyalMedya GetById(int id)
        {
            return _SosyalMedyaRepository.Get(x => x.Id == id);
        }

        public List<SosyalMedya> GetList()
        {
            return _SosyalMedyaRepository.GetList().ToList();
        }

        public IDataResult<SosyalMedya> Update(SosyalMedya entity)
        {
            var result = _SosyalMedyaRepository.Update(entity);
            if (!result.Success)
                return new ErrorDataResult<SosyalMedya>(entity, Messages.Hata);
            return new SuccessDataResult<SosyalMedya>(entity, Messages.Basarili);
        }
    }
}
