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
    public class YorumController : Controller
    {
        IYorumService _yorumService;
        IMapper _mapper;

        public YorumController(
            IYorumService yorumlarService,
            IMapper mapper)
        {
            _yorumService = yorumlarService;
            _mapper = mapper;
        }


        public IActionResult OnayBekleyenler()
        {
            var yorumlar = _yorumService.GetOnayBekleyelerList();
            var yorumlarMap = _mapper.Map<List<YorumDto>>(yorumlar);
            var viewModel = new AdminYorumViewModel(){
                yorumDtos = yorumlarMap
            };
            return View(viewModel);
        }


        public IActionResult Onaylananlar()
        {
            var yorumlar = _yorumService.GetOnaylilarList();
            var yorumlarMap = _mapper.Map<List<YorumDto>>(yorumlar);
            var viewModel = new AdminYorumViewModel()
            {
                yorumDtos = yorumlarMap
            };
            return View(viewModel);
        }
        
        [HttpPost]
        public IActionResult onayla(int id)
        {
            var yorum = _yorumService.GetById(id);
            yorum.OnayDurumuId = 1;
            _yorumService.Update(yorum);
            return RedirectToAction("OnayBekleyenler");
        }


        [HttpPost]
        public IActionResult OnayKaldir(int id)
        {
            var yorum = _yorumService.GetById(id);
            yorum.OnayDurumuId = 0;
            _yorumService.Update(yorum);
            return RedirectToAction("Onaylananlar");
        }


        [HttpPost]
        public IActionResult copeat(int id)
        {
            var yorum = _yorumService.GetById(id);
            yorum.SilId = 1;
            yorum.OnayDurumuId = 0;
            _yorumService.Update(yorum);
            return RedirectToAction("OnayBekleyenler");
        }


        [HttpPost]
        public IActionResult geriyukle(int id)
        {
            var yorum = _yorumService.GetById(id);
            yorum.SilId = 0;
            _yorumService.Update(yorum);
            return RedirectToAction("OnayBekleyenler");
        }


        [HttpPost]
        public IActionResult YorumDuzenle(YorumDto item)
        {
            var yorum = _yorumService.GetById(item.Id);
            yorum.AdSoyad = item.AdSoyad;
            yorum.CevaplananYorumId = yorum.CevaplananYorumId;
            yorum.Email = item.Email;
            yorum.InsertDate = yorum.InsertDate;
            yorum.IpAdres = yorum.IpAdres;
            yorum.OnayDurumuId = yorum.OnayDurumuId;
            yorum.UpdateDate = DateTime.Now;
            yorum.Website = item.Website;
            yorum.Yazi = yorum.Yazi;
            yorum.YaziId = yorum.YaziId;
            yorum.KullaniciYorumu = item.KullaniciYorumu;
            _yorumService.Update(yorum);
            return RedirectToAction("OnayBekleyenler");
        }

        public IActionResult geridonusumkutusu()
        {
            var yorumlar = _yorumService.GetSilinmisList();
            var yorumlarMap = _mapper.Map<List<YorumDto>>(yorumlar);
            var viewModel = new AdminYorumViewModel()
            {
                yorumDtos = yorumlarMap
            };
            return View(viewModel);
        }
    }
}