using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogUI.Models;
using Blog.Domain.Interfaces;
using AutoMapper;
using Blog.Domain.DataTransferObjects;
using HrefTag.WebUI.ViewModels;
using Blog.Domain.Entities;
using Blog.Domain.Enum;

namespace BlogUI.Controllers
{
    public class SayfaController : Controller
    {
        ISayfaService _sayfaService;
        IIletisimBilgileriService _iletisimBilgileriService;
        IYaziService _yaziService;
        IPostaKutusuService _postaKutusuService;
        IMapper _mapper;
        public SayfaController(
            ISayfaService sayfaService,
            IIletisimBilgileriService iletisimBilgileriService,
            IPostaKutusuService postaKutusuService,
            IYaziService yaziService,
            IMapper mapper)
        {
            _sayfaService = sayfaService;
            _yaziService = yaziService;
            _iletisimBilgileriService = iletisimBilgileriService;
            _postaKutusuService = postaKutusuService;
            _mapper = mapper;

        }

        [Route("Sayfa/{page}")]
        public IActionResult sayfa(string page)
        {
            var sayfa = _sayfaService.GetByUrlBaslik(page);

            if (sayfa == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            var sayfaMap = _mapper.Map<SayfaDto>(sayfa);

            var populerIcerikler = _yaziService.GetListCokOkunanlar();
            var populerIceriklerMap = _mapper.Map<List<PopulerIceriklerDto>>(populerIcerikler);

            var viewModel = new SayfaViewModel()
            {
                SayfaDtos = sayfaMap,
                populerIceriklerDtos = populerIceriklerMap
            };

            return View(viewModel);
        }

        [Route("Sayfa/iletisim")]
        public IActionResult iletisim()
        {
            var populerIcerikler = _yaziService.GetListCokOkunanlar();
            var populerIceriklerMap = _mapper.Map<List<PopulerIceriklerDto>>(populerIcerikler);

            var iletisimBilgileri = _iletisimBilgileriService.GetList();
            var iletisimBilgileriMap = _mapper.Map<List<IletisimBilgileriDto>>(iletisimBilgileri);

            var viewModel = new IletisimViewModel()
            {
                iletisimBilgileriDtos = iletisimBilgileriMap,
                populerIceriklerDtos = populerIceriklerMap
            };

            return View(viewModel);
        }

        [Route("Sayfa/SoruSor")]
        public IActionResult SoruSor()
        {
            var populerIcerikler = _yaziService.GetListCokOkunanlar();
            var populerIceriklerMap = _mapper.Map<List<PopulerIceriklerDto>>(populerIcerikler);

            var viewModel = new SayfaViewModel()
            {
                populerIceriklerDtos = populerIceriklerMap
            };
            return View(viewModel);
        }

        [HttpPost]
        [Route("Sayfa/SoruGonderildi")]
        public IActionResult SoruGonderildi(PostaKutusu item)
        {
            item.InsertDate = DateTime.Now;
            item.OnayDurumuId = (int)EOnayDurum.Taslak;
            item.Konu = "Soru";

            _postaKutusuService.Add(item);

            return RedirectToAction("SoruSor", "Sayfa");
        }
    }
}
