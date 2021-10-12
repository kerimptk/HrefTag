using BaseCore.Constants;
using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Application.Services
{
    public class YaziService : IYaziService
    {
        readonly IYaziRepository _yaziRepository;

        public YaziService(IYaziRepository yaziRepository)
        {
            _yaziRepository = yaziRepository;
        }

        public IDataResult<Yazi> Add(Yazi entity)
        {
            var result = _yaziRepository.Add(entity);
            if (!result.Success)
                return new ErrorDataResult<Yazi>(entity, Messages.Hata);
            return new SuccessDataResult<Yazi>(entity, Messages.Basarili);
        }

        public IResult Delete(Yazi entity)
        {
            var result = _yaziRepository.Delete(entity);
            if (!result.Success)
                return new ErrorResult(Messages.Hata);
            return new SuccessResult(Messages.Basarili);
        }

        public IResult DeleteList(List<Yazi> entities)
        {
            foreach (var entitiy in entities)
            {
                _yaziRepository.Delete(entitiy);
            }
            return new SuccessResult(Messages.Basarili);
        }

        public List<Yazi> GetList()
        {
            return _yaziRepository.GetList().ToList();
        }

        public Yazi GetById(int id)
        {
            return _yaziRepository.Get(x => x.Id == id);
        }

        public Yazi GetWithKategoriYaziById(int id)
        {
            return _yaziRepository.GetWithKategoriYazi(x => x.Id == id);
        }

        public IDataResult<Yazi> Update(Yazi entity)
        {
            var result = _yaziRepository.Update(entity);
            if (!result.Success)
                return new ErrorDataResult<Yazi>(entity, Messages.Hata);
            return new SuccessDataResult<Yazi>(entity, Messages.Basarili);
        }

        public List<Yazi> GetListWithKategoriByOnayli()
        {
            return _yaziRepository.GetListWithKategori(i => i.OnayDurumuId == 1).OrderByDescending(i => i.Id).ToList();
        }

        public List<Yazi> GetListOnayli()
        {
            return _yaziRepository.GetList(i => i.OnayDurumuId == 1).OrderByDescending(i => i.Id).ToList();
        }

        public List<Yazi> GetListCokOkunanlar()
        {
            return _yaziRepository.GetListWithKategori(i => i.OnayDurumuId == 1).OrderByDescending(i => i.OkunmaSayisi).ToList();
        }

        public Yazi GetOnayliByUrlBaslik(string urlbaslik)
        {
            return _yaziRepository.Get(i => i.UrlBaslik == urlbaslik && i.OnayDurumuId == 1);
        }

        public Yazi GetByUrlBaslik(string urlbaslik)
        {
            return _yaziRepository.Get(i => i.UrlBaslik == urlbaslik);
        }
        public List<Yazi> GetListOneCikan()
        {
            return _yaziRepository.GetListWithKategori(i => i.OneCikan == 1 && i.OnayDurumuId == 1).OrderByDescending(i => i.Id).ToList();
        }
        public List<Yazi> GetListDuyurular()
        {
            return _yaziRepository.GetListWithKategori(i => i.DuyuruMu == 1 && i.OnayDurumuId == 1).OrderByDescending(i => i.Id).ToList();
        }

        public List<Yazi> GetListSilinmemisWithUser()
        {
            return _yaziRepository.GetListWithUser(x => x.SilId == 0).OrderByDescending(i => i.Id).ToList();
        }

        public List<Yazi> GetListSilinenWithUser()
        {
            return _yaziRepository.GetListWithUser(x => x.SilId == 1).ToList();
        }

        public List<Yazi> GetAramaSonucList(string keyword)
        {
            return _yaziRepository.GetList(x => x.OnayDurumuId == 1 && (x.Baslik.Contains(keyword) || x.Icerik.Contains(keyword))).ToList();
        }
    }
}
