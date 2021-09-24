using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Blog.Domain.Interfaces;
using Blog.Domain.DataTransferObjects;
using HrefTag.WebUI.ViewModels;
using AutoMapper;
using System.Collections.Generic;

namespace HrefTag.WebUI.Controls
{
    public class AramaController : Controller
    {

        IYaziService _yaziService;
        IReklamAlanlariService _reklamAlanlariService;
        IMapper _mapper;

        public AramaController(
            IReklamAlanlariService reklamAlanlariService,
            IYaziService yaziService,
            IMapper mapper)
        {
            _reklamAlanlariService = reklamAlanlariService;
            _yaziService = yaziService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AramaYap()
        {
            var reklamlar = _reklamAlanlariService.GetList();
            var reklamMap = _mapper.Map<List<ReklamAlanlariDto>>(reklamlar);

            var ViewModel = new SearchViewModel()
            {
                reklamAlanlariDtos = reklamMap
            };
            return View(ViewModel);
        }


        [HttpGet]
        public IActionResult AramaSonuclari()
        {
            return RedirectToAction("AramaYap","Arama");
        }

        [HttpPost]
        public IActionResult AramaSonuclari(HeaderViewModel headerViewModel)
        {
            var sonuclar = _yaziService.GetAramaSonucList(headerViewModel.keyword.ToString()).ToList();
            var sonuclarMap = _mapper.Map<List<SearchResponseDto>>(sonuclar);

            var populerIcerikler = _yaziService.GetListCokOkunanlar();
            var populerIceriklerMap = _mapper.Map<List<PopulerIceriklerDto>>(populerIcerikler);

            var ViewModel = new SearchViewModel()
            {
                searchResponseDtos = sonuclarMap,
                populerIceriklerDtos = populerIceriklerMap
            };
            return View(ViewModel);
        }
    }
}
