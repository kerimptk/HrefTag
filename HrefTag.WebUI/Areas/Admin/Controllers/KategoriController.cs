using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Domain.DataTransferObjects;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using HrefTag.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HrefTag.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class KategoriController : Controller
    {
        IKategoriService _kategoriService;
        IMapper _mapper;
        public KategoriController(IKategoriService kategoriService,
            IMapper mapper)
        {
            _kategoriService = kategoriService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var kategoriler = _kategoriService.GetList();
            var kategorilerMap = _mapper.Map<List<KategoriDto>>(kategoriler);

            var viewModel = new AdminKategoriViewModel()
            {
                kategoriDtos = kategorilerMap,
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Index(Kategori item)
        {
            item.InsertDate = DateTime.Now;
            _kategoriService.Add(item);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult KategoriSil(int id)
        {
            _kategoriService.Delete(new Kategori
            {
                Id = id
            });
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult KategoriDuzenle(Kategori item)
        {
            var eski = _kategoriService.GetById(item.Id);
            eski.UpdateDate = DateTime.Now;
            eski.Ad = item.Ad;
            eski.RenkKodu = item.RenkKodu;
            eski.UrlAd = item.UrlAd;
            eski.YaziSayisi = eski.YaziSayisi;
            eski.ParentId = item.ParentId;
           
            _kategoriService.Update(eski);
            return RedirectToAction("Index");
        }
    }
}