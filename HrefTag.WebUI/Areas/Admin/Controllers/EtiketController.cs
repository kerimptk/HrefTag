using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using BaseCore.Aspects.Validation;
using BaseCore.Controllers.MVC;
using Blog.Application.Validations.FluentValidation;
using Blog.Domain.DataTransferObjects;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using HrefTag.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize]
    public class EtiketController : BaseController
    {
        IHttpContextAccessor httpContextAccessor;
        IEtiketService _etiketService;
        IEtiketYaziService _etiketYaziService;
        IMapper _mapper;
        public EtiketController(
            IHttpContextAccessor _httpContextAccessor,
            IEtiketService etiketService,
            IEtiketYaziService etiketYaziService,
            IMapper mapper) : base(_httpContextAccessor)
        {
            _mapper = mapper;
            _etiketService = etiketService;
            _etiketYaziService = etiketYaziService;
        }

        public IActionResult Etiketler()
        {
            var etiketList = _etiketService.GetList();
            var etiketListMap = _mapper.Map<List<EtiketDto>>(etiketList);

            var ViewModel = new AdminEtiketViewModel()
            {
                etiketDtos = etiketListMap
            };
            return View(ViewModel);
        }

        public IActionResult etiketSil(int id)
        {
            var silinecekEtiketler = _etiketYaziService.GetList().Where(i => i.EtiketId == id).ToList();
            foreach (var item in silinecekEtiketler)
            {
                _etiketYaziService.Delete(item);
            }

            _etiketService.Delete(new Etiket
            {
                Id = id
            });
            return RedirectToAction("Etiketler");
        }

        [HttpPost]
        public IActionResult etiketDuzenle(Etiket item)
        {
            var eski = _etiketService.GetById(item.Id);
            eski.Ad = item.Ad;
            eski.UrlAd = item.UrlAd;

            _etiketService.Update(eski);
            return RedirectToAction("Etiketler");
        }
    }
}