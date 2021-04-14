using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
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
    public class IletisimBilgileriController : Controller
    {
        IIletisimBilgileriService _iletisimBilgileriService;
        IMapper _mapper;
        public IletisimBilgileriController(
            IIletisimBilgileriService iletisimBilgileriService,
            IMapper mapper)
        {
            _iletisimBilgileriService = iletisimBilgileriService;
            _mapper = mapper;
        }

        public IActionResult index()
        {
            var iletisimBilgileri = _iletisimBilgileriService.GetList();
            var iletisimBilgileriMap = _mapper.Map<List<IletisimBilgileriDto>>(iletisimBilgileri);

            var viewModel = new AdminIletisimBilgileriViewModel()
            {
                iletisimBilgileriDtos = iletisimBilgileriMap
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> index(IletisimBilgileriDto iletisimBilgileriDtos)
        {
            var iletisimBilgileri = _iletisimBilgileriService.GetList().Where(i => i.Id == iletisimBilgileriDtos.Id).FirstOrDefault();
            iletisimBilgileri.Aciklama = iletisimBilgileriDtos.Aciklama;
            iletisimBilgileri.Adres = iletisimBilgileriDtos.Adres;
            iletisimBilgileri.Eposta = iletisimBilgileriDtos.Eposta;
            iletisimBilgileri.Harita = iletisimBilgileriDtos.Harita;
            iletisimBilgileri.Telefon = iletisimBilgileriDtos.Telefon;
            _iletisimBilgileriService.Update(iletisimBilgileri);
            return RedirectToAction("Index");
        }
    }
}