using AutoMapper;
using Blog.Domain.Interfaces;
using HrefTag.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Blog.Domain.DataTransferObjects;

namespace HrefTag.WebUI.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {

        IGenelAyarlarService _genelAyarlarService;
        ISeoAyarlariService _seoAyarlariService;
        IMapper _mapper;
        public HeaderViewComponent(
             IGenelAyarlarService genelAyarlarService,
             ISeoAyarlariService seoAyarlariService,
             IMapper mapper
            )
        {
            _genelAyarlarService = genelAyarlarService;
            _seoAyarlariService = seoAyarlariService;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var ayar = _genelAyarlarService.GetById(1);
            var ayarMap = _mapper.Map<GenelAyarlarDto>(ayar);

            var seo = _seoAyarlariService.GetById(1);
            var seoMap = _mapper.Map<SeoAyarlariDto>(seo);

            var ViewModel = new HeaderViewModel()
            {
                seoAyarlariDto = seoMap,
                genelAyarlarDto = ayarMap
            };
            return View(ViewModel);
        }
    }
}
