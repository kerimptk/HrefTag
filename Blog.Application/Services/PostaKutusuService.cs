using BaseCore.Constants;
using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Application.Services
{
    public class PostaKutusuService : IPostaKutusuService
    {
        readonly IPostaKutusuRepository _postaKutusuRepository;

        public PostaKutusuService(IPostaKutusuRepository postaKutusuRepository)
        {
            _postaKutusuRepository = postaKutusuRepository;
        }

        public IDataResult<PostaKutusu> Add(PostaKutusu entity)
        {
            var result = _postaKutusuRepository.Add(entity);
            if (!result.Success)
                return new ErrorDataResult<PostaKutusu>(entity, Messages.Hata);
            return new SuccessDataResult<PostaKutusu>(entity, Messages.Basarili);
        }

        public IResult Delete(PostaKutusu entity)
        {
            var result = _postaKutusuRepository.Delete(entity);
            if (!result.Success)
                return new ErrorResult(Messages.Hata);
            return new SuccessResult(Messages.Basarili);
        }

        public IResult DeleteList(List<PostaKutusu> entities)
        {
            foreach (var entitiy in entities)
            {
                _postaKutusuRepository.Delete(entitiy);
            }
            return new SuccessResult(Messages.Basarili);
        }

        public PostaKutusu GetById(int id)
        {
            return _postaKutusuRepository.Get(i => i.Id == id);
        }

        public List<PostaKutusu> GetDigerList()
        {
            return _postaKutusuRepository.GetList(i => i.Konu.Equals("Diğer") && i.SilId == 0).ToList();
        }

        public List<PostaKutusu> GetHataBildirimiList()
        {
            return _postaKutusuRepository.GetList(i => i.Konu.Equals("Hata Bildirimi") && i.SilId == 0).ToList();
        }

        public List<PostaKutusu> GetList()
        {
            return _postaKutusuRepository.GetList(i=> i.SilId == 0).ToList();
        }

        public List<PostaKutusu> GetOkunmamisList()
        {
            return _postaKutusuRepository.GetList(i=> i.OnayDurumuId == 0 && i.SilId == 0).ToList();
        }

        public List<PostaKutusu> GetOneriIstekList()
        {
            return _postaKutusuRepository.GetList(i => i.Konu.Equals("Öneri / İstek") && i.SilId == 0).ToList();
        }

        public List<PostaKutusu> GetReklamVeIsBirligiList()
        {
            return _postaKutusuRepository.GetList(i => i.Konu.Equals("Reklam ve İşbirliği") && i.SilId == 0).ToList();
        }

        public List<PostaKutusu> GetSilinmisList()
        {
            return _postaKutusuRepository.GetList(i => i.SilId == 1).ToList();
        }

        public IDataResult<PostaKutusu> Update(PostaKutusu entity)
        {
            var result = _postaKutusuRepository.Update(entity);
            if (!result.Success)
                return new ErrorDataResult<PostaKutusu>(entity, Messages.Hata);
            return new SuccessDataResult<PostaKutusu>(entity, Messages.Basarili);
        }
    }
}
