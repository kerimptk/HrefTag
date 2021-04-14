﻿using AutoMapper;
using Blog.Domain.Interfaces;
using HrefTag.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Blog.Domain.DataTransferObjects;

namespace HrefTag.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IReklamAlanlariService _reklamAlanlariService;
        readonly IYaziService _yaziService;
        ISosyalMedyaService _sosyalMedyaService;
        readonly IMapper _mapper;
        public HomeController(
            IReklamAlanlariService reklamAlanlariService,
            IYaziService yaziService,
            ISosyalMedyaService sosyalMedyaService,
            IMapper mapper
            )
        {
            _reklamAlanlariService = reklamAlanlariService;
            _yaziService = yaziService;
            _sosyalMedyaService = sosyalMedyaService;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            var yazilar = _yaziService.GetListWithKategoriByOnayli();
            var yazilarMap = _mapper.Map<List<BlogYaziListDto>>(yazilar);

            var populer = _yaziService.GetListCokOkunanlar();
            var populerMap = _mapper.Map<List<BlogYaziListDto>>(populer);

            var oneCikan = _yaziService.GetListOneCikan();
            var oneCikanMap = _mapper.Map<List<BlogYaziListDto>>(oneCikan);

            var reklamlar = _reklamAlanlariService.GetList();
            var reklamlarMap = _mapper.Map<List<ReklamAlanlariDto>>(reklamlar);

            var sosyalMedya = _sosyalMedyaService.GetById(1);
            var sosyalMedyaMap = _mapper.Map<SosyalMedyaDto>(sosyalMedya);

            var viewModel = new HomeViewModel()
            {
                blogYaziListDtos = yazilarMap,
                populerIcerkler = populerMap,
                oneCikanlar = oneCikanMap,
                reklamAlanlariDtos = reklamlarMap,
                sosyalMedyaDto = sosyalMedyaMap
            };
            return View(viewModel);
        }
    }
}