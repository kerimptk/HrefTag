using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Blog.Domain.DataTransferObjects;
using Blog.Domain.Interfaces;
using HrefTag.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HrefTag.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ReklamAyarlariController : Controller
    {
        IReklamAlanlariService _reklamAlanlariService;
        IMapper _mapper;
        public ReklamAyarlariController (
            IReklamAlanlariService reklamAlanlariService,
            IMapper mapper)
        {
            _reklamAlanlariService = reklamAlanlariService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var reklamAlanlari = _reklamAlanlariService.GetList();
            var reklamAlanlariMap = _mapper.Map<List<ReklamAlanlariDto>>(reklamAlanlari);

            var viewModel = new AdminReklamAlanlariViewModel()
            {
                reklamAlanlariDtos = reklamAlanlariMap
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult ReklamDuzenle(ReklamAlanlariDto reklamAlanlariDto)
        {
            var reklamAlanlari = _reklamAlanlariService.GetList().Where(i => i.Id == reklamAlanlariDto.Id).FirstOrDefault();
            reklamAlanlari.Aciklama = reklamAlanlariDto.Aciklama;
            reklamAlanlari.AlanAdi = reklamAlanlariDto.AlanAdi;
            reklamAlanlari.Kodu = reklamAlanlariDto.Kodu;
            reklamAlanlari.UpdateDate = DateTime.Now;
            _reklamAlanlariService.Update(reklamAlanlari);
            return RedirectToAction("Index");
        }
    }
}