using AutoMapper;
using Blog.Domain.DataTransferObjects;
using Blog.Domain.Interfaces;
using HrefTag.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrefTag.WebUI.Areas.Admin.Controllers
{
    public class HeaderAdminViewComponent : ViewComponent
    {
        IGenelAyarlarService _genelAyarlarService;
        ISeoAyarlariService _seoAyarlariService;
        IMapper _mapper;
        public HeaderAdminViewComponent(
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
            var ayarlar = _genelAyarlarService.GetList();
            var ayarlarMap = _mapper.Map<List<GenelAyarlarDto>>(ayarlar);

            var seo = _seoAyarlariService.GetList();
            var seoMap = _mapper.Map<List<SeoAyarlariDto>>(seo);

            var todo = _genelAyarlarService.GetList();
            var todoMap = _mapper.Map<List<GenelAyarlarDto>>(todo);

            var viewModel = new AdminHeaderVievModel()
            {
                genelAyarlarDtos = ayarlarMap,
                seoAyarlariDtos = seoMap
            };
            return View(viewModel);
        }
    }
}
