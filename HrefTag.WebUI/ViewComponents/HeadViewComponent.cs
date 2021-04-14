using AutoMapper;
using Blog.Domain.DataTransferObjects;
using Blog.Domain.Interfaces;
using HrefTag.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogUI.Models.ViewComponents
{
    public class HeadViewComponent : ViewComponent
    {
        ISeoAyarlariService _seoAyarlariService;
        IGenelAyarlarService _genelAyarlarService;
        IMapper _mapper;
        public HeadViewComponent(ISeoAyarlariService seoAyarlariService
            , IGenelAyarlarService genelAyarlarService
            , IMapper mapper)
        {
            _seoAyarlariService = seoAyarlariService;
            _genelAyarlarService = genelAyarlarService;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var ayarlar = _genelAyarlarService.GetList();
            var ayarlarMap = _mapper.Map<List<GenelAyarlarDto>>(ayarlar);

            var seo = _seoAyarlariService.GetById(1);
            var seoMap = _mapper.Map<SeoAyarlariDto>(seo);

            var ViewModel = new HeadViewModel()
            {
                seoAyarlariDto = seoMap,
                genelAyarlarDtos = ayarlarMap
            };
            return View(ViewModel);
        }
    }
}
