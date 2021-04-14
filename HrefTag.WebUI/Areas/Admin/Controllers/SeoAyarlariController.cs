using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Blog.Domain.Interfaces;
using AutoMapper;
using Blog.Domain.DataTransferObjects;
using System.Collections.Generic;
using HrefTag.WebUI.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace HrefTag.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SeoAyarlariController : Controller
    {
        ISeoAyarlariService _seoAyarlariService;
        IMapper _mapper;
        public SeoAyarlariController(ISeoAyarlariService seoAyarlariService,
            IMapper mapper)
        {
            _seoAyarlariService = seoAyarlariService;
            _mapper = mapper;
        }

        public IActionResult index()
        {
            var seoAyarlari = _seoAyarlariService.GetById(1);
            var seoAyarlariMap = _mapper.Map<SeoAyarlariDto>(seoAyarlari);

            var viewModel = new AdminSeoAyarlariViewModel()
            {
                seoAyarlariDto = seoAyarlariMap
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> index(SeoAyarlariDto seoAyarlariDto)
        {
            var seoAyarlari = _seoAyarlariService.GetList().Where(i => i.Id == seoAyarlariDto.Id).FirstOrDefault();
            seoAyarlari.Ad = seoAyarlariDto.Ad;
            seoAyarlari.Analytics = seoAyarlariDto.Analytics;
            seoAyarlari.Description = seoAyarlariDto.Description;
            seoAyarlari.Keywords = seoAyarlariDto.Keywords;
            seoAyarlari.Title = seoAyarlariDto.Title;
            seoAyarlari.UpdateDate = DateTime.Now;
            _seoAyarlariService.Update(seoAyarlari);
            return RedirectToAction("Index");
        }
    }
}