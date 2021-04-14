﻿using AutoMapper;
using Blog.Domain.Interfaces;
using HrefTag.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Blog.Domain.DataTransferObjects;

namespace HrefTag.WebUI.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        IKategoriService _kategoriService;
        ISayfaService _sayfaService;
        ISosyalMedyaService _sosyalMedyaService;
        IGenelAyarlarService _genelAyarlarService;
        ISeoAyarlariService _seoAyarlariService;
        IMapper _mapper;
        public SidebarViewComponent(
             IKategoriService kategoriService,
             ISayfaService sayfaService,
             ISosyalMedyaService sosyalMedyaService,
             IGenelAyarlarService genelAyarlarService,
             ISeoAyarlariService seoAyarlariService,
             IMapper mapper
            )
        {
            _kategoriService = kategoriService;
            _sayfaService = sayfaService;
            _sosyalMedyaService = sosyalMedyaService;
            _genelAyarlarService = genelAyarlarService;
            _seoAyarlariService = seoAyarlariService;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var kategoriler = _kategoriService.GetList();
            var kategoriListMap = _mapper.Map<List<KategoriDto>>(kategoriler);

            var sayfa = _sayfaService.GetOnayliList();
            var sayfaMap = _mapper.Map<List<SayfaDto>>(sayfa);

            var sosyalMedya = _sosyalMedyaService.GetList();
            var sosyalMedyaMap = _mapper.Map<List<SosyalMedyaDto>>(sosyalMedya);

            var genelAyarlar = _genelAyarlarService.GetById(1);
            var genelAyarlarMap = _mapper.Map<GenelAyarlarDto>(genelAyarlar);

            var seoAyarlari = _seoAyarlariService.GetById(1);
            var seoAyarlariMap = _mapper.Map<SeoAyarlariDto>(seoAyarlari);

            var ViewModel = new SidebarViewModel()
            {
                KategoriDtos = kategoriListMap,
                sayfaDtos = sayfaMap,
                sosyalMedyaDtos = sosyalMedyaMap,
                genelAyarlarDto = genelAyarlarMap,
                seoAyarlariDto = seoAyarlariMap
            };
            return View(ViewModel);
        }
    }
}
