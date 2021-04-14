using AutoMapper;
using Blog.Domain.Interfaces;
using HrefTag.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Blog.Domain.DataTransferObjects;

namespace HrefTag.WebUI.Controllers
{
    public class KategoriController : Controller
    {
        IKategoriService _kategoriService;
        IKategoriYaziService _kategoriYaziService;
        IReklamAlanlariService _reklamAlanlariService;
        IMapper _mapper;
        public KategoriController(
            IKategoriService kategoriService,
            IKategoriYaziService kategoriYaziService,
            IReklamAlanlariService reklamAlanlariService,
            IMapper mapper
            )
        {
            _kategoriService = kategoriService;
            _kategoriYaziService = kategoriYaziService;
            _reklamAlanlariService = reklamAlanlariService;
            _mapper = mapper;
        }


        [Route("Kategori/{kat}")]
        public IActionResult kategori(string kat)
        {
            var kategori = _kategoriService.GetByAd(kat);

            if (kategori == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            var kategoriYazilar = _kategoriYaziService.GetListByKategoriIdWithYazi(kategori.Id);
            var kategoriYaziMap = _mapper.Map<List<KategoriYaziListDto>>(kategoriYazilar);

            var reklamlar = _reklamAlanlariService.GetList();
            var reklamlarMap = _mapper.Map<List<ReklamAlanlariDto>>(reklamlar);

            var viewModel = new KategoriYaziViewModel()
            {
                kategoriYaziListDtos = kategoriYaziMap,
                reklamAlanlariDtos = reklamlarMap
            };

            return View(viewModel);
        }
    }
}
